(*
    fHexDump.fs

    2021-10-10

    Hexdump written in F#

    try: (Zsh)
    diff -y --suppress-common-lines  <(hexdump -vC ~/nohup.out | tr -s ' ') <(fHexDump -w 16 ~/nohup.out  | tr -s ' ')

    The MIT License (MIT)

    Copyright (c) 2021 Bernard TATIN

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.

 *)

namespace fHexDump

module main =
    open System
    open Libraries.LibFiles
    open Libraries.LibInt
    open Libraries.LibArguments
    open fHexDump.Version
    open fHexDump.Help

    // show binary format
    let mutable is_binary = false

    // size of read buffer
    let mutable bufferSize = 16

    // closure to get the format of the full line
    let getFullLineFormat (newBufferSize: int) new_is_binary : unit -> Printf.TextWriterFormat<_> =
        let newFormat =
            if new_is_binary then
                Printf.TextWriterFormat<_>(sprintf "%%08x  %%-%ds |%%s|" (newBufferSize * 9))
            else
                Printf.TextWriterFormat<_>(sprintf "%%08x  %%-%ds |%%s|" (newBufferSize * 3))

        let returnF () = newFormat
        bufferSize <- newBufferSize
        is_binary <- new_is_binary
        returnF

    // the current format of the full line
    let mutable fullLineFormat = getFullLineFormat bufferSize is_binary

    // called on each buffer read
    let on_buffer address lst_buffer =
        // byte to hexadecimal
        let to_hex (b: byte) : string =
            if is_binary then
                $"%08B{int b} "
            else
                $"%02x{int b} "
        // byte to ASCII: only values from 32 to 126 are unchanged,
        // others are replaced by '.'
        let to_good_ascii (b: byte) =
            if b < (byte 32) then "."
            else if b > (byte 126) then "."
            else (string (Convert.ToChar(b)))

        // functions to construct hexadecimal and ASCII strings
        let add_str s1 s2 = s1 + s2
        // hexadecimal string creation
        let hex =
            lst_buffer
            |> List.map to_hex
            |> List.fold add_str ""
        // ASCII string creation
        let asc =
            lst_buffer
            |> List.map to_good_ascii
            |> List.fold add_str ""
        // print the result
        printfn (fullLineFormat ()) address hex asc

    let on_files =
        function
        | [] ->
            let lastAddress =
                binary_file_reader (StdIn true) on_buffer bufferSize

            printfn $"%08x{lastAddress}"
            0
        | f :: rest ->
            let rec the_loop =
                function
                | [] -> 0
                | f :: rest ->
                    let lastAddress =
                        binary_file_reader (FileName f) on_buffer bufferSize

                    printfn $"%08x{lastAddress}"

                    the_loop rest

            the_loop (f :: rest)

    // hexdump all files
    let rec on_argument =
        function
        | [] -> on_files []
        | "--hexa" :: rest
        | "-x" :: rest ->
            fullLineFormat <- getFullLineFormat bufferSize false
            on_argument rest
        | "--binary" :: rest
        | "-b" :: rest ->
            fullLineFormat <- getFullLineFormat bufferSize true
            on_argument rest
        | "--width" :: rest
        | "-w" :: rest ->
            match rest with
            | [] -> help 1
            | iStr :: rest ->
                fullLineFormat <- getFullLineFormat (str2int iStr) is_binary
                on_argument rest
        | f :: rest -> on_files (f :: rest)


    // main entry point
    [<EntryPoint>]
    let main argv =
        if Array.isEmpty argv then
            on_files []
        else if (has_argument "help" "h" argv) then
            help 0
        else if (has_argument "version" "v" argv) then
            version ()
        else
            argv |> Array.toList |> on_argument

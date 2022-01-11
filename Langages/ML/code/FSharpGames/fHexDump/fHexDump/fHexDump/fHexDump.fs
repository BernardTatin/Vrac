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
    open Libraries.LibTools
    open Libraries.LibFiles
    open Libraries.LibInt

    // not in the command line parameters
    let exe_name = "fHexDump"
    let exe_version = "0.2.2"
    // show binary format
    let mutable is_binary = false
    // Show the help message
    let help exit_code =
        let lines =
            [ $"{exe_name} - A little help from your friends"
              $"{exe_name} [-h|--help]: the little help from your friends"
              $"{exe_name} -v|--version: show the version information then exits"
              $"{exe_name} [OPTIONS] [FILES ..."
              "OPTIONS:"
              "     -b|--binary: print in binary"
              "     -x|--hexa: print in hexadecimal (default)"
              "     -w|--width integer: number of bytes on each lines" ]

        print_lines lines exit_code

    // Show the version
    let rec version () =
        let lines =
            [ $"{exe_name} version {version}" ]

        print_lines lines 0

    // size of read buffer
    let mutable bufferSize = 16

    let getFormat (newBufferSize: int) : unit -> Printf.TextWriterFormat<_> =
        let newFormat : Printf.TextWriterFormat<_> = if is_binary then Printf.TextWriterFormat<_>(sprintf "%%08x  %%-%ds |%%s|" (newBufferSize * 9))
                                                        else Printf.TextWriterFormat<_>(sprintf "%%08x  %%-%ds |%%s|" (newBufferSize * 3))
        let returnF() = newFormat
        bufferSize <- newBufferSize
        returnF

    let mutable format = getFormat(bufferSize)

    let on_buffer address lst_buffer =
        // byte to hexadecimal
        let to_hex (b: byte) : string =
            if is_binary then $"%08B{int b} "
                                  else $"%02x{int b} "
//            if is_binary then (sprintf "%02x " (int b))
//                         else  (sprintf "%B " (int b))
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
        printfn (format ()) address hex asc

    // hexdump all files
    let rec all_files =
        function
        | [] -> 0
        | "--hexa" :: rest
        | "-x" :: rest ->
            is_binary <- false
            format <- getFormat(bufferSize)
            all_files rest
        | "--binary" :: rest
        | "-b" :: rest ->
            is_binary <- true
            format <- getFormat(bufferSize)
            all_files rest
        | "--width" :: rest
        | "-w" :: rest ->
            match rest with
            | [] -> help 1
            | iStr :: rest ->
                format <- getFormat(str2int iStr)
                all_files rest
        | f :: rest ->
            let lastAddress = binary_file_reader f on_buffer bufferSize
            printfn $"%08x{lastAddress}"
            |> ignore

            all_files rest

    // search a command line argument
    let has_argument name short_name args =
        args
        |> Array.exists
            (fun x ->
                x = ("--" + name)
                || x = ("/" + name)
                || x = $"-{short_name}")

    [<EntryPoint>]
    let main argv =
        if Array.isEmpty argv then
            help 0
        else if (has_argument "help" "h" argv) then
            help 0
        else if (has_argument "version" "v" argv) then
            version ()
        else
            argv |> Array.toList |> all_files

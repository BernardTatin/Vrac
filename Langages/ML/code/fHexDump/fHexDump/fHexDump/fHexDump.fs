(*
    fHexDump.fs

    bernard.tatin@outlook.fr
    2021-10-10

    Hexdump written in F#
 *)

namespace fHexDump

module main =
    open System
    open Libraries.LibTools
    open Libraries.LibFiles
    open Libraries.LibInt

    // not in the command line parameters
    let exe_name = "fHexDump"
    let exe_version = "0.2.0"
    // Show the help message
    let help exit_code =
        let lines =
            [ (sprintf "%s - Some help from your friends" exe_name)
              (sprintf "%s [-h|--help]: show this text and exits" exe_name)
              (sprintf "%s -v|--version: show the version informations then exits" exe_name)
              (sprintf "%s [OPTIONS] [FILES ..." exe_name)
              "OPTIONS:"
              "     -w|--width integer: number of bytes on each lines" ]

        print_lines lines exit_code

    // Show the version
    let version () =
        let lines =
            [ (sprintf "%s version %s" exe_name exe_version) ]

        print_lines lines 0

    // size of read buffer
    let mutable bufferSize = 16

    let mutable format: Printf.TextWriterFormat<_> =
        Printf.TextWriterFormat<_>(sprintf "%%08x: %%-%ds '%%s'" (bufferSize * 3))

    let on_buffer address lst_buffer =
        // byte to hexadecimal
        let to_hex (b: byte) : string = sprintf "%02x" (int b)
        // byte to ASCII: only values from 32 to 126 are unchanged,
        // others are replaced by '.'
        let to_good_ascii (b: byte) =
            if b < (byte 32) then "."
            else if b > (byte 126) then "."
            else (string (Convert.ToChar(b)))

        // functions to construct hexadecimal and ASCII strings
        let add_str1 s1 s2 = s1 + " " + s2
        let add_str2 s1 s2 = s1 + s2
        // hexadecimal string creation
        let hex =
            lst_buffer
            |> List.map to_hex
            |> List.fold add_str1 ""
        // ASCII string creation
        let asc =
            lst_buffer
            |> List.map to_good_ascii
            |> List.fold add_str2 ""
        // print the result
        printfn format address hex asc
    // $"%08x{address}: %-48s{hex} %s{asc}"

    // hexdump core

    // hexdump all files
    let rec all_files =
        function
        | [] -> 0
        | "--width" :: rest
        | "-w" :: rest ->
            match rest with
            | [] -> help 1
            | istr :: rest ->
                bufferSize <- str2int istr
                format <- Printf.TextWriterFormat<_>(sprintf "%%08x: %%-%ds '%%s'" (bufferSize * 3))
                all_files rest
        | f :: rest ->
            binary_file_reader f on_buffer bufferSize
            |> ignore

            all_files rest

    // search a command line argument
    let has_argument name short_name args =
        args
        |> Array.exists
            (fun x ->
                x = ("--" + name)
                || x = ("/" + name)
                || x = sprintf "-%s" short_name)

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

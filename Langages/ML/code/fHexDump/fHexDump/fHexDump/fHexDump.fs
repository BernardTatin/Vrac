(*
    fHexDump.fs

    bernard.tatin@outlook.fr
    2021-10-10

    Hexdump written in F#
 *)

namespace fHexDump

module main =
    open System
    open System.IO
    open Libraries.LibTool

    let exe_name = "fHexDump"
    let exe_version = "0.1.0"
    // Define a function to construct a message to print
    let help exit_code =
        let lines =
            [ (sprintf "%s - Some help from your friends" exe_name)
              (sprintf "%s [OPTIONS] [FILES ..." exe_name)
              (sprintf "%s [-h|--help]: show this text and exits" exe_name)
              (sprintf "%s -v|--version: show the version informations then exits" exe_name) ]

        print_lines lines exit_code

    let version () =
        let lines =
            [ (sprintf "%s version %s" exe_name exe_version) ]

        print_lines lines 0

    let on_file fileName =
        use stream =
            File.Open(fileName, FileMode.Open, FileAccess.Read)

        use reader = new BinaryReader(stream)

        let bufferSize = 16
        let mutable address = 0
        let mutable buffer: byte array = Array.zeroCreate bufferSize
        let to_hex (b: byte) : string = sprintf "%02x" (int b)

        let to_good_ascii (b: byte) : string =
            string (
                if b < (byte 32) then '.'
                else if b > (byte 126) then '.'
                else Convert.ToChar(b)
            )

        let add_str1 s1 s2 = sprintf "%s %s" s1 s2
        let add_str2 s1 s2 = sprintf "%s%s" s1 s2

        while reader.Read(buffer, 0, bufferSize) <> 0 do
            let hex =
                buffer
                |> Array.toList
                |> List.map to_hex
                |> List.fold add_str1 ""

            let asc =
                buffer
                |> Array.toList
                |> List.map to_good_ascii
                |> List.fold add_str2 ""

            printfn "%08x %s '%s'" address hex asc
            address <- address + bufferSize

    let rec all_files =
        function
        | [] -> 0
        | f :: rest ->
            on_file f
            all_files rest

    let has_argument name short_name args =
        args
        |> Array.exists
            (fun x ->
                x = ("--" + name)
                || x = ("/" + name)
                || x = sprintf "-%s" short_name)

    let strip_argument name short_name args =
        args
        |> Array.filter
            (fun x ->
                x <> ("--" + name)
                && x <> ("/" + name)
                && x <> sprintf "-%s" short_name)


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

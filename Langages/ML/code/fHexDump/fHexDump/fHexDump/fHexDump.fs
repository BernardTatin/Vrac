(*
    fHexDump.fs

    bernard.tatin@outlook.fr
    2021-10-10

    Hexdump written in F#
 *)

namespace fHexDump

module main =
    open System

    let exe_name = "fHexDump"
    let exe_version = "0.1.0"
    // Define a function to construct a message to print
    let help exit_code =
        printf "%s - Some help from your friends\n" exe_name
        printf "%s [OPTIONS] [FILES ...\n" exe_name
        printf "%s [-h|--help]: show this text and exits\n" exe_name
        printf "%s -v|--version: show the version informations then exits\n" exe_name
        exit_code

    let version () =
        printf "%s - version %s\n" exe_name exe_version
        0

    let has_argument name short_name args =
        args |> Array.exists (fun x -> x = ("--" + name) || x = ("/" + name) || x = sprintf "-%s" short_name)
    let strip_argument name short_name args =
        args |> Array.filter (fun x -> x <> ("--" + name) && x <> ("/" + name) && x <> sprintf "-%s" short_name)

    [<EntryPoint>]
    let main argv =
        if (has_argument "help" "h" argv) then
            help 0
        if (has_argument "version" "v" argv) then
            version ()
        else
            let doit () = help 1
            doit ()

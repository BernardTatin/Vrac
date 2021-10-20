(*
    fHexDump.fs

    bernard.tatin@outlook.fr
    2021-10-10

    Hexdump written in F#
 *)

namespace integer_games

module main =

    open System
    open Libraries.LibTool
    open Libraries.LibInt

    let help exit_code =
        let lines = [ "integer-games command [OPTIONS] [PARAMETERS]";
                      "command = ";
                      "    help : show this text and exit";
                      "    version : show version and exit";
                      "    fact n1 [n2 [n3 ... ]] : compute factorial of each parameters";
                       ]
        print_lines lines exit_code



    [<EntryPoint>]
    let main argv =
        if argv.Length = 0 then help 0
        else (printfn "%d! = %d" 10 (factorial 10);
                0) // return an integer exit code

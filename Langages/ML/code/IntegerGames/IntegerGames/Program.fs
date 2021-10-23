(*
    Program.fs

    bernard.tatin@outlook.fr
    2021-10-10

    Integer Games
    the real aim is to find some method to control number inputs
    and operation overflow
 *)

namespace integer_games

module main =
    open Libraries.LibTool
    open Libraries.LibInt

    let help exit_code =
        let lines = [ "IntegerGames command [OPTIONS] [PARAMETERS]";
                      "command = ";
                      "    help : show this text and exit";
                      "    version : show version and exit";
                      "    fact n1 [n2 [n3 ... ]] : compute factorial of each parameters";
                      "    fibo n1 [n2 [n3 ... ]] : compute Fibonacci number of each parameters";
                       ]
        print_lines lines exit_code

    let version() =
        let lines = ["IntegerGames version 0.1.0"]
        print_lines lines 0

    let show_1_result arg format f =
        let n = arg  |> str2int
        printfn format n (f n)

    let fact arg =
        show_1_result arg "%d! = %d" factorial

    let fibo arg =
        show_1_result arg "fibo %d = %d" fibonacchi

    let all_values f = function
        | [] -> help 1
        | args -> (foreach f args
                   0)

    let do_command = function
        | [] -> help 0
        | "help" :: _ -> help 0
        | "version" :: _ -> version()
        | "fact" :: tl -> all_values fact tl
        | "fibo" :: tl -> all_values fibo tl
        | _ -> help 1

    [<EntryPoint>]
    let main argv =
        do_command (Array.toList argv)

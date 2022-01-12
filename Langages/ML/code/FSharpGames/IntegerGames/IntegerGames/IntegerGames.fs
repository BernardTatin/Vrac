(*
    IntegerGames.fs

    2021-10-10

    Integer Games
    the real aim is to find some method to control number inputs
    and operation overflow

    try (with Zsh):
        ./IntegerGames.exe fact $(for i in {1..100}; echo $i)
        ./IntegerGames.exe fibo $(for i in {1..100}; echo $i)

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

namespace IntegerGames

module main =
    open Libraries.LibTools
    open Libraries.LibInt
    open Libraries.LibArithmetics

    let help exit_code =
        let lines =
            [ "IntegerGames command [OPTIONS] [PARAMETERS]"
              "command = "
              "    help : show this text and exit"
              "    version : show version and exit"
              "    fact n1 [n2 [n3 ... ]] : compute factorial of each parameters"
              "    fibo n1 [n2 [n3 ... ]] : compute Fibonacci number of each parameters" ]

        print_lines lines exit_code

    let version () =
        let lines = [ "IntegerGames version 0.2.0" ]
        print_lines lines 0

    let show_1_result arg format f =
        let n = arg |> str2int64
        printfn format n (f n)

    let fact arg = show_1_result arg "%d! = %d" factorial

    let fibo arg =
        show_1_result arg "fibo %d = %d" fibonacchi

    let all_values f =
        function
        | [] -> help 1
        | args ->
            foreach f args
            0

    let do_command =
        function
        | [] -> help 0
        | "help" :: _ -> help 0
        | "version" :: _ -> version ()
        | "fact" :: tl -> all_values fact tl
        | "fibo" :: tl -> all_values fibo tl
        | _ -> help 1

    [<EntryPoint>]
    let main argv = do_command (Array.toList argv)

(*
    libtools.fs
    A general purpose library
    Some code exist certainly in F# language/libraries,
    I know it, it's for learning

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

(* global namespace *)
namespace Libraries

(* the module name *)
module LibTools =
    // foreach as in Scheme:
    //      foreach f list
    //          f : function 'a -> unit to apply on each element of the list
    //          list : 'a list, the list
    // F# has List.iter
    let rec foreach f =
        function
        | [] -> ()
        | hd :: tl ->
            f hd
            foreach f tl

    let print_lines (lines: string list) (exit_code: int) =
        let iPrintFn str = printfn $"{str}"
        List.iter iPrintFn lines
        exit_code

    let on_error message =
        match message with
        | "" -> eprintfn "FATAL ERROR!!"
        | str -> eprintfn $"ERROR {message}!!"

        exit 1

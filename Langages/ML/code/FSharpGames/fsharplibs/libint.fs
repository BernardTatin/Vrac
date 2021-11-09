(*
    libint.fs
    Pure integer

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

ames
*)

(* global namespace *)
namespace Libraries


(* the module name *)
module LibInt =
    open System
    open Libraries.LibTools

    let safe_add x y =
        let bad = (x > (Int32.MaxValue - y))
        if bad then
            on_error (sprintf $"overflow on {x} + {y}")
            0
        else
            x + y

    let safe_mul x y =
        let bad = (x > (Int32.MaxValue / y))
        if bad then
            on_error (sprintf $"overflow on {x} * {y}")
            0
        else
            x * y

    let factorial n =
        let rec inner_fact acc = function
                | 0 | 1 -> acc
                | k -> inner_fact (safe_mul k acc) (k - 1)
        inner_fact 1 n

    let fibonacchi n =
        let rec inner_fibo = function
            | 0, a, _ -> a
            | 1, _, b -> b
            | k, a, b -> inner_fibo ((k - 1), b, (safe_add a b))
        inner_fibo (n, 0, 1)

    let str2int (str: string) =
        let mutable result = 0
        if Int32.TryParse(str, &result) then
            result
        else
            on_error (sprintf "Unable to transform '%s' as an integer" str) |> ignore
            0

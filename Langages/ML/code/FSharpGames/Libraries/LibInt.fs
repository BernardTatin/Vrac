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

    let safe_add (x: int64) (y: int64) : int64 =
        let bad = (x > (Int64.MaxValue - y))

        if bad then
            on_error $"overflow on {x} + {y}"
            0L
        else
            x + y

    let safe_mul (x: int64) (y: int64) : int64 =
        let bad = (x > (Int64.MaxValue / y))

        if bad then
            on_error $"overflow on {x} * {y}"
            0L
        else
            x * y

    let str2int (str: string) =
        let mutable result = 0

        if Int32.TryParse(str, &result) then
            result
        else
            on_error $"Unable to transform '{str}' as an integer"
            |> ignore

            0

    let str2int64 (str: string) =
        let mutable result: int64 = int64 0

        if Int64.TryParse(str, &result) then
            result
        else
            on_error $"Unable to transform '{str}' as an 64 bits integer"
            |> ignore

            int64 0

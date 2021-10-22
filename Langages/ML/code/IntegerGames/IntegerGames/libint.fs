(*
    libint.fs
    Pure integer games
*)

(* global namespace *)
namespace Libraries

(* the module name *)
module LibInt =
    open System
    open Libraries.LibTool

    let factorial n =
        let rec inner_fact acc = function
                | 0 | 1 -> acc
                | k -> inner_fact (k * acc ) (k - 1)
        inner_fact 1 n

    let fibonacchi n =
        let rec inner_fibo = function
            | (0, a, _) -> a
            | (1, _, b) -> b
            | (k, a, b) -> inner_fibo ((k - 1), b, (a + b))
        inner_fibo (n, 0, 1)

    let str2int (str: string) =
        let mutable result = 0
        if Int32.TryParse(str, &result) then
            let rr = result
            rr
        else
            on_error (sprintf "Unable to transform '%s' as an integer" str) |> ignore
            0

(*
    libint.fs
    Pure integer games
*)

(* global namespace *)
namespace Libraries

(* the module name *)
module LibInt =
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

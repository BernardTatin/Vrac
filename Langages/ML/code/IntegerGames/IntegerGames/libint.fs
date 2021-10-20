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

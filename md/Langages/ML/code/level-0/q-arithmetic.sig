(*
 * q-arithmetic.sig
 *
 * Notethis code give a simple arithmetic of the Q set,
 * there is no optimization, overflow detection, divide by 0 detection...
 * the aim of this code is to learn more about types and structures
 *
 * perhaps this code will be better in a mathematical meaning
 *)

signature Q_ARITHMETIC =
    sig
        val q_normalize : int * int -> int * int
        val q_add : int * int -> int * int -> int * int
        val q_mul : int * int -> int * int -> int * int
        val q_sub : int * int -> int * int -> int * int
        val q_div : int * int -> int * int -> int * int
        val q_compare : (int * int) -> (int * int) -> order
    end;
(*
 * integer-computing.sig
 * computations on integers
 *
 * an example how to use structures
 *)

signature INTEGER_COMPUTING = sig
    val fact : int -> int   (* compute the factorial of an integer *)
    val fibo : int -> int   (* compute the nth Fibonacci number *)
    val gcd : int -> int -> int     (* compute the gcd of two integers *)
end;

signature TEST_INTEGER_COMPUTING = sig
    val test : string -> (int -> int) -> int -> unit  (* for testing the above 1 parameter funtions *)
    val test2 : string -> (int -> int -> int) -> int -> unit  (* for testing the above 2 parameter funtions *)
end;

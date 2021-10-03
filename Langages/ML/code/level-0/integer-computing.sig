(*
 * integer-computing.sig
 * computations on integers 
 *
 * an example how to use structures
 *)

signature INTEGER_COMPUTING = sig
    val fact : int -> int   (* compute the factorial of an integer *)
    val fibo : int -> int   (* compute the nth Fibonacci number *)
end;

signature TEST_INTEGER_COMPUTING = sig
    val test : (int -> int) -> int -> unit  (* for testing the above funtions *)
end;
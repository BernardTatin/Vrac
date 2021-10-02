(*
 * integer-computing.sig
 * computations on integers 
 *)

signature INTEGER_COMPUTING = sig
    val fact : int -> int
    val fibo : int -> int
end;

signature TEST_INTEGER_COMPUTING = sig
    val test : (int -> int) -> int -> unit
end;
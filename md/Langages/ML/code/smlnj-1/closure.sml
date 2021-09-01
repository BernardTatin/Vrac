(*
 * closure.sml
 * show how to define closure
 *)

(* 
 * first simple closure, works only with ints
 * signature is:
 * val closure0 : int -> int -> int
 *)
fun closure0 x =
    let
      val xx = x * x
    in
      fn(y) => xx + y*y
    end;

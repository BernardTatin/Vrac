(*
 * closure.sml
 * show how to define closure
 *)

(* 
 * first simple closure, works only with ints
 * signature is:
 * val closure0 : int -> int -> int
 *)
 structure Closure0: CLOSURE = struct
  fun closure0 x =
      let
        val xx = x * x
      in
        fn(y) => xx + y*y
      end;
  fun testme() =
    let 
      fun inner_test message klos y =
        print (message ^ " " ^ Int.toString y ^ " " ^ Int.toString (klos y) ^ "\n")
      val kl0 = closure0 0
      val kl1 = closure0 1
    in
      (
        inner_test "kl0" kl0 0;
        inner_test "kl0" kl0 1;
        inner_test "kl0" kl0 2;

        inner_test "kl1" kl1 0;
        inner_test "kl1" kl1 1;
        inner_test "kl1" kl1 2
      )
    end;
end;

Closure0.testme();

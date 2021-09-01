(*
 * fact.sml
 * show haow to define tail recursive functions
 *)

(*
 * simple recursive form
 *)
 fun fact0 n =
    if n=0 then 1
           else n * fact0 (n - 1);

(*
 * same as above using pattern matching
 *)
fun fact1 0 = 1
   | fact1 n = n * fact1 (n - 1);

(*
 * same as above with tail recursive helper function
 *)
fun fact2 0 = 1
   | fact2 n = 
      let
        fun innerfact 0 acc = acc
            | innerfact n acc = innerfact (n - 1) (n * acc)
      in
        innerfact n 1
      end;

 
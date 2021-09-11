(*
 * q-test.sml
 * some tests for q-arithmetic.sml
 *)

 (*
  * do_test
  *)

fun do_test ftest fexpected 0 = print "\nEnd olf Test\n"
    | do_test ftest fexpected n =
        let
            val (ta, tb) = ftest n 
            val (ea, eb) = fexpected n 
            val is_good = if q_.q_compare(ta, tb) (ea, eb) <> EQUAL 
                then print ("\nERROR at value " ^ Int.toString n ^ "\n")
                else print "."
        in
            do_test ftest fexpected (n - 1)
        end;

fun test1 n =
    let
      fun ftest k =
        q_.q_add (1, k) (1, k + 1);
      fun fexpected k =
        q_.q_normalize (2*k + 1, k * (k+1))  
    in
      do_test ftest fexpected n
    end;
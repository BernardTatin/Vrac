(*
 * q-test.sml
 * some tests for q-arithmetic.sml
 *)

use "q-arithmetic.sig";
use "q-arithmetic.sml";
use "q-test.sig";


structure t1: Q_TEST =
struct
    val name = "Simple addition test";
    fun ftest k =
        q_.q_add (1, k) (1, k + 1);
    fun fexpected k =
        q_.q_normalize (2*k + 1, k * (k+1));
    fun begin_test loops =
        print (name ^ ", " ^ Int.toString loops ^ " loops\n");
    fun end_test errors loops =
        print ("\nEnd of test '" ^ name ^ "': errors/loops " ^ Int.toString errors ^ "/" ^ Int.toString loops ^ "\n\n");
    fun exec_test loops =
        let
          val _ = begin_test loops
          fun inner_exec errors 0 = end_test errors loops
          | inner_exec errors iloops =
            let
                val (ta, tb) = ftest iloops 
                val (ea, eb) = fexpected iloops 
                val _ = print "."
            in
                if q_.q_compare(ta, tb) (ea, eb) <> EQUAL 
                    then inner_exec (errors + 1) (iloops - 1)
                    else inner_exec errors (iloops - 1)
            end;

        in
                inner_exec 0 loops
        end
end;


structure t2: Q_TEST =
struct
    val name = "Simple substraction test";
    fun ftest k =
        q_.q_sub (1, k) (1, k + 1);
    fun fexpected k =
        q_.q_normalize (1, k * (k+1));
    fun begin_test loops =
        print (name ^ ", " ^ Int.toString loops ^ " loops\n");
    fun end_test errors loops =
        print ("\nEnd of test '" ^ name ^ "': errors/loops " ^ Int.toString errors ^ "/" ^ Int.toString loops ^ "\n\n");
    fun exec_test loops =
        let
          val _ = begin_test loops
          fun inner_exec errors 0 = end_test errors loops
          | inner_exec errors iloops =
            let
                val (ta, tb) = ftest iloops 
                val (ea, eb) = fexpected iloops 
                val _ = print "."
            in
                if q_.q_compare(ta, tb) (ea, eb) <> EQUAL 
                    then inner_exec (errors + 1) (iloops - 1)
                    else inner_exec errors (iloops - 1)
            end;

        in
            inner_exec 0 loops
        end
end;



t1.exec_test 12;
t2.exec_test 6;
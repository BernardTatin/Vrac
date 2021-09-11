(*
 * q-test.sig
 * some tests for q-arithmetic.sml
 *)

signature Q_TEST =
    sig
        (* test name, a simple value *)
        val name : string
        (* test function *)
        val ftest : int -> int * int
        (* expected value computed *)
        val fexpected : int -> int * int
        (* begin the test *)
        val begin_test : int -> unit 
        (* test execution *)
        val exec_test : int -> unit
        (* end of the test *)
        val end_test : int -> int -> unit
    end;

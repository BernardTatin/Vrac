(*
 * integer-computing.sml
 * computations on integers 
 *
 * an example how to use structures
 *)

(* naive recursive algorithms *)
structure SimpleIntCompute : INTEGER_COMPUTING = struct
    fun fact 0 = 1
        | fact 1 = 1
        | fact n =
            n * (fact (n - 1));

    fun fibo 0 = 0
        | fibo 1 = 1
        | fibo n =
            (fibo (n - 1)) + (fibo (n - 2));
end;

(* tail recursive algorithms *)
structure IntCompute : INTEGER_COMPUTING = struct
    fun fact 0 = 1
        | fact 1 = 1
        | fact n =
            let
                fun innerf 0 acc = acc
                    | innerf k acc = innerf (k - 1) (k * acc)
            
            in
              innerf n 1
            end

    fun fibo n =
        let
            fun inner_f 0 a _ = a 
                | inner_f 1 _ b = b 
                | inner_f k a b = inner_f (k - 1) b (a + b)
        in 
            inner_f n 0 1
        end
end;

structure TestIntegerComputing : TEST_INTEGER_COMPUTING = struct
    (* stupis test *)
    fun test f_name f loops =
        let
            fun show_test k =
                print (f_name ^ Int.toString k ^ " -> " ^ Int.toString (f k) ^ "\n")

            fun iloop 0 = show_test 0
                | iloop k =
                    ( show_test k;
                      iloop (k - 1))

        in
            iloop loops
        end
end;

TestIntegerComputing.test "tail rec fibo " IntCompute.fibo 32;
TestIntegerComputing.test "     rec fibo " SimpleIntCompute.fibo 32;

TestIntegerComputing.test "tail rec fact " IntCompute.fact 12;
TestIntegerComputing.test "     rec fact " SimpleIntCompute.fact 12;

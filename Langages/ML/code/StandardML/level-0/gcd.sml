(*
 * gcd.sml
 * show haow to define functions
 *)

(*
 * simple tail recursive form
 *)
 fun gcd0(m, n) =
    if m=0 then n
           else gcd0(n mod m, m);

(*
 * same as above using pattern matching
 *)
fun gcd1(0, n) = n
   | gcd1(m, n) = gcd1(n mod m, m);

(*
 * same as above less '(' and ')'
 *)
fun gcd2 0 n = n
   | gcd2 m n = gcd2 (n mod m) m;

(*
 * same as above but with lambda
 * here, recursion does not work, 
 * compilation return an error:
 *    Error: unbound variable or constructor: gcd4
 *)

(*
 val gcd20 = fn(0, n) => n
   | (m, n) => gcd20(n mod m, m);
 *)

(*
 * so we cheat a little to get a working exemple
 *)

 val gcd3 = fn(m, n) => gcd2 m n;

 val gcd4 = fn(0, n) => n
   | (m, n) => gcd2 (n mod m) m;
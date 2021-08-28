(*
 * gcd.sml
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
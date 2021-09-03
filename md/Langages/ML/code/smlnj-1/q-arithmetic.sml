(*
 * q-arithmetic.sml
 *)

(*
 * a q-element is a tuple of two integers
 * (qa, qb) wich represents a value of Q: qa/qb
 *)

(*
 * we need the gcd of two integers
 *)
fun gcd 0 n = n
   | gcd m n = gcd (n mod m) m;


(*
 * normalize
 *)
fun q_normalize(qa, qb) =
  (* normalize the sign when qb < 0 *)
    let
      fun normalize_sign(qa, qb) =
        if qb < 0 then (~qa, ~qb)
                  else (qa, qb);
  (* simplify, i.e divide qa and qb by their gcd *)
      fun normalize_simplfy(qa, qb) =
        let
          val g = gcd qa qb;
          val new_q = if g = 1 then (qa, qb)
                               else (qa div g, qb div g);
        in
          new_q
        end;
    in
      if qa = 0 then (0, 1)
                else normalize_sign (normalize_simplfy(qa, qb))
    end;

(*
 * basic operations
 *)
fun q_add  (qa, qb) (pa, pb) =
  q_normalize(qa*pb + pa*qb, qb*pb);

fun q_mul (qa, qb) (pa, pb) =
  q_normalize(qa*pa, qb*pb);


fun q_sub  (qa, qb) (pa, pb) =
  q_normalize(qa*pb - pa*qb, qb*pb);

fun q_div (qa, qb) (pa, pb) =
  q_normalize(qa*pb, qb*pa);



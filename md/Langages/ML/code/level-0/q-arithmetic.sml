(*
 * q-arithmetic.sml
 *
 * Notethis code give a simple arithmetic of the Q set,
 * there is no optimization, overflow detection, divide by 0 detection...
 * the aim of this code is to learn more about types and structures
 *
 * perhaps this code will be better in a mathematical meaning
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
      (*
      * we need the gcd of two integers
      *)
      fun gcd 0 n = n
        | gcd m n = gcd (n mod m) m;

      (*
       * normalize the sign
       *)
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

(*
 * comparison
 * problem: q_compare and q_sub are dependant, so testing one...
 *)
fun q_compare(qa, qb) (pa, pb) =
  let
    val (da, db) = q_sub (qa, qb) (pa, pb)
  in
    if da = 0 then EQUAL
        else if da < 0 then LESS
        else GREATER
  end;

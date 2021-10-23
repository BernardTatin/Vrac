(*
 * types.sml
 * show how to define types
 *)

datatype num = I of int
             | R of real

fun sq (x : num) : num =
    case x of I k => (I (k * k))
            | R y => (R (y * y));

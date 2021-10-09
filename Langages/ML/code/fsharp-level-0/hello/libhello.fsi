(*
    libhello.fsi
    a (very) small library to try multi file project
*)

(* we NEED a namespace *)
namespace Hello

(* we NEED a module *)
module LibHello =
    val from : string -> string
    val show_from : string -> unit
    val big_from : string list -> unit

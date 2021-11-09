(*
    libhello.fsi
    a (very) small library to try multi file project
*)

(* we NEED a namespace *)
namespace Libraries

(* we NEED a module *)
module LibHello =
    // construct a message for somebody
    val from : string -> string
    // print a message constructed with from
    val show_from : string -> unit
    // print a list formatted with show_from
    val big_from : string list -> unit

(*
    libhello.fs
    a (very) small library to try multi file project
*)

(* we NEED a namespace *)
namespace Hello

(* we NEED a module *)
module LibHello =
    open System

    // Define a function to construct a message to print
    let from whom =
        sprintf "from %s!!!" whom
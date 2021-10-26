(*
    libtools.fsi
    A general purpose library
*)

(* global namespace *)
namespace Libraries

(* the module name *)
module LibTool =
    // foreach as in Scheme:
    //      foreach f list
    //          f : function 'a -> unit to apply on each element of the list
    //          list : 'a list, the list
    val foreach : ('a -> unit) -> 'a list -> unit

    val print_lines : string list -> int -> int

    val on_error : string -> 'a

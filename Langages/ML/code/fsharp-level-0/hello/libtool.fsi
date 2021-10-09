(*
    libtools.fsi
    hello world, in two (2) or more files
*)

(* global namespace *)
namespace Hello
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

(* the module name *)
module LibTool =
    // foreach as in Scheme:
    //      foreach f list
    //          f : function 'a -> unit to apply on each element of the list
    //          list : 'a list, the list
    val foreach : ('a -> unit) -> 'a list -> unit

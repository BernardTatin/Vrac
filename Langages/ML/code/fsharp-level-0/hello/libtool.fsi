(*
    libtools.fsi
    hello world, in two (2) or more files
*)

(* we NEED a namespace *)
namespace Hello
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

(* we NEED a module *)
module LibTool =
    val foreach : ('a -> unit) -> 'a list -> unit

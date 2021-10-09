(*
    libtools.fs
    hello world, in two (2) or more files
*)

(* we NEED a namespace *)
namespace Hello
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

(* we NEED a module *)
module LibTool =
    let rec foreach f = function
        | []        -> ()
        | hd :: tl  -> f hd;
                       foreach f tl

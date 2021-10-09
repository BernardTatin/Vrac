(*
    libhello.fs
    a (very) small library to try multi file project
*)

(* we NEED a namespace *)
namespace Hello

(* we NEED a module *)
module LibHello =
    open System
    open LibTool

    // Define a function to construct a message to print
    let from whom =
        sprintf "from %s!!!" whom

    let show_from whom =
        printfn "Hello world %s" (from whom)

    let rec big_from_0 = function
        | []        -> ()
        | hd :: tl  -> show_from hd;
                        big_from_0 tl

    let big_from l =
        foreach show_from l

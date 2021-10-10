(*
    libhello.fs
    a (very) small library to try multi file project
*)

(* global namespace *)
namespace Hello

(* the module name *)
module LibHello =
    open LibTool

    // cf. libhello.fsi
    let from whom =
        sprintf "from %s!!!" whom

    let show_from whom =
        printfn "Hello world %s" (from whom)

    let big_from l =
        foreach show_from l

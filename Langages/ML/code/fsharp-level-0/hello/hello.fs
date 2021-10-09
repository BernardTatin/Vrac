(*
    hello.fs
    hello world, in two (2) files
*)

(* we NEED a namespace *)
namespace Hello
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

(* we NEED a module *)
module Main =
    open System
    // how to use an external module
    open LibHello

    [<EntryPoint>]
    let main argv =
        let fs = "F#" // Call the function
        let me = "Me"

        // not the best list construction
        // if we don't _open_ LibHello, we must prefix big_from
        // with LibHello.
        big_from (fs :: (me :: []))
        // command line parameters
        big_from (argv |> Array.toList)

        0 // return an integer exit code

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
        let message = from "F#" // Call the function
        let me = "Me"
        printfn "Hello world %s and %s" message (from me)
        0 // return an integer exit code
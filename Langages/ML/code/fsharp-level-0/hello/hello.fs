namespace Hello
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

module Main =
    open System
    open LibHello

    // Define a function to construct a message to print
    (* let from whom =
        sprintf "from %s!!" whom *)

    [<EntryPoint>]
    let main argv =
        let message = from "F#" // Call the function
        let me = "Me"
        printfn "Hello world %s and %s" message (from me)
        0 // return an integer exit code
// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

let factorial n =
    let rec inner_fact acc k =
        match k with
            | 0 | 1 -> acc
            | k -> inner_fact (k * acc ) (k - 1)
    inner_fact 1 n

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    printfn "%d! = %d" 10 (factorial 10)
    0 // return an integer exit code

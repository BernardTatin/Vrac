(*
    libtools.fs
    A general purpose library
    Some code exist certainly in F# language/libraries,
    I know it, it's for learning
*)

(* global namespace *)
namespace Libraries

(* the module name *)
module LibTools =
    // foreach as in Scheme:
    //      foreach f list
    //          f : function 'a -> unit to apply on each element of the list
    //          list : 'a list, the list
    // F# has List.iter
    let rec foreach f = function
        | []          -> ()
        | hd :: tl    -> f hd;
                         foreach f tl

    let print_lines (lines: string list) (exit_code: int) =
        let iprintfn str =
            printfn $"{str}"
        List.iter iprintfn lines
        exit_code

    let on_error message =
        match message with
            | "" -> eprintfn "FATAL ERROR!!"
            | str -> eprintfn $"ERROR {message}!!"
        exit 1

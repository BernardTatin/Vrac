(*
    libtools.fs
    A general purpose library
*)

(* global namespace *)
namespace Libraries

(* the module name *)
module LibTool =
    // foreach as in Scheme: see libtools.fsi
    let rec foreach f = function
        | []          -> ()
        | hd :: tl    -> f hd;
                         foreach f tl

    let print_lines lines (exit_code: int) =
        let iprintfn str =
            printfn "%s" str
        (foreach iprintfn lines;
         exit_code)

    let on_error message =
        match (message) with
            | "" -> eprintfn "FATAL ERROR!!"
            | str -> eprintfn "ERROR %s!!" message
        exit 1

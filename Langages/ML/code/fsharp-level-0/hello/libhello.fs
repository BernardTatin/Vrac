namespace Hello

module LibHello =
    open System

    // Define a function to construct a message to print
    let from whom =
        sprintf "from %s!!" whom
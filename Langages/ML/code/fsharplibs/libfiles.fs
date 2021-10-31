(*
    libfiles.fs

    bernard.tatin@outlook.fr
    2021-10-14

    Tools to process files
 *)

namespace Libraries

module LibFiles =
    open System.IO
    open Libraries.LibTools
    let binary_file_reader fileName  on_rcv_buffer buffer_size =
        // the buffer: a byte array of 'bufferSize' length
        let mutable buffer: byte array = Array.zeroCreate buffer_size
        // NOTE: use is like let with the release of the resource at
        //       the end of the block, here the file is closed
        // open the file
        // TODO: needs a better management of errors when opening a file
        let stream =
            try
                Some(File.Open(fileName, FileMode.Open, FileAccess.Read))
            with
                | :? FileNotFoundException ->
                    on_error (sprintf $"Cannot open file '{fileName}") 1
                | ex ->
                    on_error (sprintf $"FATAL {ex.Message} '{fileName}") 1

        // create a binary reader
        use reader = new BinaryReader(stream.Value)


        // the main loop to read and print
        let rec read_loop address =
            // read the buffer
            let read_count = reader.Read(buffer, 0, buffer_size)
            // Lisp always in my mind: buffer transformed in list
            let lst_buffer =
                buffer |> Array.take read_count |> Array.toList

            // call the callback function
            on_rcv_buffer address lst_buffer
            // if not end of file, loop
            if read_count = buffer_size then
                read_loop (address + buffer_size)
            else
                0
        // do it, baby!
        read_loop 0 |> ignore
        stream.Value.Close()
        0

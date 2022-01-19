(*
    libfiles.fs

    2021-10-14

    Tools to process files

    The MIT License (MIT)

    Copyright (c) 2021 Bernard TATIN

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.

 *)

namespace Libraries

open System

module LibFiles =
    open System.IO
    open Libraries.LibTools

    let binary_file_reader fileName on_rcv_buffer buffer_size is_stdin =
        // the buffer: a byte array of 'bufferSize' length
        let mutable buffer: byte array = Array.zeroCreate buffer_size

        let getReader () =
            if not is_stdin then
                // DONE: needs a better management of errors when opening a file
                let some_stream =
                    try
                        Some(File.Open(fileName, FileMode.Open, FileAccess.Read))
                    with
                    | :? FileNotFoundException -> on_error $"Cannot open file '{fileName}'" 1
                    | ex -> on_error $"FATAL {ex.Message} '{fileName}" 1
                // NOTE: use is like let with the release of the resource at
                //       the end of the block, here the file is closed
                // open the file
                let stream = some_stream.Value
                new BinaryReader(stream)
            else
                let stream = Console.OpenStandardInput()
                new BinaryReader(stream)

        use reader = getReader ()

        // the main loop to read and print
        let rec read_loop address =
            // read the buffer
            let read_count = reader.Read(buffer, 0, buffer_size)

            if read_count = 0 then
                0
            else
                // Lisp always in my mind: buffer transformed in list
                let lst_buffer =
                    buffer |> Array.take read_count |> Array.toList

                // call the callback function
                on_rcv_buffer address lst_buffer
                // if not end of file, loop
                if read_count = buffer_size then
                    read_loop (address + buffer_size)
                else
                    address + read_count
        // do it, baby!
        read_loop 0

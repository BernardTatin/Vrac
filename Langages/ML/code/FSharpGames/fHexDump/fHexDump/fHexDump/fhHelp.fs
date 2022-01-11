(*
    fHexDump.fs

    2021-10-10

    Hexdump written in F#

    try: (Zsh)
    diff -y --suppress-common-lines  <(hexdump -vC ~/nohup.out | tr -s ' ') <(fHexDump -w 16 ~/nohup.out  | tr -s ' ')

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

namespace fHexDump

module Help =
    open Libraries.LibTools
    open fHexDump.Version

    let internal helpLines =
        [ $"{exe_name}:              A little help from your friends"
          $"{exe_name} [-h|--help]:  the little help from your friends"
          $"{exe_name} -v|--version: show the version information then exits"
          $"{exe_name} [OPTIONS] [FILES ..."
          "OPTIONS:"
          "     -b|--binary: print in binary"
          "     -x|--hexa:   print in hexadecimal (default)"
          "     -w|--width:  integer: number of bytes on each lines (default: 16)" ]

    // Show the help message
    let help exit_code = print_lines helpLines exit_code

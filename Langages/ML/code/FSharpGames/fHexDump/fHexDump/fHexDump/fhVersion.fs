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

module Version =
    open Libraries.LibTools

    // not in the command line parameters
    let exe_name = "fHexDump"
    let exe_version = "0.3.2"

    let internal versionLines = [ $"{exe_name} version {exe_version}" ]

    // Show the version
    let rec version () =
        print_lines versionLines 0
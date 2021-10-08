(*
 * counters.sig
 * Copyright (C) 2018 bernard <bernard@bernard-LIFEBOOK-E782>
 *
 * Distributed under terms of the MIT license.
 *
 * Manage counters defined as closures
 *
 *)

signature COUNTERS =
sig
   val makeCounter : int -> (unit -> int)
   val makeCounterWithAction : int * (unit -> unit) -> (unit -> int)
   val makeTimer : int * int * (unit -> unit) -> (unit -> unit)
 end;

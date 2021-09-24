# les fonctions

Le code:

- [`gcd.sml`](smlnj-1/gcd.sml) et [`gcd.sig`](smlnj-1/gcd.sig), pour les bases de la définition des fonctions,
- [`fact.sml`](smlnj-1/fact.sml) pour les fonctions imbriquées.

## définir une fonction

Pour définir une fonction avec des paramètres, il y a deux méthodes. Soit les paramètres sont placés dans un _tuple_:

```ocaml
 fun gcd0(m, n) =
    if m=0 then n
           else gcd0(n mod m, m);
```

et la signature de la fonction est alors:

```ocaml
val gcd0 :  int * int -> int
```

Soit les paramètres sont listés un à un:

```ocaml
fun gcd2 0 n = n
   | gcd2 m n = gcd2 (n mod m) m;
```

et la signature de la fonction est alors:

```ocaml
val gcd2 :  int -> int -> int
```

## le _pattern-matching_

Voici un exemple avec la factorielle:

```ocaml
fun fact1 0 = 1
   | fact1 n = n * fact1 (n - 1);
```

## imbrication de fonctions

Ce peut-être très utile pour rendre une fonction récursive en _tail call recursive_. Par exemple avec la factorielle:

```ocaml
fun fact2 0 = 1
   | fact2 n = 
      let
        fun innerfact 0 acc = acc
            | innerfact n acc = 
            	innerfact (n - 1) (n * acc)
      in
        innerfact n 1
      end;
```

***ATTENTION***: entre le `let` et le `end`, il n'y a pas de point virgule en fin d'instruction (ce qui est déroutant), par contre, il est nécessaire après le `end`.


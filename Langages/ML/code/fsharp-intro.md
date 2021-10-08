# `F#`: introduction

`F#` est, d'une certaine manière, la _version Microsoft de `OCaml`_, une version très étendue. On retrouve les même concepts fondamentaux:

- la programmation fonctionnelle,
- la programmation objet,
- la programmation impérative,
- le typage à la _ML_,
- l'inférence de type, toujours à la _ML_,
- tous les concepts auxquels je ne pense pas.

`F#` est né chez _Microdsoft_, d'où la plateforme `.NET`.

## création d'un projet

### la solution simple

```bash
$ mkdir hello
$ cd hello
$ dotnet new console --language F#
$ dotnet run
```

Cette commande crée les fichiers et répertoires suivants:

- `bin/Debug/...`: le répertoire des résultats de compilation dont l'exécutable final en version _Debug_,
- `obj`: répertoires des résidus de compilation,
- `Program.fs`: un source de type _hello world_ à peine amélioré,
- `hello.fsproj`: ***le*** fichier projet utilisable par de nombreux environnements dont _VS Code_.

### la solution ***pro***:

```bash
dotnet new console --name 'BigHello' --output bighello --language F#
cd bihello
dotnet run
```

La commande crée un répertoire `bighello` dans lequel on trouve:

- `bin/Debug/...`: le répertoire des résultats de compilation dont l'exécutable final en version _Debug_,
- `obj`: répertoires des résidus de compilation,
- `Program.fs`: un source de type _hello world_ à peine amélioré,
- `BigHello.fsproj`: ***le*** fichier projet utilisable par de nombreux environnements dont _VS Code_.



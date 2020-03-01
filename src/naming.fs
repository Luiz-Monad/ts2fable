module ts2fable.Naming

open System

let stringContainsAny (a: string) (b: string list) =
    b |> List.exists a.Contains

let replace (pattern:string) (destPattern:string) (text: string) =
    text.Replace(pattern,destPattern)

[<RequireQualifiedAccess>]
module ModuleName =
    let forwordSlash (s:string) =
        s.Replace("\\","/")

    let (|Normal|Parts|) (moduleName: string) =
        let moduleName2 = forwordSlash moduleName
        if moduleName2.Contains "/" then
            let parts = moduleName2.Split('/') |> List.ofSeq
            Parts parts
        else Normal

    let normalize moduleName =
        let moduleName2 = forwordSlash moduleName
        match moduleName2 with
        | Normal -> moduleName2
        | Parts parts -> moduleName2 |> sprintf "./%s"

let (|Capital|_|) (letter: string) =
    if String.IsNullOrWhiteSpace letter then None
    elif Char.IsUpper (letter, 0) then Some letter
    else None

let (|Digit|_|) (digit: string) =
    if String.IsNullOrWhiteSpace digit then None
    elif Char.IsDigit (digit, 0) then Some digit
    else None

let createEnumNameParts (name: string) =
    let tokens = Seq.map string name
    let rec splitParts part parts  =
        function
        | [] -> part :: parts
        | Digit n :: rest when
            // Append N to beginning only if enum starts with digit
            List.isEmpty parts
            && part = "" -> splitParts ("N" + n) parts rest
        | Capital letter :: rest when part = "" -> splitParts letter parts rest
        | Capital letter :: rest -> splitParts letter (part :: parts) rest
        | "-" :: rest -> splitParts "" (part :: parts) rest
        | "." :: rest -> splitParts "_" (part :: parts) rest
        | token :: rest ->  splitParts (part + token) parts rest
    tokens
    |> List.ofSeq
    |> splitParts "" []
    |> List.rev

let capitalize (input: string): string =
    if String.IsNullOrWhiteSpace input then ""
    else sprintf "%c%s" (Char.ToUpper input.[0]) (input.Substring 1)

let lowerFirst (input: string): string =
    if String.IsNullOrWhiteSpace input then ""
    else sprintf "%c%s" (Char.ToLower input.[0]) (input.Substring 1)

let isIdentifier (input: string) =
    if String.IsNullOrWhiteSpace input then false
    else
        let isLetterOrDigitOrUnderscore c = Char.IsLetterOrDigit c || (c = '_')
        Seq.forall isLetterOrDigitOrUnderscore input
            && not (input = "_")
            && not (Char.IsDigit (input, 0))

let asIdentifier (input: string) =
    input |> String.map (fun c -> if Char.IsLetterOrDigit c then c else '_')

let createEnumName (s: string) =
    if String.IsNullOrWhiteSpace s then "Empty"
    else
        // let s = s |> asIdentifier
        let nm = s |> createEnumNameParts |> List.map capitalize |> String.concat ""
        if isIdentifier nm then nm else "``" + nm.Replace("`", "'") + "``"

// by default Fable lowercases the first letter of the name for the value
let nameEqualsDefaultFableValue (name: string) (value: string): bool =
    let defaultFableValue =
        sprintf "%s%s"
            (name.Substring(0,1).ToLower())
            (name.Substring(1))
    defaultFableValue.Equals value

let createModuleNameParts (name: string) =

    let tokens = Seq.map string name
    let rec splitParts part parts  =
        function
        | [] -> part :: parts
        | "-" :: rest -> splitParts "" (part :: parts) rest
        | "/" :: rest -> splitParts "" (part :: parts) rest
        | "." :: rest -> splitParts "" (part :: parts) rest
        | token :: rest ->  splitParts (part + token) parts rest
    tokens
    |> List.ofSeq
    |> splitParts "" []
    |> List.rev

let escapeWord (s: string) =
    if String.IsNullOrEmpty s then ""
    else
        let s = s.Replace("'","") // remove single quotes
        if Keywords.reserved.Contains s
            || Keywords.keywords.Contains s
            || s.IndexOfAny [|'-';'/';'$'|] <> -1 // invalid chars
            || (s.Length > 0 && Char.IsDigit (s, 0))
            || s.Substring(0,1).IndexOfAny [|'.';'['|] <> -1 // starts with
            || s.Equals "_"
        then
            sprintf "``%s``" s
        else
            s

let escapeProperty (s: string) =
    if String.IsNullOrEmpty s then ""
    else
        if Keywords.reserved.Contains s
            || Keywords.keywords.Contains s
            || not (isIdentifier s)
        then
            sprintf "``%s``" s
        else
            s

let fixModuleName (s: string) =
    let s = s.Replace("'","") // remove single quotes
    let s = capitalize s
    let s =
        let parts = s |> createModuleNameParts
        parts |> String.concat "_"
    let s =
        if Keywords.reserved.Contains s || Keywords.keywords.Contains s then
            sprintf "%s_" s
        else s
    s

let removeQuotes (s: string) =
    if String.IsNullOrEmpty s then ""
    else
        let c = s.[0]
        if (c = '\"' || c = ''')
        then s.Trim(c)
        else s

let makePartName (s: string) =
    let parts = s.Trim('`') |> createModuleNameParts
    let name = parts  |> List.map capitalize |> String.concat ""
    name |> asIdentifier

// gets the JavaScript module name
// intended for use by SourceFile.fileName which has slashes normalized
// TODO implement all of https://github.com/ajafff/tsutils/issues/14#issuecomment-345544684
let getJsModuleName (path: string): string =
    let parts =
        path
            |> fun x ->
                let inm = path.LastIndexOf "node_modules"
                if inm = -1 then x
                else x.Substring(inm+13)
            |> fun x ->
                let is = x.LastIndexOf "@"
                if is = -1 then x
                else x.Substring(is)
            |> fun x ->
                x.Split '/'
                    |> List.ofArray
                    |> List.filter (fun s -> s <> "index.d.ts" && s <> "types")

    let out =
        match parts with
            | "@types"::x::xs ->
                let xs' = x.Replace("__", "/") :: xs
                String.Join("/", xs')
            | x::xs when x.StartsWith "@" ->
                String.Join("/", x :: xs)
            // TODO: Shouldn't this be List.last instead?
            | xs -> List.head xs
    out.Replace(".ts","").Replace(".d","")

let primatives = ["string"; "obj"; "unit"; "float"; "bool"] |> Set.ofList

// espects a type where the namespace is simply dot separated
let fixNamespaceString (name: string): string =
    if primatives.Contains name then
        name
    else
        let parts = name.Split [|'.'|]
        if parts.Length = 1 then
            name
        else
            let parts = parts |> List.ofArray |> List.rev
            let parts = [parts.Head] @ parts.Tail |> List.map fixModuleName
            parts |> List.rev |> String.concat "."

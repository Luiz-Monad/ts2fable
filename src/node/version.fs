module ts2fable.node.Version

open Node
open Fable.Core.JsInterop
open Thoth.Json

let inline private ofJson<'T> (a: string) : 'T =
    let decoder = Decode.Auto.generateDecoder<'T>()
    match Decode.fromString decoder a with
    | Ok o -> o
    | Error e -> failwith e

type PackageJson =
    {
        version: string
    }
let version =
    let packageJsonPath = path.join(ResizeArray([__dirname; "../package.json"]))
    if fs.existsSync !^packageJsonPath then
        let packageJson = fs.readFileSync(!^(!^packageJsonPath), !^"utf8") |> ofJson<PackageJson>
        packageJson.version
    else
        "0.0.0"
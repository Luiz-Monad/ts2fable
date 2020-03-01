module ts2fable.node.Version

open Node.Api
open Fable.Core

[<Emit "require($0).version">]
let getVersion (path: string): string = jsNative

let version =
    let packageJsonPath = path.join [| __dirname; "../package.json" |]
    if fs.existsSync (packageJsonPath |> U2.Case1) then
        getVersion packageJsonPath
    else
        "0.0.0"
namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

module ts =
    type [<AllowNullLiteral>] MapLike<'T> =
        abstract [NAME]: [TYPE][OPTION] with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: string -> 'T[OPTION] with get, set

    and [<AllowNullLiteral>] Map<'T> =
        inherit MapLike<'T>
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract ___mapBrand: obj[OPTION] with get, set

    and Path =
        obj

    and [<AllowNullLiteral>] FileMap<'T> =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract get: fileName: Path -> 'T
        abstract set: fileName: Path * value: 'T -> unit
        abstract contains: fileName: Path -> bool
        abstract remove: fileName: Path -> unit
        abstract forEachValue: f: Func<Path, 'T, unit> -> unit
        abstract getKeys: unit -> ResizeArray<Path>
        abstract clear: unit -> unit

    and [<AllowNullLiteral>] TextRange =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract pos: float[OPTION] with get, set
        abstract ``end``: float[OPTION] with get, set

    and SyntaxKind =
        | Unknown = 0
        | EndOfFileToken = 1
        | SingleLineCommentTrivia = 2
        | MultiLineCommentTrivia = 3
        | NewLineTrivia = 4
        | WhitespaceTrivia = 5
        | ShebangTrivia = 6
        | ConflictMarkerTrivia = 7
        | NumericLiteral = 8
        | StringLiteral = 9
        | JsxText = 10
        | RegularExpressionLiteral = 11
        | NoSubstitutionTemplateLiteral = 12
        | TemplateHead = 13
        | TemplateMiddle = 14
        | TemplateTail = 15
        | OpenBraceToken = 16
        | CloseBraceToken = 17
        | OpenParenToken = 18
        | CloseParenToken = 19
        | OpenBracketToken = 20
        | CloseBracketToken = 21
        | DotToken = 22
        | DotDotDotToken = 23
        | SemicolonToken = 24
        | CommaToken = 25
        | LessThanToken = 26
        | LessThanSlashToken = 27
        | GreaterThanToken = 28
        | LessThanEqualsToken = 29
        | GreaterThanEqualsToken = 30
        | EqualsEqualsToken = 31
        | ExclamationEqualsToken = 32
        | EqualsEqualsEqualsToken = 33
        | ExclamationEqualsEqualsToken = 34
        | EqualsGreaterThanToken = 35
        | PlusToken = 36
        | MinusToken = 37
        | AsteriskToken = 38
        | AsteriskAsteriskToken = 39
        | SlashToken = 40
        | PercentToken = 41
        | PlusPlusToken = 42
        | MinusMinusToken = 43
        | LessThanLessThanToken = 44
        | GreaterThanGreaterThanToken = 45
        | GreaterThanGreaterThanGreaterThanToken = 46
        | AmpersandToken = 47
        | BarToken = 48
        | CaretToken = 49
        | ExclamationToken = 50
        | TildeToken = 51
        | AmpersandAmpersandToken = 52
        | BarBarToken = 53
        | QuestionToken = 54
        | ColonToken = 55
        | AtToken = 56
        | EqualsToken = 57
        | PlusEqualsToken = 58
        | MinusEqualsToken = 59
        | AsteriskEqualsToken = 60
        | AsteriskAsteriskEqualsToken = 61
        | SlashEqualsToken = 62
        | PercentEqualsToken = 63
        | LessThanLessThanEqualsToken = 64
        | GreaterThanGreaterThanEqualsToken = 65
        | GreaterThanGreaterThanGreaterThanEqualsToken = 66
        | AmpersandEqualsToken = 67
        | BarEqualsToken = 68
        | CaretEqualsToken = 69
        | Identifier = 70
        | BreakKeyword = 71
        | CaseKeyword = 72
        | CatchKeyword = 73
        | ClassKeyword = 74
        | ConstKeyword = 75
        | ContinueKeyword = 76
        | DebuggerKeyword = 77
        | DefaultKeyword = 78
        | DeleteKeyword = 79
        | DoKeyword = 80
        | ElseKeyword = 81
        | EnumKeyword = 82
        | ExportKeyword = 83
        | ExtendsKeyword = 84
        | FalseKeyword = 85
        | FinallyKeyword = 86
        | ForKeyword = 87
        | FunctionKeyword = 88
        | IfKeyword = 89
        | ImportKeyword = 90
        | InKeyword = 91
        | InstanceOfKeyword = 92
        | NewKeyword = 93
        | NullKeyword = 94
        | ReturnKeyword = 95
        | SuperKeyword = 96
        | SwitchKeyword = 97
        | ThisKeyword = 98
        | ThrowKeyword = 99
        | TrueKeyword = 100
        | TryKeyword = 101
        | TypeOfKeyword = 102
        | VarKeyword = 103
        | VoidKeyword = 104
        | WhileKeyword = 105
        | WithKeyword = 106
        | ImplementsKeyword = 107
        | InterfaceKeyword = 108
        | LetKeyword = 109
        | PackageKeyword = 110
        | PrivateKeyword = 111
        | ProtectedKeyword = 112
        | PublicKeyword = 113
        | StaticKeyword = 114
        | YieldKeyword = 115
        | AbstractKeyword = 116
        | AsKeyword = 117
        | AnyKeyword = 118
        | AsyncKeyword = 119
        | AwaitKeyword = 120
        | BooleanKeyword = 121
        | ConstructorKeyword = 122
        | DeclareKeyword = 123
        | GetKeyword = 124
        | IsKeyword = 125
        | KeyOfKeyword = 126
        | ModuleKeyword = 127
        | NamespaceKeyword = 128
        | NeverKeyword = 129
        | ReadonlyKeyword = 130
        | RequireKeyword = 131
        | NumberKeyword = 132
        | SetKeyword = 133
        | StringKeyword = 134
        | SymbolKeyword = 135
        | TypeKeyword = 136
        | UndefinedKeyword = 137
        | FromKeyword = 138
        | GlobalKeyword = 139
        | OfKeyword = 140
        | QualifiedName = 141
        | ComputedPropertyName = 142
        | TypeParameter = 143
        | Parameter = 144
        | Decorator = 145
        | PropertySignature = 146
        | PropertyDeclaration = 147
        | MethodSignature = 148
        | MethodDeclaration = 149
        | Constructor = 150
        | GetAccessor = 151
        | SetAccessor = 152
        | CallSignature = 153
        | ConstructSignature = 154
        | IndexSignature = 155
        | TypePredicate = 156
        | TypeReference = 157
        | FunctionType = 158
        | ConstructorType = 159
        | TypeQuery = 160
        | TypeLiteral = 161
        | ArrayType = 162
        | TupleType = 163
        | UnionType = 164
        | IntersectionType = 165
        | ParenthesizedType = 166
        | ThisType = 167
        | TypeOperator = 168
        | IndexedAccessType = 169
        | MappedType = 170
        | LiteralType = 171
        | ObjectBindingPattern = 172
        | ArrayBindingPattern = 173
        | BindingElement = 174
        | ArrayLiteralExpression = 175
        | ObjectLiteralExpression = 176
        | PropertyAccessExpression = 177
        | ElementAccessExpression = 178
        | CallExpression = 179
        | NewExpression = 180
        | TaggedTemplateExpression = 181
        | TypeAssertionExpression = 182
        | ParenthesizedExpression = 183
        | FunctionExpression = 184
        | ArrowFunction = 185
        | DeleteExpression = 186
        | TypeOfExpression = 187
        | VoidExpression = 188
        | AwaitExpression = 189
        | PrefixUnaryExpression = 190
        | PostfixUnaryExpression = 191
        | BinaryExpression = 192
        | ConditionalExpression = 193
        | TemplateExpression = 194
        | YieldExpression = 195
        | SpreadElement = 196
        | ClassExpression = 197
        | OmittedExpression = 198
        | ExpressionWithTypeArguments = 199
        | AsExpression = 200
        | NonNullExpression = 201
        | TemplateSpan = 202
        | SemicolonClassElement = 203
        | Block = 204
        | VariableStatement = 205
        | EmptyStatement = 206
        | ExpressionStatement = 207
        | IfStatement = 208
        | DoStatement = 209
        | WhileStatement = 210
        | ForStatement = 211
        | ForInStatement = 212
        | ForOfStatement = 213
        | ContinueStatement = 214
        | BreakStatement = 215
        | ReturnStatement = 216
        | WithStatement = 217
        | SwitchStatement = 218
        | LabeledStatement = 219
        | ThrowStatement = 220
        | TryStatement = 221
        | DebuggerStatement = 222
        | VariableDeclaration = 223
        | VariableDeclarationList = 224
        | FunctionDeclaration = 225
        | ClassDeclaration = 226
        | InterfaceDeclaration = 227
        | TypeAliasDeclaration = 228
        | EnumDeclaration = 229
        | ModuleDeclaration = 230
        | ModuleBlock = 231
        | CaseBlock = 232
        | NamespaceExportDeclaration = 233
        | ImportEqualsDeclaration = 234
        | ImportDeclaration = 235
        | ImportClause = 236
        | NamespaceImport = 237
        | NamedImports = 238
        | ImportSpecifier = 239
        | ExportAssignment = 240
        | ExportDeclaration = 241
        | NamedExports = 242
        | ExportSpecifier = 243
        | MissingDeclaration = 244
        | ExternalModuleReference = 245
        | JsxElement = 246
        | JsxSelfClosingElement = 247
        | JsxOpeningElement = 248
        | JsxClosingElement = 249
        | JsxAttribute = 250
        | JsxSpreadAttribute = 251
        | JsxExpression = 252
        | CaseClause = 253
        | DefaultClause = 254
        | HeritageClause = 255
        | CatchClause = 256
        | PropertyAssignment = 257
        | ShorthandPropertyAssignment = 258
        | SpreadAssignment = 259
        | EnumMember = 260
        | SourceFile = 261
        | JSDocTypeExpression = 262
        | JSDocAllType = 263
        | JSDocUnknownType = 264
        | JSDocArrayType = 265
        | JSDocUnionType = 266
        | JSDocTupleType = 267
        | JSDocNullableType = 268
        | JSDocNonNullableType = 269
        | JSDocRecordType = 270
        | JSDocRecordMember = 271
        | JSDocTypeReference = 272
        | JSDocOptionalType = 273
        | JSDocFunctionType = 274
        | JSDocVariadicType = 275
        | JSDocConstructorType = 276
        | JSDocThisType = 277
        | JSDocComment = 278
        | JSDocTag = 279
        | JSDocAugmentsTag = 280
        | JSDocParameterTag = 281
        | JSDocReturnTag = 282
        | JSDocTypeTag = 283
        | JSDocTemplateTag = 284
        | JSDocTypedefTag = 285
        | JSDocPropertyTag = 286
        | JSDocTypeLiteral = 287
        | JSDocLiteralType = 288
        | JSDocNullKeyword = 289
        | JSDocUndefinedKeyword = 290
        | JSDocNeverKeyword = 291
        | SyntaxList = 292
        | NotEmittedStatement = 293
        | PartiallyEmittedExpression = 294
        | MergeDeclarationMarker = 295
        | EndOfDeclarationMarker = 296
        | Count = 297
        | FirstAssignment = 57
        | LastAssignment = 69
        | FirstCompoundAssignment = 58
        | LastCompoundAssignment = 69
        | FirstReservedWord = 71
        | LastReservedWord = 106
        | FirstKeyword = 71
        | LastKeyword = 140
        | FirstFutureReservedWord = 107
        | LastFutureReservedWord = 115
        | FirstTypeNode = 156
        | LastTypeNode = 171
        | FirstPunctuation = 16
        | LastPunctuation = 69
        | FirstToken = 0
        | LastToken = 140
        | FirstTriviaToken = 2
        | LastTriviaToken = 7
        | FirstLiteralToken = 8
        | LastLiteralToken = 12
        | FirstTemplateToken = 12
        | LastTemplateToken = 15
        | FirstBinaryOperator = 26
        | LastBinaryOperator = 69
        | FirstNode = 141
        | FirstJSDocNode = 262
        | LastJSDocNode = 288
        | FirstJSDocTagNode = 278
        | LastJSDocTagNode = 291

    and NodeFlags =
        | None = 0
        | Let = 1
        | Const = 2
        | NestedNamespace = 4
        | Synthesized = 8
        | Namespace = 16
        | ExportContext = 32
        | ContainsThis = 64
        | HasImplicitReturn = 128
        | HasExplicitReturn = 256
        | GlobalAugmentation = 512
        | HasAsyncFunctions = 1024
        | DisallowInContext = 2048
        | YieldContext = 4096
        | DecoratorContext = 8192
        | AwaitContext = 16384
        | ThisNodeHasError = 32768
        | JavaScriptFile = 65536
        | ThisNodeOrAnySubNodesHasError = 131072
        | HasAggregatedChildData = 262144
        | BlockScoped = 3
        | ReachabilityCheckFlags = 384
        | ReachabilityAndEmitFlags = 1408
        | ContextFlags = 96256
        | TypeExcludesFlags = 20480

    and ModifierFlags =
        | None = 0
        | Export = 1
        | Ambient = 2
        | Public = 4
        | Private = 8
        | Protected = 16
        | Static = 32
        | Readonly = 64
        | Abstract = 128
        | Async = 256
        | Default = 512
        | Const = 2048
        | HasComputedFlags = 536870912
        | AccessibilityModifier = 28
        | ParameterPropertyModifier = 92
        | NonPublicAccessibilityModifier = 24
        | TypeScriptModifier = 2270
        | ExportDefault = 513

    and JsxFlags =
        | None = 0
        | IntrinsicNamedElement = 1
        | IntrinsicIndexedElement = 2
        | IntrinsicElement = 3

    and [<AllowNullLiteral>] Node =
        inherit TextRange
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind[OPTION] with get, set
        abstract flags: NodeFlags[OPTION] with get, set
        abstract decorators: NodeArray<Decorator> option with get, set
        abstract modifiers: ModifiersArray option with get, set
        abstract parent: Node option with get, set
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getSourceFile: unit -> SourceFile
        abstract getChildCount: ?sourceFile: SourceFile -> float
        abstract getChildAt: index: float * ?sourceFile: SourceFile -> Node
        abstract getChildren: ?sourceFile: SourceFile -> ResizeArray<Node>
        abstract getStart: ?sourceFile: SourceFile * ?includeJsDocComment: bool -> float
        abstract getFullStart: unit -> float
        abstract getEnd: unit -> float
        abstract getWidth: ?sourceFile: SourceFile -> float
        abstract getFullWidth: unit -> float
        abstract getLeadingTriviaWidth: ?sourceFile: SourceFile -> float
        abstract getFullText: ?sourceFile: SourceFile -> string
        abstract getText: ?sourceFile: SourceFile -> string
        abstract getFirstToken: ?sourceFile: SourceFile -> Node
        abstract getLastToken: ?sourceFile: SourceFile -> Node

    and [<AllowNullLiteral>] NodeArray<'T> =
        inherit ResizeArray<'T>
        inherit TextRange
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract hasTrailingComma: bool option with get, set

    and [<AllowNullLiteral>] Token<'TKind> =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: 'TKind[OPTION] with get, set

    and DotDotDotToken =
        Token<SyntaxKind.DotDotDotToken>

    and QuestionToken =
        Token<SyntaxKind.QuestionToken>

    and ColonToken =
        Token<SyntaxKind.ColonToken>

    and EqualsToken =
        Token<SyntaxKind.EqualsToken>

    and AsteriskToken =
        Token<SyntaxKind.AsteriskToken>

    and EqualsGreaterThanToken =
        Token<SyntaxKind.EqualsGreaterThanToken>

    and EndOfFileToken =
        Token<SyntaxKind.EndOfFileToken>

    and AtToken =
        Token<SyntaxKind.AtToken>

    and ReadonlyToken =
        Token<SyntaxKind.ReadonlyKeyword>

    and Modifier =
        obj

    and ModifiersArray =
        NodeArray<Modifier>

    and [<AllowNullLiteral>] Identifier =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.Identifier[OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract originalKeywordKind: SyntaxKind option with get, set
        abstract isInJSDocNamespace: bool option with get, set

    and [<AllowNullLiteral>] TransientIdentifier =
        inherit Identifier
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract resolvedSymbol: Symbol[OPTION] with get, set

    and [<AllowNullLiteral>] QualifiedName =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.QualifiedName[OPTION] with get, set
        abstract left: EntityName[OPTION] with get, set
        abstract right: Identifier[OPTION] with get, set

    and EntityName =
        U2<Identifier, QualifiedName>

    and PropertyName =
        U4<Identifier, StringLiteral, NumericLiteral, ComputedPropertyName>

    and DeclarationName =
        obj

    and [<AllowNullLiteral>] Declaration =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _declarationBrand: obj[OPTION] with get, set
        abstract name: DeclarationName option with get, set

    and [<AllowNullLiteral>] DeclarationStatement =
        inherit Declaration
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: U3<Identifier, StringLiteral, NumericLiteral> option with get, set

    and [<AllowNullLiteral>] ComputedPropertyName =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ComputedPropertyName[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] Decorator =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.Decorator[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set

    and [<AllowNullLiteral>] TypeParameterDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeParameter[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract ``constraint``: TypeNode option with get, set
        abstract expression: Expression option with get, set

    and [<AllowNullLiteral>] SignatureDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: PropertyName option with get, set
        abstract typeParameters: NodeArray<TypeParameterDeclaration> option with get, set
        abstract parameters: NodeArray<ParameterDeclaration>[OPTION] with get, set
        abstract ``type``: TypeNode option with get, set

    and [<AllowNullLiteral>] CallSignatureDeclaration =
        inherit SignatureDeclaration
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.CallSignature[OPTION] with get, set

    and [<AllowNullLiteral>] ConstructSignatureDeclaration =
        inherit SignatureDeclaration
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ConstructSignature[OPTION] with get, set

    and BindingName =
        U2<Identifier, BindingPattern>

    and [<AllowNullLiteral>] VariableDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.VariableDeclaration[OPTION] with get, set
        abstract parent: VariableDeclarationList option with get, set
        abstract name: BindingName[OPTION] with get, set
        abstract ``type``: TypeNode option with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] VariableDeclarationList =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.VariableDeclarationList[OPTION] with get, set
        abstract declarations: NodeArray<VariableDeclaration>[OPTION] with get, set

    and [<AllowNullLiteral>] ParameterDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.Parameter[OPTION] with get, set
        abstract dotDotDotToken: DotDotDotToken option with get, set
        abstract name: BindingName[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract ``type``: TypeNode option with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] BindingElement =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.BindingElement[OPTION] with get, set
        abstract propertyName: PropertyName option with get, set
        abstract dotDotDotToken: DotDotDotToken option with get, set
        abstract name: BindingName[OPTION] with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] PropertySignature =
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: U2<SyntaxKind.PropertySignature, SyntaxKind.JSDocRecordMember>[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract ``type``: TypeNode option with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] PropertyDeclaration =
        inherit ClassElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.PropertyDeclaration[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract ``type``: TypeNode option with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] ObjectLiteralElement =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _objectLiteralBrandBrand: obj[OPTION] with get, set
        abstract name: PropertyName option with get, set

    and ObjectLiteralElementLike =
        obj

    and [<AllowNullLiteral>] PropertyAssignment =
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.PropertyAssignment[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract initializer: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] ShorthandPropertyAssignment =
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ShorthandPropertyAssignment[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract equalsToken: Token<SyntaxKind.EqualsToken> option with get, set
        abstract objectAssignmentInitializer: Expression option with get, set

    and [<AllowNullLiteral>] SpreadAssignment =
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SpreadAssignment[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] VariableLikeDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract propertyName: PropertyName option with get, set
        abstract dotDotDotToken: DotDotDotToken option with get, set
        abstract name: DeclarationName[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract ``type``: TypeNode option with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] PropertyLikeDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set

    and [<AllowNullLiteral>] ObjectBindingPattern =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ObjectBindingPattern[OPTION] with get, set
        abstract elements: NodeArray<BindingElement>[OPTION] with get, set

    and [<AllowNullLiteral>] ArrayBindingPattern =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ArrayBindingPattern[OPTION] with get, set
        abstract elements: NodeArray<ArrayBindingElement>[OPTION] with get, set

    and BindingPattern =
        U2<ObjectBindingPattern, ArrayBindingPattern>

    and ArrayBindingElement =
        U2<BindingElement, OmittedExpression>

    and [<AllowNullLiteral>] FunctionLikeDeclaration =
        inherit SignatureDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _functionLikeDeclarationBrand: obj[OPTION] with get, set
        abstract asteriskToken: AsteriskToken option with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract body: U2<Block, Expression> option with get, set

    and [<AllowNullLiteral>] FunctionDeclaration =
        inherit FunctionLikeDeclaration
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.FunctionDeclaration[OPTION] with get, set
        abstract name: Identifier option with get, set
        abstract body: FunctionBody option with get, set

    and [<AllowNullLiteral>] MethodSignature =
        inherit SignatureDeclaration
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.MethodSignature[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set

    and [<AllowNullLiteral>] MethodDeclaration =
        inherit FunctionLikeDeclaration
        inherit ClassElement
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.MethodDeclaration[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract body: FunctionBody option with get, set

    and [<AllowNullLiteral>] ConstructorDeclaration =
        inherit FunctionLikeDeclaration
        inherit ClassElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.Constructor[OPTION] with get, set
        abstract body: FunctionBody option with get, set

    and [<AllowNullLiteral>] SemicolonClassElement =
        inherit ClassElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SemicolonClassElement[OPTION] with get, set

    and [<AllowNullLiteral>] GetAccessorDeclaration =
        inherit FunctionLikeDeclaration
        inherit ClassElement
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.GetAccessor[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract body: FunctionBody[OPTION] with get, set

    and [<AllowNullLiteral>] SetAccessorDeclaration =
        inherit FunctionLikeDeclaration
        inherit ClassElement
        inherit ObjectLiteralElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SetAccessor[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract body: FunctionBody[OPTION] with get, set

    and AccessorDeclaration =
        U2<GetAccessorDeclaration, SetAccessorDeclaration>

    and [<AllowNullLiteral>] IndexSignatureDeclaration =
        inherit SignatureDeclaration
        inherit ClassElement
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.IndexSignature[OPTION] with get, set

    and [<AllowNullLiteral>] TypeNode =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _typeNodeBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] KeywordTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: obj[OPTION] with get, set

    and [<AllowNullLiteral>] ThisTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ThisType[OPTION] with get, set

    and [<AllowNullLiteral>] FunctionOrConstructorTypeNode =
        inherit TypeNode
        inherit SignatureDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: U2<SyntaxKind.FunctionType, SyntaxKind.ConstructorType>[OPTION] with get, set

    and [<AllowNullLiteral>] FunctionTypeNode =
        inherit FunctionOrConstructorTypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.FunctionType[OPTION] with get, set

    and [<AllowNullLiteral>] ConstructorTypeNode =
        inherit FunctionOrConstructorTypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ConstructorType[OPTION] with get, set

    and [<AllowNullLiteral>] TypeReferenceNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeReference[OPTION] with get, set
        abstract typeName: EntityName[OPTION] with get, set
        abstract typeArguments: NodeArray<TypeNode> option with get, set

    and [<AllowNullLiteral>] TypePredicateNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypePredicate[OPTION] with get, set
        abstract parameterName: U2<Identifier, ThisTypeNode>[OPTION] with get, set
        abstract ``type``: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] TypeQueryNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeQuery[OPTION] with get, set
        abstract exprName: EntityName[OPTION] with get, set

    and [<AllowNullLiteral>] TypeLiteralNode =
        inherit TypeNode
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeLiteral[OPTION] with get, set
        abstract members: NodeArray<TypeElement>[OPTION] with get, set

    and [<AllowNullLiteral>] ArrayTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ArrayType[OPTION] with get, set
        abstract elementType: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] TupleTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TupleType[OPTION] with get, set
        abstract elementTypes: NodeArray<TypeNode>[OPTION] with get, set

    and [<AllowNullLiteral>] UnionOrIntersectionTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: U2<SyntaxKind.UnionType, SyntaxKind.IntersectionType>[OPTION] with get, set
        abstract types: NodeArray<TypeNode>[OPTION] with get, set

    and [<AllowNullLiteral>] UnionTypeNode =
        inherit UnionOrIntersectionTypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.UnionType[OPTION] with get, set

    and [<AllowNullLiteral>] IntersectionTypeNode =
        inherit UnionOrIntersectionTypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.IntersectionType[OPTION] with get, set

    and [<AllowNullLiteral>] ParenthesizedTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ParenthesizedType[OPTION] with get, set
        abstract ``type``: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] TypeOperatorNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeOperator[OPTION] with get, set
        abstract operator: SyntaxKind.KeyOfKeyword[OPTION] with get, set
        abstract ``type``: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] IndexedAccessTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.IndexedAccessType[OPTION] with get, set
        abstract objectType: TypeNode[OPTION] with get, set
        abstract indexType: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] MappedTypeNode =
        inherit TypeNode
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.MappedType[OPTION] with get, set
        abstract Token: ReadonlyToken option with get, set
        abstract typeParameter: TypeParameterDeclaration[OPTION] with get, set
        abstract questionToken: QuestionToken option with get, set
        abstract ``type``: TypeNode option with get, set

    and [<AllowNullLiteral>] LiteralTypeNode =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.LiteralType[OPTION] with get, set
        abstract literal: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] StringLiteral =
        inherit LiteralExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.StringLiteral[OPTION] with get, set

    and [<AllowNullLiteral>] Expression =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _expressionBrand: obj[OPTION] with get, set
        abstract contextualType: Type option with get, set

    and [<AllowNullLiteral>] OmittedExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.OmittedExpression[OPTION] with get, set

    and [<AllowNullLiteral>] UnaryExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _unaryExpressionBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] IncrementExpression =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _incrementExpressionBrand: obj[OPTION] with get, set

    and PrefixUnaryOperator =
        obj

    and [<AllowNullLiteral>] PrefixUnaryExpression =
        inherit IncrementExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.PrefixUnaryExpression[OPTION] with get, set
        abstract operator: PrefixUnaryOperator[OPTION] with get, set
        abstract operand: UnaryExpression[OPTION] with get, set

    and PostfixUnaryOperator =
        U2<SyntaxKind.PlusPlusToken, SyntaxKind.MinusMinusToken>

    and [<AllowNullLiteral>] PostfixUnaryExpression =
        inherit IncrementExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.PostfixUnaryExpression[OPTION] with get, set
        abstract operand: LeftHandSideExpression[OPTION] with get, set
        abstract operator: PostfixUnaryOperator[OPTION] with get, set

    and [<AllowNullLiteral>] LeftHandSideExpression =
        inherit IncrementExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _leftHandSideExpressionBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] MemberExpression =
        inherit LeftHandSideExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _memberExpressionBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] PrimaryExpression =
        inherit MemberExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _primaryExpressionBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] NullLiteral =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NullKeyword[OPTION] with get, set

    and [<AllowNullLiteral>] BooleanLiteral =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: U2<SyntaxKind.TrueKeyword, SyntaxKind.FalseKeyword>[OPTION] with get, set

    and [<AllowNullLiteral>] ThisExpression =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ThisKeyword[OPTION] with get, set

    and [<AllowNullLiteral>] SuperExpression =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SuperKeyword[OPTION] with get, set

    and [<AllowNullLiteral>] DeleteExpression =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.DeleteExpression[OPTION] with get, set
        abstract expression: UnaryExpression[OPTION] with get, set

    and [<AllowNullLiteral>] TypeOfExpression =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeOfExpression[OPTION] with get, set
        abstract expression: UnaryExpression[OPTION] with get, set

    and [<AllowNullLiteral>] VoidExpression =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.VoidExpression[OPTION] with get, set
        abstract expression: UnaryExpression[OPTION] with get, set

    and [<AllowNullLiteral>] AwaitExpression =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.AwaitExpression[OPTION] with get, set
        abstract expression: UnaryExpression[OPTION] with get, set

    and [<AllowNullLiteral>] YieldExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.YieldExpression[OPTION] with get, set
        abstract asteriskToken: AsteriskToken option with get, set
        abstract expression: Expression option with get, set

    and ExponentiationOperator =
        SyntaxKind.AsteriskAsteriskToken

    and MultiplicativeOperator =
        U3<SyntaxKind.AsteriskToken, SyntaxKind.SlashToken, SyntaxKind.PercentToken>

    and MultiplicativeOperatorOrHigher =
        U2<ExponentiationOperator, MultiplicativeOperator>

    and AdditiveOperator =
        U2<SyntaxKind.PlusToken, SyntaxKind.MinusToken>

    and AdditiveOperatorOrHigher =
        U2<MultiplicativeOperatorOrHigher, AdditiveOperator>

    and ShiftOperator =
        U3<SyntaxKind.LessThanLessThanToken, SyntaxKind.GreaterThanGreaterThanToken, SyntaxKind.GreaterThanGreaterThanGreaterThanToken>

    and ShiftOperatorOrHigher =
        U2<AdditiveOperatorOrHigher, ShiftOperator>

    and RelationalOperator =
        obj

    and RelationalOperatorOrHigher =
        U2<ShiftOperatorOrHigher, RelationalOperator>

    and EqualityOperator =
        U4<SyntaxKind.EqualsEqualsToken, SyntaxKind.EqualsEqualsEqualsToken, SyntaxKind.ExclamationEqualsEqualsToken, SyntaxKind.ExclamationEqualsToken>

    and EqualityOperatorOrHigher =
        U2<RelationalOperatorOrHigher, EqualityOperator>

    and BitwiseOperator =
        U3<SyntaxKind.AmpersandToken, SyntaxKind.BarToken, SyntaxKind.CaretToken>

    and BitwiseOperatorOrHigher =
        U2<EqualityOperatorOrHigher, BitwiseOperator>

    and LogicalOperator =
        U2<SyntaxKind.AmpersandAmpersandToken, SyntaxKind.BarBarToken>

    and LogicalOperatorOrHigher =
        U2<BitwiseOperatorOrHigher, LogicalOperator>

    and CompoundAssignmentOperator =
        obj

    and AssignmentOperator =
        U2<SyntaxKind.EqualsToken, CompoundAssignmentOperator>

    and AssignmentOperatorOrHigher =
        U2<LogicalOperatorOrHigher, AssignmentOperator>

    and BinaryOperator =
        U2<AssignmentOperatorOrHigher, SyntaxKind.CommaToken>

    and BinaryOperatorToken =
        Token<BinaryOperator>

    and [<AllowNullLiteral>] BinaryExpression =
        inherit Expression
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.BinaryExpression[OPTION] with get, set
        abstract left: Expression[OPTION] with get, set
        abstract operatorToken: BinaryOperatorToken[OPTION] with get, set
        abstract right: Expression[OPTION] with get, set

    and AssignmentOperatorToken =
        Token<AssignmentOperator>

    and [<AllowNullLiteral>] AssignmentExpression<'TOperator> =
        inherit BinaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract left: LeftHandSideExpression[OPTION] with get, set
        abstract operatorToken: 'TOperator[OPTION] with get, set

    and [<AllowNullLiteral>] ObjectDestructuringAssignment =
        inherit AssignmentExpression<EqualsToken>
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract left: ObjectLiteralExpression[OPTION] with get, set

    and [<AllowNullLiteral>] ArrayDestructuringAssignment =
        inherit AssignmentExpression<EqualsToken>
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract left: ArrayLiteralExpression[OPTION] with get, set

    and DestructuringAssignment =
        U2<ObjectDestructuringAssignment, ArrayDestructuringAssignment>

    and BindingOrAssignmentElement =
        obj

    and BindingOrAssignmentElementRestIndicator =
        U3<DotDotDotToken, SpreadElement, SpreadAssignment>

    and BindingOrAssignmentElementTarget =
        U2<BindingOrAssignmentPattern, Expression>

    and ObjectBindingOrAssignmentPattern =
        U2<ObjectBindingPattern, ObjectLiteralExpression>

    and ArrayBindingOrAssignmentPattern =
        U2<ArrayBindingPattern, ArrayLiteralExpression>

    and AssignmentPattern =
        U2<ObjectLiteralExpression, ArrayLiteralExpression>

    and BindingOrAssignmentPattern =
        U2<ObjectBindingOrAssignmentPattern, ArrayBindingOrAssignmentPattern>

    and [<AllowNullLiteral>] ConditionalExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ConditionalExpression[OPTION] with get, set
        abstract condition: Expression[OPTION] with get, set
        abstract questionToken: QuestionToken[OPTION] with get, set
        abstract whenTrue: Expression[OPTION] with get, set
        abstract colonToken: ColonToken[OPTION] with get, set
        abstract whenFalse: Expression[OPTION] with get, set

    and FunctionBody =
        Block

    and ConciseBody =
        U2<FunctionBody, Expression>

    and [<AllowNullLiteral>] FunctionExpression =
        inherit PrimaryExpression
        inherit FunctionLikeDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.FunctionExpression[OPTION] with get, set
        abstract name: Identifier option with get, set
        abstract body: FunctionBody[OPTION] with get, set

    and [<AllowNullLiteral>] ArrowFunction =
        inherit Expression
        inherit FunctionLikeDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ArrowFunction[OPTION] with get, set
        abstract equalsGreaterThanToken: EqualsGreaterThanToken[OPTION] with get, set
        abstract body: ConciseBody[OPTION] with get, set

    and [<AllowNullLiteral>] LiteralLikeNode =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract isUnterminated: bool option with get, set
        abstract hasExtendedUnicodeEscape: bool option with get, set

    and [<AllowNullLiteral>] LiteralExpression =
        inherit LiteralLikeNode
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _literalExpressionBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] RegularExpressionLiteral =
        inherit LiteralExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.RegularExpressionLiteral[OPTION] with get, set

    and [<AllowNullLiteral>] NoSubstitutionTemplateLiteral =
        inherit LiteralExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NoSubstitutionTemplateLiteral[OPTION] with get, set

    and [<AllowNullLiteral>] NumericLiteral =
        inherit LiteralExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NumericLiteral[OPTION] with get, set
        abstract trailingComment: string option with get, set

    and [<AllowNullLiteral>] TemplateHead =
        inherit LiteralLikeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TemplateHead[OPTION] with get, set

    and [<AllowNullLiteral>] TemplateMiddle =
        inherit LiteralLikeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TemplateMiddle[OPTION] with get, set

    and [<AllowNullLiteral>] TemplateTail =
        inherit LiteralLikeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TemplateTail[OPTION] with get, set

    and TemplateLiteral =
        U2<TemplateExpression, NoSubstitutionTemplateLiteral>

    and [<AllowNullLiteral>] TemplateExpression =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TemplateExpression[OPTION] with get, set
        abstract head: TemplateHead[OPTION] with get, set
        abstract templateSpans: NodeArray<TemplateSpan>[OPTION] with get, set

    and [<AllowNullLiteral>] TemplateSpan =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TemplateSpan[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract literal: U2<TemplateMiddle, TemplateTail>[OPTION] with get, set

    and [<AllowNullLiteral>] ParenthesizedExpression =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ParenthesizedExpression[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] ArrayLiteralExpression =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ArrayLiteralExpression[OPTION] with get, set
        abstract elements: NodeArray<Expression>[OPTION] with get, set

    and [<AllowNullLiteral>] SpreadElement =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SpreadElement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] ObjectLiteralExpressionBase<'T> =
        inherit PrimaryExpression
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract properties: NodeArray<'T>[OPTION] with get, set

    and [<AllowNullLiteral>] ObjectLiteralExpression =
        inherit ObjectLiteralExpressionBase<ObjectLiteralElementLike>
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ObjectLiteralExpression[OPTION] with get, set

    and EntityNameExpression =
        U2<Identifier, PropertyAccessEntityNameExpression>

    and EntityNameOrEntityNameExpression =
        U2<EntityName, EntityNameExpression>

    and [<AllowNullLiteral>] PropertyAccessExpression =
        inherit MemberExpression
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.PropertyAccessExpression[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set

    and [<AllowNullLiteral>] SuperPropertyAccessExpression =
        inherit PropertyAccessExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract expression: SuperExpression[OPTION] with get, set

    and [<AllowNullLiteral>] PropertyAccessEntityNameExpression =
        inherit PropertyAccessExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _propertyAccessExpressionLikeQualifiedNameBrand: obj option with get, set
        abstract expression: EntityNameExpression[OPTION] with get, set

    and [<AllowNullLiteral>] ElementAccessExpression =
        inherit MemberExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ElementAccessExpression[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set
        abstract argumentExpression: Expression option with get, set

    and [<AllowNullLiteral>] SuperElementAccessExpression =
        inherit ElementAccessExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract expression: SuperExpression[OPTION] with get, set

    and SuperProperty =
        U2<SuperPropertyAccessExpression, SuperElementAccessExpression>

    and [<AllowNullLiteral>] CallExpression =
        inherit LeftHandSideExpression
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.CallExpression[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set
        abstract typeArguments: NodeArray<TypeNode> option with get, set
        abstract arguments: NodeArray<Expression>[OPTION] with get, set

    and [<AllowNullLiteral>] SuperCall =
        inherit CallExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract expression: SuperExpression[OPTION] with get, set

    and [<AllowNullLiteral>] ExpressionWithTypeArguments =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExpressionWithTypeArguments[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set
        abstract typeArguments: NodeArray<TypeNode> option with get, set

    and [<AllowNullLiteral>] NewExpression =
        inherit PrimaryExpression
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NewExpression[OPTION] with get, set
        abstract expression: LeftHandSideExpression[OPTION] with get, set
        abstract typeArguments: NodeArray<TypeNode> option with get, set
        abstract arguments: NodeArray<Expression>[OPTION] with get, set

    and [<AllowNullLiteral>] TaggedTemplateExpression =
        inherit MemberExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TaggedTemplateExpression[OPTION] with get, set
        abstract tag: LeftHandSideExpression[OPTION] with get, set
        abstract template: TemplateLiteral[OPTION] with get, set

    and CallLikeExpression =
        U4<CallExpression, NewExpression, TaggedTemplateExpression, Decorator>

    and [<AllowNullLiteral>] AsExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.AsExpression[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract ``type``: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] TypeAssertion =
        inherit UnaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeAssertionExpression[OPTION] with get, set
        abstract ``type``: TypeNode[OPTION] with get, set
        abstract expression: UnaryExpression[OPTION] with get, set

    and AssertionExpression =
        U2<TypeAssertion, AsExpression>

    and [<AllowNullLiteral>] NonNullExpression =
        inherit LeftHandSideExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NonNullExpression[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] JsxElement =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxElement[OPTION] with get, set
        abstract openingElement: JsxOpeningElement[OPTION] with get, set
        abstract children: NodeArray<JsxChild>[OPTION] with get, set
        abstract closingElement: JsxClosingElement[OPTION] with get, set

    and JsxTagNameExpression =
        U2<PrimaryExpression, PropertyAccessExpression>

    and [<AllowNullLiteral>] JsxOpeningElement =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxOpeningElement[OPTION] with get, set
        abstract tagName: JsxTagNameExpression[OPTION] with get, set
        abstract attributes: NodeArray<U2<JsxAttribute, JsxSpreadAttribute>>[OPTION] with get, set

    and [<AllowNullLiteral>] JsxSelfClosingElement =
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxSelfClosingElement[OPTION] with get, set
        abstract tagName: JsxTagNameExpression[OPTION] with get, set
        abstract attributes: NodeArray<U2<JsxAttribute, JsxSpreadAttribute>>[OPTION] with get, set

    and JsxOpeningLikeElement =
        U2<JsxSelfClosingElement, JsxOpeningElement>

    and JsxAttributeLike =
        U2<JsxAttribute, JsxSpreadAttribute>

    and [<AllowNullLiteral>] JsxAttribute =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxAttribute[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract initializer: U2<StringLiteral, JsxExpression> option with get, set

    and [<AllowNullLiteral>] JsxSpreadAttribute =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxSpreadAttribute[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] JsxClosingElement =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxClosingElement[OPTION] with get, set
        abstract tagName: JsxTagNameExpression[OPTION] with get, set

    and [<AllowNullLiteral>] JsxExpression =
        inherit Expression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxExpression[OPTION] with get, set
        abstract expression: Expression option with get, set

    and [<AllowNullLiteral>] JsxText =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JsxText[OPTION] with get, set

    and JsxChild =
        U4<JsxText, JsxExpression, JsxElement, JsxSelfClosingElement>

    and [<AllowNullLiteral>] Statement =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _statementBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] EmptyStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.EmptyStatement[OPTION] with get, set

    and [<AllowNullLiteral>] DebuggerStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.DebuggerStatement[OPTION] with get, set

    and [<AllowNullLiteral>] MissingDeclaration =
        inherit DeclarationStatement
        inherit ClassElement
        inherit ObjectLiteralElement
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.MissingDeclaration[OPTION] with get, set
        abstract name: Identifier option with get, set

    and BlockLike =
        U4<SourceFile, Block, ModuleBlock, CaseClause>

    and [<AllowNullLiteral>] Block =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.Block[OPTION] with get, set
        abstract statements: NodeArray<Statement>[OPTION] with get, set

    and [<AllowNullLiteral>] VariableStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.VariableStatement[OPTION] with get, set
        abstract declarationList: VariableDeclarationList[OPTION] with get, set

    and [<AllowNullLiteral>] ExpressionStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExpressionStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] IfStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.IfStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract thenStatement: Statement[OPTION] with get, set
        abstract elseStatement: Statement option with get, set

    and [<AllowNullLiteral>] IterationStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract statement: Statement[OPTION] with get, set

    and [<AllowNullLiteral>] DoStatement =
        inherit IterationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.DoStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] WhileStatement =
        inherit IterationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.WhileStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and ForInitializer =
        U2<VariableDeclarationList, Expression>

    and [<AllowNullLiteral>] ForStatement =
        inherit IterationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ForStatement[OPTION] with get, set
        abstract initializer: ForInitializer option with get, set
        abstract condition: Expression option with get, set
        abstract incrementor: Expression option with get, set

    and [<AllowNullLiteral>] ForInStatement =
        inherit IterationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ForInStatement[OPTION] with get, set
        abstract initializer: ForInitializer[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] ForOfStatement =
        inherit IterationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ForOfStatement[OPTION] with get, set
        abstract initializer: ForInitializer[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] BreakStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.BreakStatement[OPTION] with get, set
        abstract label: Identifier option with get, set

    and [<AllowNullLiteral>] ContinueStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ContinueStatement[OPTION] with get, set
        abstract label: Identifier option with get, set

    and BreakOrContinueStatement =
        U2<BreakStatement, ContinueStatement>

    and [<AllowNullLiteral>] ReturnStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ReturnStatement[OPTION] with get, set
        abstract expression: Expression option with get, set

    and [<AllowNullLiteral>] WithStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.WithStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract statement: Statement[OPTION] with get, set

    and [<AllowNullLiteral>] SwitchStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SwitchStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract caseBlock: CaseBlock[OPTION] with get, set
        abstract possiblyExhaustive: bool option with get, set

    and [<AllowNullLiteral>] CaseBlock =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.CaseBlock[OPTION] with get, set
        abstract clauses: NodeArray<CaseOrDefaultClause>[OPTION] with get, set

    and [<AllowNullLiteral>] CaseClause =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.CaseClause[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract statements: NodeArray<Statement>[OPTION] with get, set

    and [<AllowNullLiteral>] DefaultClause =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.DefaultClause[OPTION] with get, set
        abstract statements: NodeArray<Statement>[OPTION] with get, set

    and CaseOrDefaultClause =
        U2<CaseClause, DefaultClause>

    and [<AllowNullLiteral>] LabeledStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.LabeledStatement[OPTION] with get, set
        abstract label: Identifier[OPTION] with get, set
        abstract statement: Statement[OPTION] with get, set

    and [<AllowNullLiteral>] ThrowStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ThrowStatement[OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] TryStatement =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TryStatement[OPTION] with get, set
        abstract tryBlock: Block[OPTION] with get, set
        abstract catchClause: CatchClause option with get, set
        abstract finallyBlock: Block option with get, set

    and [<AllowNullLiteral>] CatchClause =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.CatchClause[OPTION] with get, set
        abstract variableDeclaration: VariableDeclaration[OPTION] with get, set
        abstract block: Block[OPTION] with get, set

    and DeclarationWithTypeParameters =
        U4<SignatureDeclaration, ClassLikeDeclaration, InterfaceDeclaration, TypeAliasDeclaration>

    and [<AllowNullLiteral>] ClassLikeDeclaration =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: Identifier option with get, set
        abstract typeParameters: NodeArray<TypeParameterDeclaration> option with get, set
        abstract heritageClauses: NodeArray<HeritageClause> option with get, set
        abstract members: NodeArray<ClassElement>[OPTION] with get, set

    and [<AllowNullLiteral>] ClassDeclaration =
        inherit ClassLikeDeclaration
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ClassDeclaration[OPTION] with get, set
        abstract name: Identifier option with get, set

    and [<AllowNullLiteral>] ClassExpression =
        inherit ClassLikeDeclaration
        inherit PrimaryExpression
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ClassExpression[OPTION] with get, set

    and [<AllowNullLiteral>] ClassElement =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _classElementBrand: obj[OPTION] with get, set
        abstract name: PropertyName option with get, set

    and [<AllowNullLiteral>] TypeElement =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _typeElementBrand: obj[OPTION] with get, set
        abstract name: PropertyName option with get, set
        abstract questionToken: QuestionToken option with get, set

    and [<AllowNullLiteral>] InterfaceDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.InterfaceDeclaration[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract typeParameters: NodeArray<TypeParameterDeclaration> option with get, set
        abstract heritageClauses: NodeArray<HeritageClause> option with get, set
        abstract members: NodeArray<TypeElement>[OPTION] with get, set

    and [<AllowNullLiteral>] HeritageClause =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.HeritageClause[OPTION] with get, set
        abstract token: SyntaxKind[OPTION] with get, set
        abstract types: NodeArray<ExpressionWithTypeArguments> option with get, set

    and [<AllowNullLiteral>] TypeAliasDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.TypeAliasDeclaration[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract typeParameters: NodeArray<TypeParameterDeclaration> option with get, set
        abstract ``type``: TypeNode[OPTION] with get, set

    and [<AllowNullLiteral>] EnumMember =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.EnumMember[OPTION] with get, set
        abstract name: PropertyName[OPTION] with get, set
        abstract initializer: Expression option with get, set

    and [<AllowNullLiteral>] EnumDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.EnumDeclaration[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract members: NodeArray<EnumMember>[OPTION] with get, set

    and ModuleBody =
        U2<ModuleBlock, ModuleDeclaration>

    and ModuleName =
        U2<Identifier, StringLiteral>

    and [<AllowNullLiteral>] ModuleDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ModuleDeclaration[OPTION] with get, set
        abstract name: U2<Identifier, StringLiteral>[OPTION] with get, set
        abstract body: U4<ModuleBlock, NamespaceDeclaration, JSDocNamespaceDeclaration, Identifier> option with get, set

    and [<AllowNullLiteral>] NamespaceDeclaration =
        inherit ModuleDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract body: U2<ModuleBlock, NamespaceDeclaration>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocNamespaceDeclaration =
        inherit ModuleDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract body: U2<JSDocNamespaceDeclaration, Identifier>[OPTION] with get, set

    and [<AllowNullLiteral>] ModuleBlock =
        inherit Node
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ModuleBlock[OPTION] with get, set
        abstract statements: NodeArray<Statement>[OPTION] with get, set

    and ModuleReference =
        U2<EntityName, ExternalModuleReference>

    and [<AllowNullLiteral>] ImportEqualsDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ImportEqualsDeclaration[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract moduleReference: ModuleReference[OPTION] with get, set

    and [<AllowNullLiteral>] ExternalModuleReference =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExternalModuleReference[OPTION] with get, set
        abstract expression: Expression option with get, set

    and [<AllowNullLiteral>] ImportDeclaration =
        inherit Statement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ImportDeclaration[OPTION] with get, set
        abstract importClause: ImportClause option with get, set
        abstract moduleSpecifier: Expression[OPTION] with get, set

    and NamedImportBindings =
        U2<NamespaceImport, NamedImports>

    and [<AllowNullLiteral>] ImportClause =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ImportClause[OPTION] with get, set
        abstract name: Identifier option with get, set
        abstract namedBindings: NamedImportBindings option with get, set

    and [<AllowNullLiteral>] NamespaceImport =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NamespaceImport[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set

    and [<AllowNullLiteral>] NamespaceExportDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NamespaceExportDeclaration[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract moduleReference: LiteralLikeNode[OPTION] with get, set

    and [<AllowNullLiteral>] ExportDeclaration =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExportDeclaration[OPTION] with get, set
        abstract exportClause: NamedExports option with get, set
        abstract moduleSpecifier: Expression option with get, set

    and [<AllowNullLiteral>] NamedImports =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NamedImports[OPTION] with get, set
        abstract elements: NodeArray<ImportSpecifier>[OPTION] with get, set

    and [<AllowNullLiteral>] NamedExports =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.NamedExports[OPTION] with get, set
        abstract elements: NodeArray<ExportSpecifier>[OPTION] with get, set

    and NamedImportsOrExports =
        U2<NamedImports, NamedExports>

    and [<AllowNullLiteral>] ImportSpecifier =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ImportSpecifier[OPTION] with get, set
        abstract propertyName: Identifier option with get, set
        abstract name: Identifier[OPTION] with get, set

    and [<AllowNullLiteral>] ExportSpecifier =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExportSpecifier[OPTION] with get, set
        abstract propertyName: Identifier option with get, set
        abstract name: Identifier[OPTION] with get, set

    and ImportOrExportSpecifier =
        U2<ImportSpecifier, ExportSpecifier>

    and [<AllowNullLiteral>] ExportAssignment =
        inherit DeclarationStatement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.ExportAssignment[OPTION] with get, set
        abstract isExportEquals: bool option with get, set
        abstract expression: Expression[OPTION] with get, set

    and [<AllowNullLiteral>] FileReference =
        inherit TextRange
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string[OPTION] with get, set

    and [<AllowNullLiteral>] CommentRange =
        inherit TextRange
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract hasTrailingNewLine: bool option with get, set
        abstract kind: SyntaxKind[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTypeExpression =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTypeExpression[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocType =
        inherit TypeNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _jsDocTypeBrand: obj[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocAllType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocAllType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocUnknownType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocUnknownType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocArrayType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocArrayType[OPTION] with get, set
        abstract elementType: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocUnionType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocUnionType[OPTION] with get, set
        abstract types: NodeArray<JSDocType>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTupleType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTupleType[OPTION] with get, set
        abstract types: NodeArray<JSDocType>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocNonNullableType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocNonNullableType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocNullableType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocNullableType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocRecordType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocRecordType[OPTION] with get, set
        abstract literal: TypeLiteralNode[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTypeReference =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTypeReference[OPTION] with get, set
        abstract name: EntityName[OPTION] with get, set
        abstract typeArguments: NodeArray<JSDocType>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocOptionalType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocOptionalType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocFunctionType =
        inherit JSDocType
        inherit SignatureDeclaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocFunctionType[OPTION] with get, set
        abstract parameters: NodeArray<ParameterDeclaration>[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocVariadicType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocVariadicType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocConstructorType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocConstructorType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocThisType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocThisType[OPTION] with get, set
        abstract ``type``: JSDocType[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocLiteralType =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocLiteralType[OPTION] with get, set
        abstract literal: LiteralTypeNode[OPTION] with get, set

    and JSDocTypeReferencingNode =
        obj

    and [<AllowNullLiteral>] JSDocRecordMember =
        inherit PropertySignature
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocRecordMember[OPTION] with get, set
        abstract name: U3<Identifier, StringLiteral, NumericLiteral>[OPTION] with get, set
        abstract ``type``: JSDocType option with get, set

    and [<AllowNullLiteral>] JSDoc =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocComment[OPTION] with get, set
        abstract tags: U2<NodeArray<JSDocTag>, obj>[OPTION] with get, set
        abstract comment: U2<string, obj>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTag =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract atToken: AtToken[OPTION] with get, set
        abstract tagName: Identifier[OPTION] with get, set
        abstract comment: U2<string, obj>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocUnknownTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTag[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocAugmentsTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocAugmentsTag[OPTION] with get, set
        abstract typeExpression: JSDocTypeExpression[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTemplateTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTemplateTag[OPTION] with get, set
        abstract typeParameters: NodeArray<TypeParameterDeclaration>[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocReturnTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocReturnTag[OPTION] with get, set
        abstract typeExpression: JSDocTypeExpression[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTypeTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTypeTag[OPTION] with get, set
        abstract typeExpression: JSDocTypeExpression[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTypedefTag =
        inherit JSDocTag
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTypedefTag[OPTION] with get, set
        abstract fullName: U2<JSDocNamespaceDeclaration, Identifier> option with get, set
        abstract name: Identifier option with get, set
        abstract typeExpression: JSDocTypeExpression option with get, set
        abstract jsDocTypeLiteral: JSDocTypeLiteral option with get, set

    and [<AllowNullLiteral>] JSDocPropertyTag =
        inherit JSDocTag
        inherit TypeElement
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocPropertyTag[OPTION] with get, set
        abstract name: Identifier[OPTION] with get, set
        abstract typeExpression: JSDocTypeExpression[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTypeLiteral =
        inherit JSDocType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocTypeLiteral[OPTION] with get, set
        abstract jsDocPropertyTags: NodeArray<JSDocPropertyTag> option with get, set
        abstract jsDocTypeTag: JSDocTypeTag option with get, set

    and [<AllowNullLiteral>] JSDocParameterTag =
        inherit JSDocTag
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.JSDocParameterTag[OPTION] with get, set
        abstract preParameterName: Identifier option with get, set
        abstract typeExpression: JSDocTypeExpression option with get, set
        abstract postParameterName: Identifier option with get, set
        abstract parameterName: Identifier[OPTION] with get, set
        abstract isBracketed: bool[OPTION] with get, set

    and FlowFlags =
        | Unreachable = 1
        | Start = 2
        | BranchLabel = 4
        | LoopLabel = 8
        | Assignment = 16
        | TrueCondition = 32
        | FalseCondition = 64
        | SwitchClause = 128
        | ArrayMutation = 256
        | Referenced = 512
        | Shared = 1024
        | Label = 12
        | Condition = 96

    and [<AllowNullLiteral>] FlowNode =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract flags: FlowFlags[OPTION] with get, set
        abstract id: float option with get, set

    and [<AllowNullLiteral>] FlowStart =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract container: U3<FunctionExpression, ArrowFunction, MethodDeclaration> option with get, set

    and [<AllowNullLiteral>] FlowLabel =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract antecedents: ResizeArray<FlowNode>[OPTION] with get, set

    and [<AllowNullLiteral>] FlowAssignment =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract node: U3<Expression, VariableDeclaration, BindingElement>[OPTION] with get, set
        abstract antecedent: FlowNode[OPTION] with get, set

    and [<AllowNullLiteral>] FlowCondition =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract expression: Expression[OPTION] with get, set
        abstract antecedent: FlowNode[OPTION] with get, set

    and [<AllowNullLiteral>] FlowSwitchClause =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract switchStatement: SwitchStatement[OPTION] with get, set
        abstract clauseStart: float[OPTION] with get, set
        abstract clauseEnd: float[OPTION] with get, set
        abstract antecedent: FlowNode[OPTION] with get, set

    and [<AllowNullLiteral>] FlowArrayMutation =
        inherit FlowNode
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract node: U2<CallExpression, BinaryExpression>[OPTION] with get, set
        abstract antecedent: FlowNode[OPTION] with get, set

    and FlowType =
        U2<Type, IncompleteType>

    and [<AllowNullLiteral>] IncompleteType =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract flags: TypeFlags[OPTION] with get, set
        abstract ``type``: Type[OPTION] with get, set

    and [<AllowNullLiteral>] AmdDependency =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract path: string[OPTION] with get, set
        abstract name: string[OPTION] with get, set

    and [<AllowNullLiteral>] SourceFile =
        inherit Declaration
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: SyntaxKind.SourceFile[OPTION] with get, set
        abstract statements: NodeArray<Statement>[OPTION] with get, set
        abstract endOfFileToken: Token<SyntaxKind.EndOfFileToken>[OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract path: Path[OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract amdDependencies: ResizeArray<AmdDependency>[OPTION] with get, set
        abstract moduleName: string[OPTION] with get, set
        abstract referencedFiles: ResizeArray<FileReference>[OPTION] with get, set
        abstract typeReferenceDirectives: ResizeArray<FileReference>[OPTION] with get, set
        abstract languageVariant: LanguageVariant[OPTION] with get, set
        abstract isDeclarationFile: bool[OPTION] with get, set
        abstract hasNoDefaultLib: bool[OPTION] with get, set
        abstract languageVersion: ScriptTarget[OPTION] with get, set
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getLineAndCharacterOfPosition: pos: float -> LineAndCharacter
        abstract getLineEndOfPosition: pos: float -> float
        abstract getLineStarts: unit -> ResizeArray<float>
        abstract getPositionOfLineAndCharacter: line: float * character: float -> float
        abstract update: newText: string * textChangeRange: TextChangeRange -> SourceFile

    and [<AllowNullLiteral>] ScriptReferenceHost =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getCompilerOptions: unit -> CompilerOptions
        abstract getSourceFile: fileName: string -> SourceFile
        abstract getSourceFileByPath: path: Path -> SourceFile
        abstract getCurrentDirectory: unit -> string

    and [<AllowNullLiteral>] ParseConfigHost =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract useCaseSensitiveFileNames: bool[OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract readDirectory: rootDir: string * extensions: ResizeArray<string> * excludes: ResizeArray<string> * includes: ResizeArray<string> -> ResizeArray<string>
        abstract fileExists: path: string -> bool
        abstract readFile: path: string -> string

    and [<AllowNullLiteral>] WriteFileCallback =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        [<Emit("$0($1...)")>] abstract Invoke: fileName: string * data: string * writeByteOrderMark: bool * ?onError: Func<string, unit> * ?sourceFiles: ResizeArray<SourceFile> -> unit

    and [<AllowNullLiteral>] [<Import("OperationCanceledException","ts")>] OperationCanceledException() =
        class end

    and [<AllowNullLiteral>] CancellationToken =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract isCancellationRequested: unit -> bool
        abstract throwIfCancellationRequested: unit -> unit

    and [<AllowNullLiteral>] Program =
        inherit ScriptReferenceHost
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getRootFileNames: unit -> ResizeArray<string>
        abstract getSourceFiles: unit -> ResizeArray<SourceFile>
        abstract emit: ?targetSourceFile: SourceFile * ?writeFile: WriteFileCallback * ?cancellationToken: CancellationToken * ?emitOnlyDtsFiles: bool -> EmitResult
        abstract getOptionsDiagnostics: ?cancellationToken: CancellationToken -> ResizeArray<Diagnostic>
        abstract getGlobalDiagnostics: ?cancellationToken: CancellationToken -> ResizeArray<Diagnostic>
        abstract getSyntacticDiagnostics: ?sourceFile: SourceFile * ?cancellationToken: CancellationToken -> ResizeArray<Diagnostic>
        abstract getSemanticDiagnostics: ?sourceFile: SourceFile * ?cancellationToken: CancellationToken -> ResizeArray<Diagnostic>
        abstract getDeclarationDiagnostics: ?sourceFile: SourceFile * ?cancellationToken: CancellationToken -> ResizeArray<Diagnostic>
        abstract getTypeChecker: unit -> TypeChecker

    and [<AllowNullLiteral>] SourceMapSpan =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract emittedLine: float[OPTION] with get, set
        abstract emittedColumn: float[OPTION] with get, set
        abstract sourceLine: float[OPTION] with get, set
        abstract sourceColumn: float[OPTION] with get, set
        abstract nameIndex: float option with get, set
        abstract sourceIndex: float[OPTION] with get, set

    and [<AllowNullLiteral>] SourceMapData =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract sourceMapFilePath: string[OPTION] with get, set
        abstract jsSourceMappingURL: string[OPTION] with get, set
        abstract sourceMapFile: string[OPTION] with get, set
        abstract sourceMapSourceRoot: string[OPTION] with get, set
        abstract sourceMapSources: ResizeArray<string>[OPTION] with get, set
        abstract sourceMapSourcesContent: ResizeArray<string> option with get, set
        abstract inputSourceFileNames: ResizeArray<string>[OPTION] with get, set
        abstract sourceMapNames: ResizeArray<string> option with get, set
        abstract sourceMapMappings: string[OPTION] with get, set
        abstract sourceMapDecodedMappings: ResizeArray<SourceMapSpan>[OPTION] with get, set

    and ExitStatus =
        | Success = 0
        | DiagnosticsPresent_OutputsSkipped = 1
        | DiagnosticsPresent_OutputsGenerated = 2

    and [<AllowNullLiteral>] EmitResult =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract emitSkipped: bool[OPTION] with get, set
        abstract diagnostics: ResizeArray<Diagnostic>[OPTION] with get, set
        abstract emittedFiles: ResizeArray<string>[OPTION] with get, set

    and [<AllowNullLiteral>] TypeChecker =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getTypeOfSymbolAtLocation: symbol: Symbol * node: Node -> Type
        abstract getDeclaredTypeOfSymbol: symbol: Symbol -> Type
        abstract getPropertiesOfType: ``type``: Type -> ResizeArray<Symbol>
        abstract getPropertyOfType: ``type``: Type * propertyName: string -> Symbol
        abstract getSignaturesOfType: ``type``: Type * kind: SignatureKind -> ResizeArray<Signature>
        abstract getIndexTypeOfType: ``type``: Type * kind: IndexKind -> Type
        abstract getBaseTypes: ``type``: InterfaceType -> ResizeArray<ObjectType>
        abstract getReturnTypeOfSignature: signature: Signature -> Type
        abstract getNonNullableType: ``type``: Type -> Type
        abstract getSymbolsInScope: location: Node * meaning: SymbolFlags -> ResizeArray<Symbol>
        abstract getSymbolAtLocation: node: Node -> Symbol
        abstract getSymbolsOfParameterPropertyDeclaration: parameter: ParameterDeclaration * parameterName: string -> ResizeArray<Symbol>
        abstract getShorthandAssignmentValueSymbol: location: Node -> Symbol
        abstract getExportSpecifierLocalTargetSymbol: location: ExportSpecifier -> Symbol
        abstract getPropertySymbolOfDestructuringAssignment: location: Identifier -> Symbol
        abstract getTypeAtLocation: node: Node -> Type
        abstract typeToString: ``type``: Type * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> string
        abstract symbolToString: symbol: Symbol * ?enclosingDeclaration: Node * ?meaning: SymbolFlags -> string
        abstract getSymbolDisplayBuilder: unit -> SymbolDisplayBuilder
        abstract getFullyQualifiedName: symbol: Symbol -> string
        abstract getAugmentedPropertiesOfType: ``type``: Type -> ResizeArray<Symbol>
        abstract getRootSymbols: symbol: Symbol -> ResizeArray<Symbol>
        abstract getContextualType: node: Expression -> Type
        abstract getResolvedSignature: node: CallLikeExpression * ?candidatesOutArray: ResizeArray<Signature> -> Signature
        abstract getSignatureFromDeclaration: declaration: SignatureDeclaration -> Signature
        abstract isImplementationOfOverload: node: FunctionLikeDeclaration -> bool
        abstract isUndefinedSymbol: symbol: Symbol -> bool
        abstract isArgumentsSymbol: symbol: Symbol -> bool
        abstract isUnknownSymbol: symbol: Symbol -> bool
        abstract getConstantValue: node: U3<EnumMember, PropertyAccessExpression, ElementAccessExpression> -> float
        abstract isValidPropertyAccess: node: U2<PropertyAccessExpression, QualifiedName> * propertyName: string -> bool
        abstract getAliasedSymbol: symbol: Symbol -> Symbol
        abstract getExportsOfModule: moduleSymbol: Symbol -> ResizeArray<Symbol>
        abstract getJsxElementAttributesType: elementNode: JsxOpeningLikeElement -> Type
        abstract getJsxIntrinsicTagNames: unit -> ResizeArray<Symbol>
        abstract isOptionalParameter: node: ParameterDeclaration -> bool
        abstract getAmbientModules: unit -> ResizeArray<Symbol>
        abstract tryGetMemberInModuleExports: memberName: string * moduleSymbol: Symbol -> U2<Symbol, obj>

    and [<AllowNullLiteral>] SymbolDisplayBuilder =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract buildTypeDisplay: ``type``: Type * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildSymbolDisplay: symbol: Symbol * writer: SymbolWriter * ?enclosingDeclaration: Node * ?meaning: SymbolFlags * ?flags: SymbolFormatFlags -> unit
        abstract buildSignatureDisplay: signatures: Signature * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags * ?kind: SignatureKind -> unit
        abstract buildParameterDisplay: parameter: Symbol * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildTypeParameterDisplay: tp: TypeParameter * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildTypePredicateDisplay: predicate: TypePredicate * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildTypeParameterDisplayFromSymbol: symbol: Symbol * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildDisplayForParametersAndDelimiters: thisParameter: Symbol * parameters: ResizeArray<Symbol> * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildDisplayForTypeParametersAndDelimiters: typeParameters: ResizeArray<TypeParameter> * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit
        abstract buildReturnTypeDisplay: signature: Signature * writer: SymbolWriter * ?enclosingDeclaration: Node * ?flags: TypeFormatFlags -> unit

    and [<AllowNullLiteral>] SymbolWriter =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract writeKeyword: text: string -> unit
        abstract writeOperator: text: string -> unit
        abstract writePunctuation: text: string -> unit
        abstract writeSpace: text: string -> unit
        abstract writeStringLiteral: text: string -> unit
        abstract writeParameter: text: string -> unit
        abstract writeProperty: text: string -> unit
        abstract writeSymbol: text: string * symbol: Symbol -> unit
        abstract writeLine: unit -> unit
        abstract increaseIndent: unit -> unit
        abstract decreaseIndent: unit -> unit
        abstract clear: unit -> unit
        abstract trackSymbol: symbol: Symbol * ?enclosingDeclaration: Node * ?meaning: SymbolFlags -> unit
        abstract reportInaccessibleThisError: unit -> unit

    and TypeFormatFlags =
        | None = 0
        | WriteArrayAsGenericType = 1
        | UseTypeOfFunction = 2
        | NoTruncation = 4
        | WriteArrowStyleSignature = 8
        | WriteOwnNameForAnyLike = 16
        | WriteTypeArgumentsOfSignature = 32
        | InElementType = 64
        | UseFullyQualifiedType = 128
        | InFirstTypeArgument = 256
        | InTypeAlias = 512
        | UseTypeAliasValue = 1024

    and SymbolFormatFlags =
        | None = 0
        | WriteTypeParametersOrArguments = 1
        | UseOnlyExternalAliasing = 2

    and TypePredicateKind =
        | This = 0
        | Identifier = 1

    and [<AllowNullLiteral>] TypePredicateBase =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: TypePredicateKind[OPTION] with get, set
        abstract ``type``: Type[OPTION] with get, set

    and [<AllowNullLiteral>] ThisTypePredicate =
        inherit TypePredicateBase
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: TypePredicateKind.This[OPTION] with get, set

    and [<AllowNullLiteral>] IdentifierTypePredicate =
        inherit TypePredicateBase
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: TypePredicateKind.Identifier[OPTION] with get, set
        abstract parameterName: string[OPTION] with get, set
        abstract parameterIndex: float[OPTION] with get, set

    and TypePredicate =
        U2<IdentifierTypePredicate, ThisTypePredicate>

    and SymbolFlags =
        | None = 0
        | FunctionScopedVariable = 1
        | BlockScopedVariable = 2
        | Property = 4
        | EnumMember = 8
        | Function = 16
        | Class = 32
        | Interface = 64
        | ConstEnum = 128
        | RegularEnum = 256
        | ValueModule = 512
        | NamespaceModule = 1024
        | TypeLiteral = 2048
        | ObjectLiteral = 4096
        | Method = 8192
        | Constructor = 16384
        | GetAccessor = 32768
        | SetAccessor = 65536
        | Signature = 131072
        | TypeParameter = 262144
        | TypeAlias = 524288
        | ExportValue = 1048576
        | ExportType = 2097152
        | ExportNamespace = 4194304
        | Alias = 8388608
        | Instantiated = 16777216
        | Merged = 33554432
        | Transient = 67108864
        | Prototype = 134217728
        | SyntheticProperty = 268435456
        | Optional = 536870912
        | ExportStar = 1073741824
        | Enum = 384
        | Variable = 3
        | Value = 107455
        | Type = 793064
        | Namespace = 1920
        | Module = 1536
        | Accessor = 98304
        | FunctionScopedVariableExcludes = 107454
        | BlockScopedVariableExcludes = 107455
        | ParameterExcludes = 107455
        | PropertyExcludes = 0
        | EnumMemberExcludes = 900095
        | FunctionExcludes = 106927
        | ClassExcludes = 899519
        | InterfaceExcludes = 792968
        | RegularEnumExcludes = 899327
        | ConstEnumExcludes = 899967
        | ValueModuleExcludes = 106639
        | NamespaceModuleExcludes = 0
        | MethodExcludes = 99263
        | GetAccessorExcludes = 41919
        | SetAccessorExcludes = 74687
        | TypeParameterExcludes = 530920
        | TypeAliasExcludes = 793064
        | AliasExcludes = 8388608
        | ModuleMember = 8914931
        | ExportHasLocal = 944
        | HasExports = 1952
        | HasMembers = 6240
        | BlockScoped = 418
        | PropertyOrAccessor = 98308
        | Export = 7340032
        | ClassMember = 106500

    and [<AllowNullLiteral>] Symbol =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract flags: SymbolFlags[OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract declarations: ResizeArray<Declaration> option with get, set
        abstract valueDeclaration: Declaration option with get, set
        abstract members: SymbolTable option with get, set
        abstract exports: SymbolTable option with get, set
        abstract globalExports: SymbolTable option with get, set
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getFlags: unit -> SymbolFlags
        abstract getName: unit -> string
        abstract getDeclarations: unit -> ResizeArray<Declaration>
        abstract getDocumentationComment: unit -> ResizeArray<SymbolDisplayPart>
        abstract getJsDocTags: unit -> ResizeArray<JSDocTagInfo>

    and SymbolTable =
        Map<Symbol>

    and TypeFlags =
        | Any = 1
        | String = 2
        | Number = 4
        | Boolean = 8
        | Enum = 16
        | StringLiteral = 32
        | NumberLiteral = 64
        | BooleanLiteral = 128
        | EnumLiteral = 256
        | ESSymbol = 512
        | Void = 1024
        | Undefined = 2048
        | Null = 4096
        | Never = 8192
        | TypeParameter = 16384
        | Object = 32768
        | Union = 65536
        | Intersection = 131072
        | Index = 262144
        | IndexedAccess = 524288
        | Literal = 480
        | StringOrNumberLiteral = 96
        | PossiblyFalsy = 7406
        | StringLike = 262178
        | NumberLike = 340
        | BooleanLike = 136
        | EnumLike = 272
        | UnionOrIntersection = 196608
        | StructuredType = 229376
        | StructuredOrTypeParameter = 507904
        | TypeVariable = 540672
        | Narrowable = 1033215
        | NotUnionOrUnit = 33281

    and DestructuringPattern =
        U3<BindingPattern, ObjectLiteralExpression, ArrayLiteralExpression>

    and [<AllowNullLiteral>] Type =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract flags: TypeFlags[OPTION] with get, set
        abstract symbol: Symbol option with get, set
        abstract pattern: DestructuringPattern option with get, set
        abstract aliasSymbol: Symbol option with get, set
        abstract aliasTypeArguments: ResizeArray<Type> option with get, set
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getFlags: unit -> TypeFlags
        abstract getSymbol: unit -> Symbol
        abstract getProperties: unit -> ResizeArray<Symbol>
        abstract getProperty: propertyName: string -> Symbol
        abstract getApparentProperties: unit -> ResizeArray<Symbol>
        abstract getCallSignatures: unit -> ResizeArray<Signature>
        abstract getConstructSignatures: unit -> ResizeArray<Signature>
        abstract getStringIndexType: unit -> Type
        abstract getNumberIndexType: unit -> Type
        abstract getBaseTypes: unit -> ResizeArray<ObjectType>
        abstract getNonNullableType: unit -> Type

    and [<AllowNullLiteral>] LiteralType =
        inherit Type
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract freshType: LiteralType option with get, set
        abstract regularType: LiteralType option with get, set

    and [<AllowNullLiteral>] EnumType =
        inherit Type
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract memberTypes: Map<EnumLiteralType>[OPTION] with get, set

    and [<AllowNullLiteral>] EnumLiteralType =
        inherit LiteralType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract baseType: obj[OPTION] with get, set

    and ObjectFlags =
        | Class = 1
        | Interface = 2
        | Reference = 4
        | Tuple = 8
        | Anonymous = 16
        | Mapped = 32
        | Instantiated = 64
        | ObjectLiteral = 128
        | EvolvingArray = 256
        | ObjectLiteralPatternWithComputedProperties = 512
        | ClassOrInterface = 3

    and [<AllowNullLiteral>] ObjectType =
        inherit Type
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract objectFlags: ObjectFlags[OPTION] with get, set

    and [<AllowNullLiteral>] InterfaceType =
        inherit ObjectType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract typeParameters: ResizeArray<TypeParameter>[OPTION] with get, set
        abstract outerTypeParameters: ResizeArray<TypeParameter>[OPTION] with get, set
        abstract localTypeParameters: ResizeArray<TypeParameter>[OPTION] with get, set
        abstract thisType: TypeParameter[OPTION] with get, set

    and [<AllowNullLiteral>] InterfaceTypeWithDeclaredMembers =
        inherit InterfaceType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract declaredProperties: ResizeArray<Symbol>[OPTION] with get, set
        abstract declaredCallSignatures: ResizeArray<Signature>[OPTION] with get, set
        abstract declaredConstructSignatures: ResizeArray<Signature>[OPTION] with get, set
        abstract declaredStringIndexInfo: IndexInfo[OPTION] with get, set
        abstract declaredNumberIndexInfo: IndexInfo[OPTION] with get, set

    and [<AllowNullLiteral>] TypeReference =
        inherit ObjectType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract target: GenericType[OPTION] with get, set
        abstract typeArguments: ResizeArray<Type>[OPTION] with get, set

    and [<AllowNullLiteral>] GenericType =
        inherit InterfaceType
        inherit TypeReference


    and [<AllowNullLiteral>] UnionOrIntersectionType =
        inherit Type
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract types: ResizeArray<Type>[OPTION] with get, set

    and [<AllowNullLiteral>] UnionType =
        inherit UnionOrIntersectionType


    and [<AllowNullLiteral>] IntersectionType =
        inherit UnionOrIntersectionType


    and StructuredType =
        U3<ObjectType, UnionType, IntersectionType>

    and [<AllowNullLiteral>] EvolvingArrayType =
        inherit ObjectType
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract elementType: Type[OPTION] with get, set
        abstract finalArrayType: Type option with get, set

    and [<AllowNullLiteral>] TypeVariable =
        inherit Type


    and [<AllowNullLiteral>] TypeParameter =
        inherit TypeVariable
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract ``constraint``: Type[OPTION] with get, set

    and [<AllowNullLiteral>] IndexedAccessType =
        inherit TypeVariable
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract objectType: Type[OPTION] with get, set
        abstract indexType: Type[OPTION] with get, set
        abstract ``constraint``: Type option with get, set

    and [<AllowNullLiteral>] IndexType =
        inherit Type
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract ``type``: U2<TypeVariable, UnionOrIntersectionType>[OPTION] with get, set

    and SignatureKind =
        | Call = 0
        | Construct = 1

    and [<AllowNullLiteral>] Signature =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract declaration: SignatureDeclaration[OPTION] with get, set
        abstract typeParameters: ResizeArray<TypeParameter>[OPTION] with get, set
        abstract parameters: ResizeArray<Symbol>[OPTION] with get, set
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getDeclaration: unit -> SignatureDeclaration
        abstract getTypeParameters: unit -> ResizeArray<Type>
        abstract getParameters: unit -> ResizeArray<Symbol>
        abstract getReturnType: unit -> Type
        abstract getDocumentationComment: unit -> ResizeArray<SymbolDisplayPart>
        abstract getJsDocTags: unit -> ResizeArray<JSDocTagInfo>

    and IndexKind =
        | String = 0
        | Number = 1

    and [<AllowNullLiteral>] IndexInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract ``type``: Type[OPTION] with get, set
        abstract isReadonly: bool[OPTION] with get, set
        abstract declaration: SignatureDeclaration option with get, set

    and [<AllowNullLiteral>] FileExtensionInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract extension: string[OPTION] with get, set
        abstract scriptKind: ScriptKind[OPTION] with get, set
        abstract isMixedContent: bool[OPTION] with get, set

    and [<AllowNullLiteral>] DiagnosticMessage =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract key: string[OPTION] with get, set
        abstract category: DiagnosticCategory[OPTION] with get, set
        abstract code: float[OPTION] with get, set
        abstract message: string[OPTION] with get, set

    and [<AllowNullLiteral>] DiagnosticMessageChain =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract messageText: string[OPTION] with get, set
        abstract category: DiagnosticCategory[OPTION] with get, set
        abstract code: float[OPTION] with get, set
        abstract next: DiagnosticMessageChain option with get, set

    and [<AllowNullLiteral>] Diagnostic =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract file: SourceFile[OPTION] with get, set
        abstract start: float[OPTION] with get, set
        abstract length: float[OPTION] with get, set
        abstract messageText: U2<string, DiagnosticMessageChain>[OPTION] with get, set
        abstract category: DiagnosticCategory[OPTION] with get, set
        abstract code: float[OPTION] with get, set

    and DiagnosticCategory =
        | Warning = 0
        | Error = 1
        | Message = 2

    and ModuleResolutionKind =
        | Classic = 1
        | NodeJs = 2

    and CompilerOptionsValue =
        obj

    and [<AllowNullLiteral>] CompilerOptions =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract allowJs: bool option with get, set
        abstract allowSyntheticDefaultImports: bool option with get, set
        abstract allowUnreachableCode: bool option with get, set
        abstract allowUnusedLabels: bool option with get, set
        abstract alwaysStrict: bool option with get, set
        abstract baseUrl: string option with get, set
        abstract charset: string option with get, set
        abstract declaration: bool option with get, set
        abstract declarationDir: string option with get, set
        abstract disableSizeLimit: bool option with get, set
        abstract emitBOM: bool option with get, set
        abstract emitDecoratorMetadata: bool option with get, set
        abstract experimentalDecorators: bool option with get, set
        abstract forceConsistentCasingInFileNames: bool option with get, set
        abstract importHelpers: bool option with get, set
        abstract inlineSourceMap: bool option with get, set
        abstract inlineSources: bool option with get, set
        abstract isolatedModules: bool option with get, set
        abstract jsx: JsxEmit option with get, set
        abstract lib: ResizeArray<string> option with get, set
        abstract locale: string option with get, set
        abstract mapRoot: string option with get, set
        abstract maxNodeModuleJsDepth: float option with get, set
        abstract ``module``: ModuleKind option with get, set
        abstract moduleResolution: ModuleResolutionKind option with get, set
        abstract newLine: NewLineKind option with get, set
        abstract noEmit: bool option with get, set
        abstract noEmitHelpers: bool option with get, set
        abstract noEmitOnError: bool option with get, set
        abstract noErrorTruncation: bool option with get, set
        abstract noFallthroughCasesInSwitch: bool option with get, set
        abstract noImplicitAny: bool option with get, set
        abstract noImplicitReturns: bool option with get, set
        abstract noImplicitThis: bool option with get, set
        abstract noUnusedLocals: bool option with get, set
        abstract noUnusedParameters: bool option with get, set
        abstract noImplicitUseStrict: bool option with get, set
        abstract noLib: bool option with get, set
        abstract noResolve: bool option with get, set
        abstract out: string option with get, set
        abstract outDir: string option with get, set
        abstract outFile: string option with get, set
        abstract paths: MapLike<ResizeArray<string>> option with get, set
        abstract preserveConstEnums: bool option with get, set
        abstract project: string option with get, set
        abstract reactNamespace: string option with get, set
        abstract jsxFactory: string option with get, set
        abstract removeComments: bool option with get, set
        abstract rootDir: string option with get, set
        abstract rootDirs: ResizeArray<string> option with get, set
        abstract skipLibCheck: bool option with get, set
        abstract skipDefaultLibCheck: bool option with get, set
        abstract sourceMap: bool option with get, set
        abstract sourceRoot: string option with get, set
        abstract strictNullChecks: bool option with get, set
        abstract suppressExcessPropertyErrors: bool option with get, set
        abstract suppressImplicitAnyIndexErrors: bool option with get, set
        abstract target: ScriptTarget option with get, set
        abstract traceResolution: bool option with get, set
        abstract types: ResizeArray<string> option with get, set
        abstract typeRoots: ResizeArray<string> option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: option: string -> U2<CompilerOptionsValue, obj>[OPTION] with get, set

    and [<AllowNullLiteral>] TypeAcquisition =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract enableAutoDiscovery: bool option with get, set
        abstract enable: bool option with get, set
        abstract ``include``: ResizeArray<string> option with get, set
        abstract exclude: ResizeArray<string> option with get, set
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: option: string -> U3<ResizeArray<string>, bool, obj>[OPTION] with get, set

    and [<AllowNullLiteral>] DiscoverTypingsInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileNames: ResizeArray<string>[OPTION] with get, set
        abstract projectRootPath: string[OPTION] with get, set
        abstract safeListPath: string[OPTION] with get, set
        abstract packageNameToTypingLocation: Map<string>[OPTION] with get, set
        abstract typeAcquisition: TypeAcquisition[OPTION] with get, set
        abstract compilerOptions: CompilerOptions[OPTION] with get, set
        abstract unresolvedImports: ReadonlyArray<string>[OPTION] with get, set

    and ModuleKind =
        | None = 0
        | CommonJS = 1
        | AMD = 2
        | UMD = 3
        | System = 4
        | ES2015 = 5

    and JsxEmit =
        | None = 0
        | Preserve = 1
        | React = 2

    and NewLineKind =
        | CarriageReturnLineFeed = 0
        | LineFeed = 1

    and [<AllowNullLiteral>] LineAndCharacter =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract line: float[OPTION] with get, set
        abstract character: float[OPTION] with get, set

    and ScriptKind =
        | Unknown = 0
        | JS = 1
        | JSX = 2
        | TS = 3
        | TSX = 4

    and ScriptTarget =
        | ES3 = 0
        | ES5 = 1
        | ES2015 = 2
        | ES2016 = 3
        | ES2017 = 4
        | ESNext = 5
        | Latest = 5

    and LanguageVariant =
        | Standard = 0
        | JSX = 1

    and [<AllowNullLiteral>] ParsedCommandLine =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract options: CompilerOptions[OPTION] with get, set
        abstract typeAcquisition: TypeAcquisition option with get, set
        abstract fileNames: ResizeArray<string>[OPTION] with get, set
        abstract raw: obj option with get, set
        abstract errors: ResizeArray<Diagnostic>[OPTION] with get, set
        abstract wildcardDirectories: MapLike<WatchDirectoryFlags> option with get, set
        abstract compileOnSave: bool option with get, set

    and WatchDirectoryFlags =
        | None = 0
        | Recursive = 1

    and [<AllowNullLiteral>] ExpandResult =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileNames: ResizeArray<string>[OPTION] with get, set
        abstract wildcardDirectories: MapLike<WatchDirectoryFlags>[OPTION] with get, set

    and [<AllowNullLiteral>] ModuleResolutionHost =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract fileExists: fileName: string -> bool
        abstract readFile: fileName: string -> string
        abstract trace: s: string -> unit
        abstract directoryExists: directoryName: string -> bool
        abstract realpath: path: string -> string
        abstract getCurrentDirectory: unit -> string
        abstract getDirectories: path: string -> ResizeArray<string>

    and [<AllowNullLiteral>] ResolvedModule =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract resolvedFileName: string[OPTION] with get, set
        abstract isExternalLibraryImport: bool option with get, set

    and [<AllowNullLiteral>] ResolvedModuleFull =
        inherit ResolvedModule
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract extension: Extension[OPTION] with get, set

    and Extension =
        | Ts = 0
        | Tsx = 1
        | Dts = 2
        | Js = 3
        | Jsx = 4
        | LastTypeScriptExtension = 2

    and [<AllowNullLiteral>] ResolvedModuleWithFailedLookupLocations =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract resolvedModule: U2<ResolvedModuleFull, obj>[OPTION] with get, set
        abstract failedLookupLocations: ResizeArray<string>[OPTION] with get, set

    and [<AllowNullLiteral>] ResolvedTypeReferenceDirective =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract primary: bool[OPTION] with get, set
        abstract resolvedFileName: string option with get, set

    and [<AllowNullLiteral>] ResolvedTypeReferenceDirectiveWithFailedLookupLocations =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract resolvedTypeReferenceDirective: ResolvedTypeReferenceDirective[OPTION] with get, set
        abstract failedLookupLocations: ResizeArray<string>[OPTION] with get, set

    and [<AllowNullLiteral>] CompilerHost =
        inherit ModuleResolutionHost
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract writeFile: WriteFileCallback[OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getSourceFile: fileName: string * languageVersion: ScriptTarget * ?onError: Func<string, unit> -> SourceFile
        abstract getSourceFileByPath: fileName: string * path: Path * languageVersion: ScriptTarget * ?onError: Func<string, unit> -> SourceFile
        abstract getCancellationToken: unit -> CancellationToken
        abstract getDefaultLibFileName: options: CompilerOptions -> string
        abstract getDefaultLibLocation: unit -> string
        abstract getCurrentDirectory: unit -> string
        abstract getDirectories: path: string -> ResizeArray<string>
        abstract getCanonicalFileName: fileName: string -> string
        abstract useCaseSensitiveFileNames: unit -> bool
        abstract getNewLine: unit -> string
        abstract resolveModuleNames: moduleNames: ResizeArray<string> * containingFile: string -> ResizeArray<ResolvedModule>
        abstract resolveTypeReferenceDirectives: typeReferenceDirectiveNames: ResizeArray<string> * containingFile: string -> ResizeArray<ResolvedTypeReferenceDirective>
        abstract getEnvironmentVariable: name: string -> string

    and [<AllowNullLiteral>] TextSpan =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract start: float[OPTION] with get, set
        abstract length: float[OPTION] with get, set

    and [<AllowNullLiteral>] TextChangeRange =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract span: TextSpan[OPTION] with get, set
        abstract newLength: float[OPTION] with get, set

    and [<AllowNullLiteral>] SyntaxList =
        inherit Node
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract _children: ResizeArray<Node>[OPTION] with get, set

    and FileWatcherCallback =
        Func<string, bool, unit>

    and DirectoryWatcherCallback =
        Func<string, unit>

    and [<AllowNullLiteral>] WatchedFile =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract callback: FileWatcherCallback[OPTION] with get, set
        abstract mtime: DateTime option with get, set

    and [<AllowNullLiteral>] System =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract args: ResizeArray<string>[OPTION] with get, set
        abstract newLine: string[OPTION] with get, set
        abstract useCaseSensitiveFileNames: bool[OPTION] with get, set
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract write: s: string -> unit
        abstract readFile: path: string * ?encoding: string -> string
        abstract getFileSize: path: string -> float
        abstract writeFile: path: string * data: string * ?writeByteOrderMark: bool -> unit
        abstract watchFile: path: string * callback: FileWatcherCallback * ?pollingInterval: float -> FileWatcher
        abstract watchDirectory: path: string * callback: DirectoryWatcherCallback * ?recursive: bool -> FileWatcher
        abstract resolvePath: path: string -> string
        abstract fileExists: path: string -> bool
        abstract directoryExists: path: string -> bool
        abstract createDirectory: path: string -> unit
        abstract getExecutingFilePath: unit -> string
        abstract getCurrentDirectory: unit -> string
        abstract getDirectories: path: string -> ResizeArray<string>
        abstract readDirectory: path: string * ?extensions: ResizeArray<string> * ?exclude: ResizeArray<string> * ?``include``: ResizeArray<string> -> ResizeArray<string>
        abstract getModifiedTime: path: string -> DateTime
        abstract createHash: data: string -> string
        abstract getMemoryUsage: unit -> float
        abstract exit: ?exitCode: float -> unit
        abstract realpath: path: string -> string
        abstract setTimeout: callback: Func<obj, unit> * ms: float * [<ParamArray>] args: obj[] -> obj
        abstract clearTimeout: timeoutId: obj -> unit

    and [<AllowNullLiteral>] FileWatcher =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract close: unit -> unit

    and [<AllowNullLiteral>] DirectoryWatcher =
        inherit FileWatcher
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract directoryName: string[OPTION] with get, set
        abstract referenceCount: float[OPTION] with get, set

    and [<AllowNullLiteral>] ErrorCallback =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        [<Emit("$0($1...)")>] abstract Invoke: message: DiagnosticMessage * length: float -> unit

    and [<AllowNullLiteral>] Scanner =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getStartPos: unit -> float
        abstract getToken: unit -> SyntaxKind
        abstract getTextPos: unit -> float
        abstract getTokenPos: unit -> float
        abstract getTokenText: unit -> string
        abstract getTokenValue: unit -> string
        abstract hasExtendedUnicodeEscape: unit -> bool
        abstract hasPrecedingLineBreak: unit -> bool
        abstract isIdentifier: unit -> bool
        abstract isReservedWord: unit -> bool
        abstract isUnterminated: unit -> bool
        abstract reScanGreaterToken: unit -> SyntaxKind
        abstract reScanSlashToken: unit -> SyntaxKind
        abstract reScanTemplateToken: unit -> SyntaxKind
        abstract scanJsxIdentifier: unit -> SyntaxKind
        abstract scanJsxAttributeValue: unit -> SyntaxKind
        abstract reScanJsxToken: unit -> SyntaxKind
        abstract scanJsxToken: unit -> SyntaxKind
        abstract scanJSDocToken: unit -> SyntaxKind
        abstract scan: unit -> SyntaxKind
        abstract getText: unit -> string
        abstract setText: text: string * ?start: float * ?length: float -> unit
        abstract setOnError: onError: ErrorCallback -> unit
        abstract setScriptTarget: scriptTarget: ScriptTarget -> unit
        abstract setLanguageVariant: variant: LanguageVariant -> unit
        abstract setTextPos: textPos: float -> unit
        abstract lookAhead: callback: Func<unit, 'T> -> 'T
        abstract scanRange: start: float * length: float * callback: Func<unit, 'T> -> 'T
        abstract tryScan: callback: Func<unit, 'T> -> 'T

    and [<AllowNullLiteral>] ModuleResolutionCache =
        inherit NonRelativeModuleNameResolutionCache
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getOrCreateCacheForDirectory: directoryName: string -> Map<ResolvedModuleWithFailedLookupLocations>

    and [<AllowNullLiteral>] NonRelativeModuleNameResolutionCache =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getOrCreateCacheForModuleName: nonRelativeModuleName: string -> PerModuleNameCache

    and [<AllowNullLiteral>] PerModuleNameCache =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract get: directory: string -> ResolvedModuleWithFailedLookupLocations
        abstract set: directory: string * result: ResolvedModuleWithFailedLookupLocations -> unit

    and [<AllowNullLiteral>] FormatDiagnosticsHost =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getCurrentDirectory: unit -> string
        abstract getCanonicalFileName: fileName: string -> string
        abstract getNewLine: unit -> string

    and [<AllowNullLiteral>] IScriptSnapshot =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getText: start: float * ``end``: float -> string
        abstract getLength: unit -> float
        abstract getChangeRange: oldSnapshot: IScriptSnapshot -> U2<TextChangeRange, obj>
        abstract dispose: unit -> unit

    and [<AllowNullLiteral>] PreProcessedFileInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract referencedFiles: ResizeArray<FileReference>[OPTION] with get, set
        abstract typeReferenceDirectives: ResizeArray<FileReference>[OPTION] with get, set
        abstract importedFiles: ResizeArray<FileReference>[OPTION] with get, set
        abstract ambientExternalModules: ResizeArray<string>[OPTION] with get, set
        abstract isLibFile: bool[OPTION] with get, set

    and [<AllowNullLiteral>] HostCancellationToken =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract isCancellationRequested: unit -> bool

    and [<AllowNullLiteral>] LanguageServiceHost =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getCompilationSettings: unit -> CompilerOptions
        abstract getNewLine: unit -> string
        abstract getProjectVersion: unit -> string
        abstract getScriptFileNames: unit -> ResizeArray<string>
        abstract getScriptKind: fileName: string -> ScriptKind
        abstract getScriptVersion: fileName: string -> string
        abstract getScriptSnapshot: fileName: string -> U2<IScriptSnapshot, obj>
        abstract getLocalizedDiagnosticMessages: unit -> obj
        abstract getCancellationToken: unit -> HostCancellationToken
        abstract getCurrentDirectory: unit -> string
        abstract getDefaultLibFileName: options: CompilerOptions -> string
        abstract log: s: string -> unit
        abstract trace: s: string -> unit
        abstract error: s: string -> unit
        abstract useCaseSensitiveFileNames: unit -> bool
        abstract readDirectory: path: string * ?extensions: ResizeArray<string> * ?exclude: ResizeArray<string> * ?``include``: ResizeArray<string> -> ResizeArray<string>
        abstract readFile: path: string * ?encoding: string -> string
        abstract fileExists: path: string -> bool
        abstract getTypeRootsVersion: unit -> float
        abstract resolveModuleNames: moduleNames: ResizeArray<string> * containingFile: string -> ResizeArray<ResolvedModule>
        abstract resolveTypeReferenceDirectives: typeDirectiveNames: ResizeArray<string> * containingFile: string -> ResizeArray<ResolvedTypeReferenceDirective>
        abstract directoryExists: directoryName: string -> bool
        abstract getDirectories: directoryName: string -> ResizeArray<string>

    and [<AllowNullLiteral>] LanguageService =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract cleanupSemanticCache: unit -> unit
        abstract getSyntacticDiagnostics: fileName: string -> ResizeArray<Diagnostic>
        abstract getSemanticDiagnostics: fileName: string -> ResizeArray<Diagnostic>
        abstract getCompilerOptionsDiagnostics: unit -> ResizeArray<Diagnostic>
        abstract getSyntacticClassifications: fileName: string * span: TextSpan -> ResizeArray<ClassifiedSpan>
        abstract getSemanticClassifications: fileName: string * span: TextSpan -> ResizeArray<ClassifiedSpan>
        abstract getEncodedSyntacticClassifications: fileName: string * span: TextSpan -> Classifications
        abstract getEncodedSemanticClassifications: fileName: string * span: TextSpan -> Classifications
        abstract getCompletionsAtPosition: fileName: string * position: float -> CompletionInfo
        abstract getCompletionEntryDetails: fileName: string * position: float * entryName: string -> CompletionEntryDetails
        abstract getCompletionEntrySymbol: fileName: string * position: float * entryName: string -> Symbol
        abstract getQuickInfoAtPosition: fileName: string * position: float -> QuickInfo
        abstract getNameOrDottedNameSpan: fileName: string * startPos: float * endPos: float -> TextSpan
        abstract getBreakpointStatementAtPosition: fileName: string * position: float -> TextSpan
        abstract getSignatureHelpItems: fileName: string * position: float -> SignatureHelpItems
        abstract getRenameInfo: fileName: string * position: float -> RenameInfo
        abstract findRenameLocations: fileName: string * position: float * findInStrings: bool * findInComments: bool -> ResizeArray<RenameLocation>
        abstract getDefinitionAtPosition: fileName: string * position: float -> ResizeArray<DefinitionInfo>
        abstract getTypeDefinitionAtPosition: fileName: string * position: float -> ResizeArray<DefinitionInfo>
        abstract getImplementationAtPosition: fileName: string * position: float -> ResizeArray<ImplementationLocation>
        abstract getReferencesAtPosition: fileName: string * position: float -> ResizeArray<ReferenceEntry>
        abstract findReferences: fileName: string * position: float -> ResizeArray<ReferencedSymbol>
        abstract getDocumentHighlights: fileName: string * position: float * filesToSearch: ResizeArray<string> -> ResizeArray<DocumentHighlights>
        abstract getOccurrencesAtPosition: fileName: string * position: float -> ResizeArray<ReferenceEntry>
        abstract getNavigateToItems: searchValue: string * ?maxResultCount: float * ?fileName: string * ?excludeDtsFiles: bool -> ResizeArray<NavigateToItem>
        abstract getNavigationBarItems: fileName: string -> ResizeArray<NavigationBarItem>
        abstract getNavigationTree: fileName: string -> NavigationTree
        abstract getOutliningSpans: fileName: string -> ResizeArray<OutliningSpan>
        abstract getTodoComments: fileName: string * descriptors: ResizeArray<TodoCommentDescriptor> -> ResizeArray<TodoComment>
        abstract getBraceMatchingAtPosition: fileName: string * position: float -> ResizeArray<TextSpan>
        abstract getIndentationAtPosition: fileName: string * position: float * options: U2<EditorOptions, EditorSettings> -> float
        abstract getFormattingEditsForRange: fileName: string * start: float * ``end``: float * options: U2<FormatCodeOptions, FormatCodeSettings> -> ResizeArray<TextChange>
        abstract getFormattingEditsForDocument: fileName: string * options: U2<FormatCodeOptions, FormatCodeSettings> -> ResizeArray<TextChange>
        abstract getFormattingEditsAfterKeystroke: fileName: string * position: float * key: string * options: U2<FormatCodeOptions, FormatCodeSettings> -> ResizeArray<TextChange>
        abstract getDocCommentTemplateAtPosition: fileName: string * position: float -> TextInsertion
        abstract isValidBraceCompletionAtPosition: fileName: string * position: float * openingBrace: float -> bool
        abstract getCodeFixesAtPosition: fileName: string * start: float * ``end``: float * errorCodes: ResizeArray<float> -> ResizeArray<CodeAction>
        abstract getEmitOutput: fileName: string * ?emitOnlyDtsFiles: bool -> EmitOutput
        abstract getProgram: unit -> Program
        abstract dispose: unit -> unit

    and [<AllowNullLiteral>] Classifications =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract spans: ResizeArray<float>[OPTION] with get, set
        abstract endOfLineState: EndOfLineState[OPTION] with get, set

    and [<AllowNullLiteral>] ClassifiedSpan =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract classificationType: string[OPTION] with get, set

    and [<AllowNullLiteral>] NavigationBarItem =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract spans: ResizeArray<TextSpan>[OPTION] with get, set
        abstract childItems: ResizeArray<NavigationBarItem>[OPTION] with get, set
        abstract indent: float[OPTION] with get, set
        abstract bolded: bool[OPTION] with get, set
        abstract grayed: bool[OPTION] with get, set

    and [<AllowNullLiteral>] NavigationTree =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract spans: ResizeArray<TextSpan>[OPTION] with get, set
        abstract childItems: ResizeArray<NavigationTree> option with get, set

    and [<AllowNullLiteral>] TodoCommentDescriptor =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract priority: float[OPTION] with get, set

    and [<AllowNullLiteral>] TodoComment =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract descriptor: TodoCommentDescriptor[OPTION] with get, set
        abstract message: string[OPTION] with get, set
        abstract position: float[OPTION] with get, set

    and [<AllowNullLiteral>] [<Import("TextChange","ts")>] TextChange() =
        class end

    and [<AllowNullLiteral>] FileTextChanges =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract textChanges: ResizeArray<TextChange>[OPTION] with get, set

    and [<AllowNullLiteral>] CodeAction =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract description: string[OPTION] with get, set
        abstract changes: ResizeArray<FileTextChanges>[OPTION] with get, set

    and [<AllowNullLiteral>] TextInsertion =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract newText: string[OPTION] with get, set
        abstract caretOffset: float[OPTION] with get, set

    and [<AllowNullLiteral>] RenameLocation =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract fileName: string[OPTION] with get, set

    and [<AllowNullLiteral>] ReferenceEntry =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract isWriteAccess: bool[OPTION] with get, set
        abstract isDefinition: bool[OPTION] with get, set

    and [<AllowNullLiteral>] ImplementationLocation =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract fileName: string[OPTION] with get, set

    and [<AllowNullLiteral>] DocumentHighlights =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract highlightSpans: ResizeArray<HighlightSpan>[OPTION] with get, set

    and [<AllowNullLiteral>] HighlightSpan =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string option with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract kind: string[OPTION] with get, set

    and [<AllowNullLiteral>] NavigateToItem =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract matchKind: string[OPTION] with get, set
        abstract isCaseSensitive: bool[OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract containerName: string[OPTION] with get, set
        abstract containerKind: string[OPTION] with get, set

    and IndentStyle =
        | None = 0
        | Block = 1
        | Smart = 2

    and [<AllowNullLiteral>] EditorOptions =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract BaseIndentSize: float option with get, set
        abstract IndentSize: float[OPTION] with get, set
        abstract TabSize: float[OPTION] with get, set
        abstract NewLineCharacter: string[OPTION] with get, set
        abstract ConvertTabsToSpaces: bool[OPTION] with get, set
        abstract IndentStyle: IndentStyle[OPTION] with get, set

    and [<AllowNullLiteral>] EditorSettings =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract baseIndentSize: float option with get, set
        abstract indentSize: float option with get, set
        abstract tabSize: float option with get, set
        abstract newLineCharacter: string option with get, set
        abstract convertTabsToSpaces: bool option with get, set
        abstract indentStyle: IndentStyle option with get, set

    and [<AllowNullLiteral>] FormatCodeOptions =
        inherit EditorOptions
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract InsertSpaceAfterCommaDelimiter: bool[OPTION] with get, set
        abstract InsertSpaceAfterSemicolonInForStatements: bool[OPTION] with get, set
        abstract InsertSpaceBeforeAndAfterBinaryOperators: bool[OPTION] with get, set
        abstract InsertSpaceAfterConstructor: bool option with get, set
        abstract InsertSpaceAfterKeywordsInControlFlowStatements: bool[OPTION] with get, set
        abstract InsertSpaceAfterFunctionKeywordForAnonymousFunctions: bool[OPTION] with get, set
        abstract InsertSpaceAfterOpeningAndBeforeClosingNonemptyParenthesis: bool[OPTION] with get, set
        abstract InsertSpaceAfterOpeningAndBeforeClosingNonemptyBrackets: bool[OPTION] with get, set
        abstract InsertSpaceAfterOpeningAndBeforeClosingNonemptyBraces: bool option with get, set
        abstract InsertSpaceAfterOpeningAndBeforeClosingTemplateStringBraces: bool[OPTION] with get, set
        abstract InsertSpaceAfterOpeningAndBeforeClosingJsxExpressionBraces: bool option with get, set
        abstract InsertSpaceAfterTypeAssertion: bool option with get, set
        abstract InsertSpaceBeforeFunctionParenthesis: bool option with get, set
        abstract PlaceOpenBraceOnNewLineForFunctions: bool[OPTION] with get, set
        abstract PlaceOpenBraceOnNewLineForControlBlocks: bool[OPTION] with get, set

    and [<AllowNullLiteral>] FormatCodeSettings =
        inherit EditorSettings
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract insertSpaceAfterCommaDelimiter: bool option with get, set
        abstract insertSpaceAfterSemicolonInForStatements: bool option with get, set
        abstract insertSpaceBeforeAndAfterBinaryOperators: bool option with get, set
        abstract insertSpaceAfterConstructor: bool option with get, set
        abstract insertSpaceAfterKeywordsInControlFlowStatements: bool option with get, set
        abstract insertSpaceAfterFunctionKeywordForAnonymousFunctions: bool option with get, set
        abstract insertSpaceAfterOpeningAndBeforeClosingNonemptyParenthesis: bool option with get, set
        abstract insertSpaceAfterOpeningAndBeforeClosingNonemptyBrackets: bool option with get, set
        abstract insertSpaceAfterOpeningAndBeforeClosingNonemptyBraces: bool option with get, set
        abstract insertSpaceAfterOpeningAndBeforeClosingTemplateStringBraces: bool option with get, set
        abstract insertSpaceAfterOpeningAndBeforeClosingJsxExpressionBraces: bool option with get, set
        abstract insertSpaceAfterTypeAssertion: bool option with get, set
        abstract insertSpaceBeforeFunctionParenthesis: bool option with get, set
        abstract placeOpenBraceOnNewLineForFunctions: bool option with get, set
        abstract placeOpenBraceOnNewLineForControlBlocks: bool option with get, set

    and [<AllowNullLiteral>] DefinitionInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract fileName: string[OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract containerKind: string[OPTION] with get, set
        abstract containerName: string[OPTION] with get, set

    and [<AllowNullLiteral>] ReferencedSymbolDefinitionInfo =
        inherit DefinitionInfo
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract displayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set

    and [<AllowNullLiteral>] ReferencedSymbol =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract definition: ReferencedSymbolDefinitionInfo[OPTION] with get, set
        abstract references: ResizeArray<ReferenceEntry>[OPTION] with get, set

    and SymbolDisplayPartKind =
        | aliasName = 0
        | className = 1
        | enumName = 2
        | fieldName = 3
        | interfaceName = 4
        | keyword = 5
        | lineBreak = 6
        | numericLiteral = 7
        | stringLiteral = 8
        | localName = 9
        | methodName = 10
        | moduleName = 11
        | operator = 12
        | parameterName = 13
        | propertyName = 14
        | punctuation = 15
        | space = 16
        | text = 17
        | typeParameterName = 18
        | enumMemberName = 19
        | functionName = 20
        | regularExpressionLiteral = 21

    and [<AllowNullLiteral>] SymbolDisplayPart =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract text: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set

    and [<AllowNullLiteral>] JSDocTagInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract text: string option with get, set

    and [<AllowNullLiteral>] QuickInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract displayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract documentation: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract tags: ResizeArray<JSDocTagInfo>[OPTION] with get, set

    and [<AllowNullLiteral>] RenameInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract canRename: bool[OPTION] with get, set
        abstract localizedErrorMessage: string[OPTION] with get, set
        abstract displayName: string[OPTION] with get, set
        abstract fullDisplayName: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract triggerSpan: TextSpan[OPTION] with get, set

    and [<AllowNullLiteral>] SignatureHelpParameter =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract documentation: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract displayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract isOptional: bool[OPTION] with get, set

    and [<AllowNullLiteral>] SignatureHelpItem =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract isVariadic: bool[OPTION] with get, set
        abstract prefixDisplayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract suffixDisplayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract separatorDisplayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract parameters: ResizeArray<SignatureHelpParameter>[OPTION] with get, set
        abstract documentation: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract tags: ResizeArray<JSDocTagInfo>[OPTION] with get, set

    and [<AllowNullLiteral>] SignatureHelpItems =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract items: ResizeArray<SignatureHelpItem>[OPTION] with get, set
        abstract applicableSpan: TextSpan[OPTION] with get, set
        abstract selectedItemIndex: float[OPTION] with get, set
        abstract argumentIndex: float[OPTION] with get, set
        abstract argumentCount: float[OPTION] with get, set

    and [<AllowNullLiteral>] CompletionInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract isGlobalCompletion: bool[OPTION] with get, set
        abstract isMemberCompletion: bool[OPTION] with get, set
        abstract isNewIdentifierLocation: bool[OPTION] with get, set
        abstract entries: ResizeArray<CompletionEntry>[OPTION] with get, set

    and [<AllowNullLiteral>] CompletionEntry =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract sortText: string[OPTION] with get, set
        abstract replacementSpan: TextSpan option with get, set

    and [<AllowNullLiteral>] CompletionEntryDetails =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract kind: string[OPTION] with get, set
        abstract kindModifiers: string[OPTION] with get, set
        abstract displayParts: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract documentation: ResizeArray<SymbolDisplayPart>[OPTION] with get, set
        abstract tags: ResizeArray<JSDocTagInfo>[OPTION] with get, set

    and [<AllowNullLiteral>] OutliningSpan =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract textSpan: TextSpan[OPTION] with get, set
        abstract hintSpan: TextSpan[OPTION] with get, set
        abstract bannerText: string[OPTION] with get, set
        abstract autoCollapse: bool[OPTION] with get, set

    and [<AllowNullLiteral>] EmitOutput =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract outputFiles: ResizeArray<OutputFile>[OPTION] with get, set
        abstract emitSkipped: bool[OPTION] with get, set

    and OutputFileType =
        | JavaScript = 0
        | SourceMap = 1
        | Declaration = 2

    and [<AllowNullLiteral>] OutputFile =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract name: string[OPTION] with get, set
        abstract writeByteOrderMark: bool[OPTION] with get, set
        abstract text: string[OPTION] with get, set

    and EndOfLineState =
        | None = 0
        | InMultiLineCommentTrivia = 1
        | InSingleQuoteStringLiteral = 2
        | InDoubleQuoteStringLiteral = 3
        | InTemplateHeadOrNoSubstitutionTemplate = 4
        | InTemplateMiddleOrTail = 5
        | InTemplateSubstitutionPosition = 6

    and TokenClass =
        | Punctuation = 0
        | Keyword = 1
        | Operator = 2
        | Comment = 3
        | Whitespace = 4
        | Identifier = 5
        | NumberLiteral = 6
        | StringLiteral = 7
        | RegExpLiteral = 8

    and [<AllowNullLiteral>] ClassificationResult =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract finalLexState: EndOfLineState[OPTION] with get, set
        abstract entries: ResizeArray<ClassificationInfo>[OPTION] with get, set

    and [<AllowNullLiteral>] ClassificationInfo =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract length: float[OPTION] with get, set
        abstract classification: TokenClass[OPTION] with get, set

    and [<AllowNullLiteral>] Classifier =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract getClassificationsForLine: text: string * lexState: EndOfLineState * syntacticClassifierAbsent: bool -> ClassificationResult
        abstract getEncodedLexicalClassifications: text: string * endOfLineState: EndOfLineState * syntacticClassifierAbsent: bool -> Classifications

    and [<AllowNullLiteral>] [<Import("ClassificationTypeNames","ts")>] ClassificationTypeNames() =
        class end

    and ClassificationType =
        | comment = 1
        | identifier = 2
        | keyword = 3
        | numericLiteral = 4
        | operator = 5
        | stringLiteral = 6
        | regularExpressionLiteral = 7
        | whiteSpace = 8
        | text = 9
        | punctuation = 10
        | className = 11
        | enumName = 12
        | interfaceName = 13
        | moduleName = 14
        | typeParameterName = 15
        | typeAliasName = 16
        | parameterName = 17
        | docCommentTagName = 18
        | jsxOpenTagName = 19
        | jsxCloseTagName = 20
        | jsxSelfClosingTagName = 21
        | jsxAttribute = 22
        | jsxText = 23
        | jsxAttributeStringLiteralValue = 24

    and [<AllowNullLiteral>] DocumentRegistry =
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract acquireDocument: fileName: string * compilationSettings: CompilerOptions * scriptSnapshot: IScriptSnapshot * version: string * ?scriptKind: ScriptKind -> SourceFile
        abstract acquireDocumentWithKey: fileName: string * path: Path * compilationSettings: CompilerOptions * key: DocumentRegistryBucketKey * scriptSnapshot: IScriptSnapshot * version: string * ?scriptKind: ScriptKind -> SourceFile
        abstract updateDocument: fileName: string * compilationSettings: CompilerOptions * scriptSnapshot: IScriptSnapshot * version: string * ?scriptKind: ScriptKind -> SourceFile
        abstract updateDocumentWithKey: fileName: string * path: Path * compilationSettings: CompilerOptions * key: DocumentRegistryBucketKey * scriptSnapshot: IScriptSnapshot * version: string * ?scriptKind: ScriptKind -> SourceFile
        abstract getKeyForCompilationSettings: settings: CompilerOptions -> DocumentRegistryBucketKey
        abstract releaseDocument: fileName: string * compilationSettings: CompilerOptions -> unit
        abstract releaseDocumentWithKey: path: Path * key: DocumentRegistryBucketKey -> unit
        abstract reportStats: unit -> string

    and DocumentRegistryBucketKey =
        obj

    and [<AllowNullLiteral>] TranspileOptions =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract compilerOptions: CompilerOptions option with get, set
        abstract fileName: string option with get, set
        abstract reportDiagnostics: bool option with get, set
        abstract moduleName: string option with get, set
        abstract renamedDependencies: MapLike<string> option with get, set

    and [<AllowNullLiteral>] TranspileOutput =
        abstract [NAME]: [TYPE][OPTION] with get, set
        abstract outputText: string[OPTION] with get, set
        abstract diagnostics: ResizeArray<Diagnostic> option with get, set
        abstract sourceMapText: string option with get, set

    and [<AllowNullLiteral>] DisplayPartsSymbolWriter =
        inherit SymbolWriter
        abstract [NAME]: [PARAMETERS] -> [TYPE]
        abstract displayParts: unit -> ResizeArray<SymbolDisplayPart>

    module ScriptSnapshot =


    module HighlightSpanKind =


    module ScriptElementKind =


    module ScriptElementKindModifier =


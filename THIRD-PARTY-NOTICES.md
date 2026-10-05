# Third-party notices

Smart Retail POS is proprietary software of NextGenOS, used under the licence agreement in [EULA.txt](EULA.txt) (see also [LICENSE](LICENSE)). It includes or uses the third-party software below, each under its own licence, which the agreement does not change. This file is installed with the app, next to `EULA.txt`.

## Libraries in the app and the dashboard

These NuGet packages are built into the Windows app (`SmartRetailAI.exe`) and the sales dashboard (`Dashboard\`). The list is the packages the two projects restore for Windows; a package used by both appears once.

| Package | Version | Licence | Copyright |
|---|---|---|---|
| Anthropic | 12.50.0 | MIT | Copyright 2026 Anthropic |
| Markdig | 1.4.0 | BSD-2-Clause | Alexandre Mutel |
| Microsoft.AspNetCore.App.Internal.Assets | 10.0.12 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Bcl.AsyncInterfaces | 10.0.6 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Bcl.Cryptography | 9.0.18 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Data.SqlClient | 7.1.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Data.SqlClient.Extensions.Abstractions | 7.1.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Data.SqlClient.Internal.Logging | 7.1.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Data.SqlClient.SNI.runtime | 7.1.0 | Microsoft Software License Terms (redistributable) | © Microsoft Corporation. All rights reserved. |
| Microsoft.Extensions.AI.Abstractions | 10.5.1 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.Abstractions | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.JsonWebTokens | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.Logging | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.Protocols | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Data.Sqlite / Microsoft.Data.Sqlite.Core | 10.0.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.Protocols.OpenIdConnect | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.IdentityModel.Tokens | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.ML.OnnxRuntime | 1.30.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.ML.OnnxRuntime.Managed | 1.30.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.SqlServer.Server | 1.0.0 | MIT | © Microsoft Corporation. All rights reserved. |
| Microsoft.Web.WebView2 | 1.0.4191.47 | BSD-3-Clause (Microsoft) | © Microsoft Corporation. All rights reserved. |
| Newtonsoft.Json | 13.0.3 | MIT | Copyright © James Newton-King 2008 |
| SkiaSharp | 4.152.1 | MIT | © Microsoft Corporation. All rights reserved. |
| SkiaSharp.NativeAssets.Linux.NoDependencies / .macOS / .Win32 | 4.152.1 | MIT | © Microsoft Corporation. All rights reserved. |
| SQLitePCLRaw (core, provider and lib.e_sqlite3) | 2.1.13 | Apache-2.0 | Copyright 2014-2024 SourceGear, LLC (SQLite itself is in the public domain) |
| System.Buffers | 4.6.1 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Collections.Immutable | 8.0.0 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Configuration.ConfigurationManager | 9.0.18 | MIT | © Microsoft Corporation. All rights reserved. |
| System.IO.Ports | 8.0.0 | MIT | © Microsoft Corporation. All rights reserved. |
| System.IdentityModel.Tokens.Jwt | 8.16.0 | MIT | © Microsoft Corporation. All rights reserved. |
| System.IO.Pipelines | 10.0.6 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Memory | 4.6.3 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Net.ServerSentEvents | 10.0.1 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Numerics.Tensors | 9.0.0 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Numerics.Vectors | 4.6.1 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Runtime.CompilerServices.Unsafe | 6.1.2 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Security.Cryptography.Pkcs | 9.0.18 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Security.Cryptography.ProtectedData | 9.0.18 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Text.Encodings.Web | 10.0.6 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Text.Json | 10.0.6 | MIT | © Microsoft Corporation. All rights reserved. |
| System.Threading.Tasks.Extensions | 4.6.3 | MIT | © Microsoft Corporation. All rights reserved. |
| System.ValueTuple | 4.6.2 | MIT | © Microsoft Corporation. All rights reserved. |
| ZXing.Net | 0.16.11 | Apache-2.0 | Michael Jahn |

The packages marked MIT are used under the MIT License, whose text is at the end of this file; each keeps its own copyright line above. Markdig is under the BSD 2-Clause License, and ZXing.Net and SQLitePCLRaw under the Apache License 2.0 (full text in [licenses/Apache-2.0.txt](licenses/Apache-2.0.txt)). WebView2's SDK is under Microsoft's BSD-style licence, and the SQL Server client's native network library (`Microsoft.Data.SqlClient.SNI.runtime`) is **not** under the MIT License: it is Microsoft's "Distributable Code" under the terms in [licenses/third-party/Microsoft.Data.SqlClient.SNI-LICENSE.txt](licenses/third-party/Microsoft.Data.SqlClient.SNI-LICENSE.txt). It is in the binary downloads only (never in this repository's source), may be passed on only as a part of an application and not by itself, and whoever passes this app on has to keep those terms.

## Other components

| Component | Where | Licence |
|---|---|---|
| .NET runtime and ASP.NET Core, with the Microsoft.Extensions libraries (such as Microsoft.Extensions.DependencyInjection.Abstractions) | Bundled with the dashboard (it runs without a .NET install) | MIT, © .NET Foundation and contributors |
| Inter (variable font) | Dashboard, `wwwroot/fonts` | SIL Open Font License 1.1: `Inter-LICENSE.txt` beside the font |
| Noto Sans Devanagari | Dashboard, `wwwroot/fonts` | SIL Open Font License 1.1: `NotoSansDevanagari-LICENSE.txt` beside the font |
| supabase-js, with the `@supabase` packages inside it | The owner's live-view page, `owner-app/vendor` | MIT: `supabase-js.LICENSE` beside it |
| NSIS | Builds the setup program (`SmartRetailAI-Setup.exe`); its runtime is inside the setup | The NSIS licence (zlib/libpng style, with the licences of the compression code it includes), https://nsis.sourceforge.io/NSIS_License |
| Microsoft Edge WebView2 Runtime bootstrapper | Inside the setup; run only on a PC that does not have WebView2 | Microsoft's redistribution terms for the WebView2 Runtime |

## The vendors' own notices

The files in [`licenses/third-party/`](licenses/third-party) are the licence and notice files that come with the packages above, unchanged (they are installed with the app, in `licenses\third-party\`).

| File | What it covers |
|---|---|
| `Microsoft.Data.SqlClient.SNI-LICENSE.txt` | Microsoft's licence terms for the SQL Server network library, described above |
| `Microsoft.Web.WebView2-LICENSE.txt`, `Microsoft.Web.WebView2-NOTICE.txt` | WebView2's SDK (BSD-3-Clause style), and the third-party components in its loader |
| `SkiaSharp-THIRD-PARTY-NOTICES.txt` | The components inside SkiaSharp's native library (Skia and others) |
| `OnnxRuntime-ThirdPartyNotices.txt` | The components inside ONNX Runtime's native library |
| `dotnet-runtime-THIRD-PARTY-NOTICES.txt`, `aspnetcore-runtime-THIRD-PARTY-NOTICES.txt` | The components inside the .NET and ASP.NET Core runtime that the dashboard carries |
| `Newtonsoft.Json-LICENSE.md` | Json.NET's licence (MIT) |

## Used when the owner turns it on, and not part of this software

These are not included; they are installed or downloaded separately, and the owner accepts their own terms there.

- **OpenAI Codex CLI** (Apache-2.0), the default AI tool: installed by OpenAI's own installer from the *Get started* page, and updated by OpenAI's installer. Signing in and using it is under the owner's own OpenAI account terms.
- **Claude Code**, **Antigravity CLI** and the AI services reached with an API key (OpenAI, Anthropic, Google): only if the owner sets them up, under their own terms.
- **DINOv2-small** (Meta AI, Apache-2.0; the ONNX conversion is by `onnx-community`): downloaded once, on the owner's request, for finding products by their look, https://huggingface.co/facebook/dinov2-small
- **DINOv2-base** (Meta AI, Apache-2.0; the ONNX conversion is by `onnx-community`): the better model for finding products by their look, downloaded once, only if the owner chooses it in Settings, https://huggingface.co/facebook/dinov2-base

## Trademarks

Microsoft, Windows, SQL Server and WebView2 are trademarks of Microsoft Corporation. OpenAI, ChatGPT and Codex are trademarks of OpenAI. Claude and Anthropic are trademarks of Anthropic. Google and Gemini are trademarks of Google LLC. Supabase is a trademark of Supabase Inc. They are used here only to say what this software works with; it is not made, endorsed or supported by any of them.

## Licence texts

### MIT License

Used, with the copyright line of each package in the table above, for the packages marked MIT:

    MIT License

    Copyright (c) <the copyright holder named for the package>

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

### BSD 2-Clause License (Markdig)

    Copyright (c) 2018-2019, Alexandre Mutel
    All rights reserved.

    Redistribution and use in source and binary forms, with or without modification,
    are permitted provided that the following conditions are met:

    1. Redistributions of source code must retain the above copyright notice, this
       list of conditions and the following disclaimer.

    2. Redistributions in binary form must reproduce the above copyright notice,
       this list of conditions and the following disclaimer in the documentation
       and/or other materials provided with the distribution.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
    ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
    WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
    DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
    ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
    (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
    LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
    ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
    (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

### Apache License 2.0 (ZXing.Net)

The full text is in [licenses/Apache-2.0.txt](licenses/Apache-2.0.txt), which is installed with the app.

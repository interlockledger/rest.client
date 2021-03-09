/******************************************************************************************************************************

Copyright (c) 2018-2020 InterlockLedger Network
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

* Neither the name of the copyright holder nor the names of its
  contributors may be used to endorse or promote products derived from
  this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

******************************************************************************************************************************/

using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InterlockLedger.Rest.Client.V6_0
{
    public static class StringExtensions
    {
        public static string Ellipsis(this string text, ushort limit) => UnsafeEllipsis(text.Safe(), limit);

        public static bool IsValidJson(this string text) {
            if (string.IsNullOrWhiteSpace(text))
                return false;
            try {
                _ = JsonSerializer.Deserialize<object>(text.Trim(), _jsonValidationOptions);
            } catch (Exception) {
                return false;
            }
            return true;
        }

        private static readonly JsonSerializerOptions _jsonValidationOptions = new() {
            AllowTrailingCommas = true,
            NumberHandling = JsonNumberHandling.Strict,
            ReadCommentHandling = JsonCommentHandling.Skip,
        };

        private static string UnsafeEllipsis(string text, ushort limit)
            => text.Length <= limit ? text : limit > 3 ? $"{text.Substring(0, -3 + limit)}..." : text.Substring(0, limit);
    }
}
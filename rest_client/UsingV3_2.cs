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
using InterlockLedger.Rest.Client.Abstractions;
using InterlockLedger.Rest.Client.V3;

namespace rest_client
{

    public class UsingV3_2 : AbstractUsing<RestChain>
    {
        public static void DoIt(string[] args) {
            try {
                var client = args.Length > 2 ? new RestNode(args[0], args[1], ushort.Parse(args[2])) : new RestNode(args[0], args[1]);
                new UsingV3_2(client).Exercise();
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        protected UsingV3_2(RestAbstractNode<RestChain> node) : base(node) {
        }

        protected override string Version => "3.2";

        protected override void ExerciseDocApp(RestChain chain) {
            bool first = true;
            // using old document API
            if (chain is IDocumentApp chainDocApp)
                foreach (var doc in chainDocApp.Documents) {
                    Console.WriteLine($"    {doc}");
                    if (first && doc.IsPlainText) {
                        Dump(chainDocApp.DocumentAsPlain(doc.FileId));
                        Dump(chainDocApp.DocumentAsRaw(doc.FileId).ToString());
                        first = false;
                    }
                }
        }

        protected override void TryToStoreNiceDocuments(RestChain chain) {
            if (chain is IDocumentApp chainDocApp)
                try {
                    Console.WriteLine();
                    Console.WriteLine("  Trying to store a nice document:");
                    var document = chainDocApp.StoreDocumentFromText("Simple test document", "TestDocument");
                    Console.WriteLine($"    {document}");
                } catch (Exception e) {
                    Console.WriteLine(e);
                }
        }
    }
}
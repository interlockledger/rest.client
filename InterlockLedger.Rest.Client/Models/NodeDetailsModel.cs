/******************************************************************************************************************************

Copyright (c) 2018-2019 InterlockLedger Network
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

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace InterlockLedger
{
    /// <summary>
    /// Node details
    /// </summary>
    public class NodeDetailsModel
    {
        /// <summary>
        /// List of owned records, only the ids
        /// </summary>
        public IEnumerable<string> Chains { get; set; }

        /// <summary>
        /// Mapping color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Unique node id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Node name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Network this node participates on
        /// </summary>
        public string Network { get; set; }

        /// <summary>
        /// Node owner id [Optional]
        /// </summary>
        public string OwnerId { get; set; }

        /// <summary>
        /// Node owner name [Optional]
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// List of active roles running in the node
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        public override string ToString() => $@"Node '{Name}' #{Id}
Network {Network}
Color {Color}
Owner {OwnerName} #{OwnerId}
Roles: {string.Join(", ", Roles ?? _empty)}
Chains: {string.Join(", ", Chains ?? _empty)}
";

        private static readonly IEnumerable<string> _empty = Enumerable.Empty<string>();
    }
}
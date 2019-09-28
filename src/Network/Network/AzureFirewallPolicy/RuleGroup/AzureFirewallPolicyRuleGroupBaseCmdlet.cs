
// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class AzureFirewallPolicyRuleGroupBaseCmdlet : NetworkBaseCmdlet
    {
        public FirewallPolicyRuleGroupsOperationsExtensions AzureFirewallPolicyRuleGroupClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.FirewallPolicyRuleGroups;
            }
        }

        public IAzureFirewallFqdnTagsOperations AzureFirewallPolicyRuleGroupFqdnTagClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.AzureFirewallFqdnTags;
            }
        }

        // public bool IsAzureFirewallPolicyPresent(string resourceGroupName, string name)
        // {
        //     try
        //     {
        //         GetAzureFirewallPolicy(resourceGroupName, name);
        //     }
        //     catch (Microsoft.Rest.Azure.CloudException exception)
        //     {
        //         if (exception.Response.StatusCode == HttpStatusCode.NotFound)
        //         {
        //             // Resource is not present
        //             return false;
        //         }

        //         throw;
        //     }

        //     return true;
        // }

        // public PSAzureFirewallPolicy GetAzureFirewallPolicy(string resourceGroupName, string name)
        // {
        //     var azureFirewallPolicy = this.AzureFirewallPolicyRuleGroupClient.Get(resourceGroupName, name);

        //     var psAzureFirewall = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicy>(azureFirewallPolicy);
        //     psAzureFirewall.ResourceGroupName = resourceGroupName;
        //     psAzureFirewall.Tag = TagsConversionHelper.CreateTagHashtable(azureFirewallPolicy.Tags);

        //     return psAzureFirewall;
        // }

        public PSAzureFirewallPolicy ToPsAzureFirewallPolicy(FirewallPolicy firewall)
        {
            var azureFirewall = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicy>(firewall);

            azureFirewall.Tag = TagsConversionHelper.CreateTagHashtable(firewall.Tags);

            return azureFirewall;
        }
    }
}

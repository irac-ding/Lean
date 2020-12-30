/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

namespace QuantConnect.Securities
{
    /// <summary>
    /// Provides an implementation of <see cref="IBuyingPowerModel"/> that uses an absurdly low margin
    /// requirement to ensure all orders have sufficient margin provided the portfolio is not underwater.
    /// </summary>
    public class NullBuyingPowerModel : BuyingPowerModel
    {
        private const decimal MarginRequirement = 0.0000000001m;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullBuyingPowerModel"/> class
        /// </summary>
        public NullBuyingPowerModel()
            : base(MarginRequirement, MarginRequirement, requiredFreeBuyingPowerPercent: 0m)
        {
        }

        public override void SetLeverage(Security security, decimal leverage)
        {
            // ignored -- reasoning is user has an algorithm that has margin issues and so they quickly swap
            // this impl in, but their code calls set leverage, they would need to comment that out and such
            // said another way -- user made the decision to ignore margin/leverage by selecting this model
        }
    }
}

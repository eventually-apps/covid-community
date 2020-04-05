using System;
using System.Collections.Generic;
using System.Text;

namespace CovidCommunity.Api.HttpService
{
    public interface IHttpAuthenticationSettings
    {
        /// <summary>
        /// Generates the authentication header with the correct implemenation.
        /// </summary>
        /// <returns>They key-value pair of the authentication header</returns>
        public KeyValuePair<string, string> GenerateAuthenticationHeader();
    }
}

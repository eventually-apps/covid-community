using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidCommunity.Api.HttpService
{
    /// <summary>
    /// Base class that cab be used when making http services. 
    /// </summary>
    public abstract class BaseHttpService
    {
        /// <summary>
        /// Sends a http request the content type set to application/json
        /// </summary>
        /// <typeparam name="TData">The type of data you expect back in the response</typeparam>
        /// <param name="uri">The url to send the request to.</param>
        /// <param name="httpMethod">The HTTP Request Type Protocol to use</param>
        /// <param name="authenticationSettings">The authentication settings, if any, that needs to sent with this request.</param>
        /// <param name="headers">The headers, if any, we need to send with this request.</param>
        /// <param name="requestData">The data to send.</param>
        /// <returns>Task that resolves to a response object that has the data from the response.</returns>
        protected Task<Response<TData>> SendRequestAsync<TData>(Uri uri, HttpMethod httpMethod = null, IHttpAuthenticationSettings authenticationSettings = null, IDictionary<string, string> headers = null, object requestData = null)
        {
            // default to get if the method is null
            var method = httpMethod ?? HttpMethod.Get;
            // convert a request data to json to send it
            var data = requestData == null ? null : new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            
            return SendRequestAsync<TData>(uri, method, authenticationSettings, headers, data);
        }

        /// <summary>
        /// Sends a http request with the content type sent to form-url-encoded
        /// </summary>
        /// <typeparam name="TData">The type of data you expect back in the response</typeparam>
        /// <param name="uri">The url to send the request to.</param>
        /// <param name="httpMethod">The HTTP Request Type Protocol to use</param>
        /// <param name="authenticationSettings">The authentication settings, if any, that needs to sent with this request.</param>
        /// <param name="headers">The headers, if any, we need to send with this request.</param>
        /// <param name="formContent">The form content to send.</param>
        /// <returns>Task that resolves to a response object that has the data from the response.</returns>
        protected Task<Response<TData>> SendRequestAsync<TData>(Uri uri, HttpMethod httpMethod = null, IHttpAuthenticationSettings authenticationSettings = null, IDictionary<string, string> headers = null, IDictionary<string, string> formContent = null)
        {
            // default to get if the method is null
            var method = httpMethod ?? HttpMethod.Get;
            // url encode our data
            var data = formContent == null ? null : new FormUrlEncodedContent(formContent.Select(x => x));

            return SendRequestAsync<TData>(uri, method, authenticationSettings, headers, data);
        }

        /// <summary>
        /// Sends a http request out with the request content.
        /// </summary>
        /// <typeparam name="TData">The type of data you expect back in the response</typeparam>
        /// <param name="uri">The url to send the request to.</param>
        /// <param name="httpMethod">The HTTP Request Type Protocol to use</param>
        /// <param name="authenticationSettings">The authentication settings, if any, that needs to sent with this request.</param>
        /// <param name="headers">The headers, if any, we need to send with this request.</param>
        /// <param name="requestContent">The request content to send in the request</param>
        /// <returns>Task that resolves to a response object that has the data from the response.</returns>
        protected async Task<Response<TData>> SendRequestAsync<TData>(Uri uri, HttpMethod httpMethod, IHttpAuthenticationSettings authenticationSettings = null, IDictionary<string, string> headers = null, HttpContent requestContent = null)
        {
            Response<TData> result;

            using (var request = new HttpRequestMessage(httpMethod, uri))
            {
                if (requestContent != null)
                {
                    request.Content = requestContent;
                }

                headers = GetHeaders(authenticationSettings, headers);

                // create the client and send the request out
                using var client = new HttpClient();
                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

                if (response.IsSuccessStatusCode)
                {
                    result = new Response<TData>
                    {
                        Success = true,
                        Data = JsonConvert.DeserializeObject<TData>(await response.Content.ReadAsStringAsync())
                    };
                }
                else
                {
                    result = new Response<TData>
                    {
                        ErrorCode = response.StatusCode.ToString(),
                        ErrorMessage = response.ReasonPhrase,
                        Success = false
                    };
                }
            }

            return result;
        }

        private IDictionary<string, string> GetHeaders(IHttpAuthenticationSettings authenticationSettings, IDictionary<string, string> headers)
        {
            if(authenticationSettings == null && headers == null)
            {
                return null;
            }

            if(authenticationSettings == null)
            {
                return headers;
            }

            if(headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            headers.Add(authenticationSettings.GenerateAuthenticationHeader());

            return headers;
        }
    }
}

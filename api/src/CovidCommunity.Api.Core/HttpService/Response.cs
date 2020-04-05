namespace CovidCommunity.Api.HttpService
{
    /// <summary>
    /// Represents a response from an HTTP Call using the <see cref="BaseHttpService"/>
    /// </summary>
    /// <typeparam name="T">The type of data you are expecting back from the http call.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// The error code if an error happened.
        /// will be null if response was successful.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// The error message if an error happened in the call.
        /// Will be null if response was successful.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// If this response was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The data returned from the HTTP call.
        /// </summary>
        public T Data { get; set; }
    }

}

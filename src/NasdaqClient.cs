using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Nasdaq.StockReports.Api.Models;

namespace Nasdaq.StockReports.Api
{
    public sealed class NasdaqClient : ClientApiBase
    {
        public NasdaqClient() : base("https://api.nasdaq.com/api/")
        {
        }

        public Task<EarningsDateResponse> GetEarningsDateAsync(string ticker)
        {
            return this.GetAsync<EarningsDateResponse>($"analyst/{ticker}/earnings-date");
        }

        public Task<EarningsForecastResponse> GetEarningsForecastAsync(string ticker)
        {
            return this.GetAsync<EarningsForecastResponse>($"analyst/{ticker}/earnings-forecast");
        }

        public Task<EarningsMomentumResponse> GetEarningsMomentumAsync(string ticker)
        {
            return this.GetAsync<EarningsMomentumResponse>($"analyst/{ticker}/estimate-momentum");
        }

        public Task<EarningsSurpriseResponse> GetEarningsSurpriseAsync(string ticker)
        {
            return this.GetAsync<EarningsSurpriseResponse>($"company/{ticker}/earnings-surprise");
        }

        public Task<StockDataResponse> GetStockAsync(string ticker)
        {
            return this.GetAsync<StockDataResponse>($"quote/{ticker}/summary?assetclass=stocks");
        }
    }

    /// <summary>
    /// Base class for any SDK client API implementation containing reusable logic for common call types, error handling, request retry attempts.
    /// </summary>
    public abstract class ClientApiBase : IDisposable
    {
        #region Variables

        protected HttpClient Client { get; private set; }

        protected Uri BaseUri { get; private set; }

        #endregion

        #region Constructors

        public ClientApiBase(string baseURL = null)
        {
            HttpClientHandler handler = new HttpClientHandler();
            this.BaseUri = new Uri(baseURL);
            this.Client = new HttpClient(handler);
        }

        public void Dispose()
        {
            this.Client.Dispose();
            this.Client = null;
        }

        #endregion

        #region Methods

        #region Build Uri

        private Uri GetUri(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return new Uri(this.BaseUri, url);
        }

        #endregion

        #region Get

        protected async Task<string> GetAsync(string url, CancellationToken ct = default(CancellationToken))
        {
            var response = await this.GetResponseAsync(url, ct);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Gets data from the specified URL.
        /// </summary>
        /// <typeparam name="T">Type for the strongly typed class representing data returned from the URL.</typeparam>
        /// <param name="url">URL to retrieve data from should be deserialized.</param>
        /// <returns>Instance of the type specified representing the data returned from the URL.</returns>
        protected async Task<T> GetAsync<T>(string url, CancellationToken ct = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var response = await this.Client.GetAsync(new Uri(this.BaseUri, url), ct);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// Gets an HttpResponseMessage from a specified URL.
        /// </summary>
        /// <param name="url">URL of the service to call.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>Returns an HttpResponseMessage from the URL specified.</returns>
        protected async Task<HttpResponseMessage> GetResponseAsync(string url, CancellationToken ct = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var response = await this.Client.GetAsync(new Uri(this.BaseUri, url), ct);
            response.EnsureSuccessStatusCode();
            return response;
        }

        #endregion

        #endregion
    }
}
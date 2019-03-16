using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using NUnit.Framework;
using Should;
using SpecsFor.StructureMap;

namespace Store.Tests.Integration.Framework
{
    [TestFixture]
    public abstract class SpecsForApi
    {
        protected static HttpClient Client => SetupFixture.Client;
        protected static TestServer Server => SetupFixture.Server;
        protected SqliteConnection Connection;

        /// <summary>Send a DELETE request to the specified Uri.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="authToken">A <see cref="string" /> containing the authorization token.</param>
        /// <returns>An <see cref="HttpResponseMessage" /> containing the response.</returns>
        protected virtual async Task<HttpResponseMessage> DeleteAsync(string requestUri, string authToken = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{requestUri}"),
                Method = HttpMethod.Delete
            };

            return await SendAsync(request, authToken);
        }

        /// <summary>Gets the result of calling the specified request URI.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="authToken">A <see cref="string" /> containing the authorization token.</param>
        /// <returns>An <see cref="HttpResponseMessage" /> containing the response.</returns>
        protected virtual async Task<HttpResponseMessage> GetAsync(string requestUri, string authToken = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{requestUri}"),
                Method = HttpMethod.Get
            };

            return await SendAsync(request, authToken);
        }

        protected TModel GetModel<TModel>(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<TModel>(content);

            return model;
        }

        public virtual void Given()
        {
        }

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            Given();
            When();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            Connection.Close();
        }

        /// <summary>Posts the model to the specified URI.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="model">The content sent to the server.</param>
        /// <param name="authToken">A <see cref="string" /> containing the authorization token.</param>
        /// <returns>An <see cref="HttpResponseMessage" /> containing the response.</returns>
        protected virtual async Task<HttpResponseMessage> PostAsync(string requestUri, object model, string authToken = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{requestUri}"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            };

            return await SendAsync(request, authToken);
        }

        /// <summary>Send a PUT request to the specified Uri.</summary>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="model">The content sent to the server.</param>
        /// <param name="authToken">A <see cref="string" /> containing the authorization token.</param>
        /// <returns>An <see cref="HttpResponseMessage" /> containing the response.</returns>
        protected virtual async Task<HttpResponseMessage> PutAsync(string requestUri, object model, string authToken = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{Client.BaseAddress}{requestUri}"),
                Method = HttpMethod.Put,
                Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
            };

            return await SendAsync(request, authToken);
        }

        protected async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, string authToken = null)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (authToken != null)
            {
                request.Headers.Add(HttpRequestHeader.Authorization.ToString(), authToken);
            }

            return await Client.SendAsync(request);
        }

        /// <summary>
        ///     Checks the status code, and attempts to deserialize the respones content into an ApiError if possible for
        ///     debugging.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="expectedStatusCode"></param>
        protected void VerifyStatusCode(HttpResponseMessage response, HttpStatusCode expectedStatusCode)
        {
            response.StatusCode.ShouldEqual(expectedStatusCode);
        }

        public virtual void When()
        {
        }
    }
}

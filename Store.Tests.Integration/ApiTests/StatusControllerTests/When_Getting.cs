using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Should;
using Store.Services.Contracts.Status;

namespace Store.Tests.Integration.ApiTests.StatusControllerTests
{
    public class When_Getting : SpecsForStatusController
    {
        private StatusGetResponse model;
        private HttpResponseMessage response;

        public override void When()
        {
            base.When();
            response = GetAsync("status").Result;
            model = GetModel<StatusGetResponse>(response);
        }

        [Test]
        public void Then_the_model_should_indicate_success()
        {
            model.Message.ShouldEqual("OK");
        }

        [Test]
        public void Then_the_StatusCode_was_OK()
        {
            response.StatusCode.ShouldEqual(HttpStatusCode.OK);
        }
    }
}

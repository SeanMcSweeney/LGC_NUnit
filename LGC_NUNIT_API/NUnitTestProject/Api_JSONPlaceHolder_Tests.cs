using NUnit.Framework;
using RestSharp;
using System.Net;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Api_JSONPlaceHolder_Tests
{
    [TestFixture]
    [AllureNUnit]
    public class Api_JSONPlaceHolder_Tests
    {
        private RestClient client;
        public Api_JSONPlaceHolder_Tests()
        {
            client = new RestClient("https://jsonplaceholder.typicode.com");
        }

        [Test]
        [AllureTag("APIGET")]
        public void GET_Request()
        {
            // Test setup
            var request = new RestRequest("/posts/1", Method.Get);

            Dictionary<string, object> expectedGetResponse = new Dictionary<string, object>
            {
                { "userId", 1 },
                { "id", 1 },
                { "title", "sunt aut facere repellat provident occaecati excepturi optio reprehenderit" },
                { "body", "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto" }
            };

            // Execute tests
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);
            if (response.Content != null){
                JObject jsonResponse = JObject.Parse(response.Content);
                int userId = jsonResponse["userId"]?.Value<int>() ?? throw new InvalidOperationException("userId not found or is null");
                Assert.That(userId, Is.EqualTo(expectedGetResponse["userId"]));
                int id = jsonResponse["id"]?.Value<int>() ?? throw new InvalidOperationException("id not found or is null");
                Assert.That(id, Is.EqualTo(expectedGetResponse["id"]));
                string title = jsonResponse["title"]?.Value<string>() ?? throw new InvalidOperationException("title not found or is null");
                Assert.That(title, Is.EqualTo(expectedGetResponse["title"]));
                string body = jsonResponse["body"]?.Value<string>() ?? throw new InvalidOperationException("body not found or is null");
                Assert.That(body, Is.EqualTo(expectedGetResponse["body"]));
            }
            else{
                throw new InvalidOperationException("response.Content null or not found");
            }

            // Log response details
            TestContext.WriteLine($"Response Status Code: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");
        }

        [Test]
        [AllureTag("APIPOST")]
        public void POST_Request()
        {
            // Test setup
            var request = new RestRequest("/posts", Method.Post);

            Dictionary<string, object> buildPostResponse = new Dictionary<string, object>
            {
                { "userId", 99 },
                { "title", "LGC Test Title" },
                { "body", "LGC Test Body" }
            };
            string jsonBody = JsonConvert.SerializeObject(buildPostResponse);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            // Execute tests
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Content, Is.Not.Empty);
            if (response.Content != null){
                JObject jsonResponse = JObject.Parse(response.Content);
                int userId = jsonResponse["userId"]?.Value<int>() ?? throw new InvalidOperationException("userId not found or is null");
                Assert.That(userId, Is.EqualTo(buildPostResponse["userId"]));
                string title = jsonResponse["title"]?.Value<string>() ?? throw new InvalidOperationException("title not found or is null");
                Assert.That(title, Is.EqualTo(buildPostResponse["title"]));
                string body = jsonResponse["body"]?.Value<string>() ?? throw new InvalidOperationException("body not found or is null");
                Assert.That(body, Is.EqualTo(buildPostResponse["body"]));
                int id = jsonResponse["id"]?.Value<int>() ?? throw new InvalidOperationException("id not found or is null");
            }
            else{
                throw new InvalidOperationException("response.Content null or not found");
            }

            // Log response details
            TestContext.WriteLine($"Response Status Code: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");
        }
        [Test]
        [AllureTag("APIPUT")]
        public void PUT_Request()
        {
            // Test setup
            var request = new RestRequest("/posts/1", Method.Put);

            Dictionary<string, object> buildPutResponse = new Dictionary<string, object>
            {
                { "userId", 98 },
                { "title", "LGC Test Title PUT REQ" },
                { "body", "LGC Test Body PUT REQ" }
            };
            string jsonBody = JsonConvert.SerializeObject(buildPutResponse);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            // Execute tests
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);
            if (response.Content != null){
                JObject jsonResponse = JObject.Parse(response.Content);
                int userId = jsonResponse["userId"]?.Value<int>() ?? throw new InvalidOperationException("userId not found or is null");
                Assert.That(userId, Is.EqualTo(buildPutResponse["userId"]));
                string title = jsonResponse["title"]?.Value<string>() ?? throw new InvalidOperationException("title not found or is null");
                Assert.That(title, Is.EqualTo(buildPutResponse["title"]));
                string body = jsonResponse["body"]?.Value<string>() ?? throw new InvalidOperationException("body not found or is null");
                Assert.That(body, Is.EqualTo(buildPutResponse["body"]));
                int id = jsonResponse["id"]?.Value<int>() ?? throw new InvalidOperationException("id not found or is null");
                Assert.That(id, Is.EqualTo(1));
            }
            else{
                throw new InvalidOperationException("response.Content null or not found");
            }

            // Log response details
            TestContext.WriteLine($"Response Status Code: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");
        }
        [Test]
        [AllureTag("APIDELETE")]
        public void DELETE_Request()
        {
            // Test setup
            var request = new RestRequest("/posts/1", Method.Delete);

            // Execute tests
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK).Or.EqualTo(HttpStatusCode.NoContent));
            Assert.That(response.Content, Is.EqualTo("{}"));

            // Log response details
            TestContext.WriteLine($"Response Status Code: {response.StatusCode}");
            TestContext.WriteLine($"Response Content: {response.Content}");
        }
    }
}


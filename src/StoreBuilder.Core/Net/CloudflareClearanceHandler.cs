using FlareSolverrSharp;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace StoreBuilder.Core.Net
{
    public static class CloudflareClearanceHandler
    {
        public static string FlareSolverrUrl = "http://localhost:45/";
        public static string ProtectedUrl = "https://bckyrdbbq.com";

        public static async Task SampleGet()
        {
            var handler = new ClearanceHandler(FlareSolverrUrl)
            {
                MaxTimeout = 60000,
                ProxyUrl = "http://127.0.0.1:8888"
            };

            var client = new HttpClient(handler);
            try
            {
                var content = await client.GetAsync(ProtectedUrl);
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task SamplePostUrlEncoded()
        {
            var handler = new ClearanceHandler(FlareSolverrUrl)
            {
                MaxTimeout = 60000
            };

            var request = new HttpRequestMessage();
            request.Headers.ExpectContinue = false;
            request.RequestUri = new Uri(ProtectedUrl);
            var postData = new Dictionary<string, string> { { "story", "test" } };
            request.Content = FormUrlEncodedContentWithEncoding(postData, Encoding.UTF8);
            request.Method = HttpMethod.Post;

            var client = new HttpClient(handler);
            var content = await client.SendAsync(request);
            Console.WriteLine(content);
        }

        static ByteArrayContent FormUrlEncodedContentWithEncoding(
            IEnumerable<KeyValuePair<string, string>> nameValueCollection, Encoding encoding)
        {
            // utf-8 / default
            if (Encoding.UTF8.Equals(encoding) || encoding == null)
                return new FormUrlEncodedContent(nameValueCollection);

            // other encodings
            var builder = new StringBuilder();
            foreach (var pair in nameValueCollection)
            {
                if (builder.Length > 0)
                    builder.Append('&');
                builder.Append(HttpUtility.UrlEncode(pair.Key, encoding));
                builder.Append('=');
                builder.Append(HttpUtility.UrlEncode(pair.Value, encoding));
            }
            // HttpRuleParser.DefaultHttpEncoding == "latin1"
            var data = Encoding.GetEncoding("latin1").GetBytes(builder.ToString());
            var content = new ByteArrayContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return content;
        }
    }
}

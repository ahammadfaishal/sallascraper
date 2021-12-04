namespace StoreBuilder.Core.Excavation
{
    public class ExcavationService : IExcavationService
    {
        public string ProtectedUrl = "https://bckyrdbbq.com";
        public async Task CollectData(string targetSiteUrl)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("http://localhost:3000/?url=https://bckyrdbbq.com/");
            if (response.IsSuccessStatusCode)
            {
               var content = await response.Content.ReadAsStringAsync();
            }
            //HtmlWeb web = new HtmlWeb();
            //web.UseCookies = true;
            //var jlkl = await web.LoadFromWebAsync(targetSiteUrl);
        }
    }
}

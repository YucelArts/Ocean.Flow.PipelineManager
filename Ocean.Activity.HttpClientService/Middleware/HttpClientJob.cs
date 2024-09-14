using Ocean.Activity.HttpClientService.Options;
using Ocean.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Activity.HttpClientService.Middleware
{
    public class HttpClientJob : IPipelineMiddleware
    {
        public async Task<object> InvokeAsync(object input, Func<Task<object>> next, object parameters)
        {
            var _pre = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpClientModel>(parameters.ToString());
            Console.WriteLine("Begin Job Started");

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(_pre.Url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Begin Job Completed: {result}");

                input = result;

            }

            return input;


        }
    }
}

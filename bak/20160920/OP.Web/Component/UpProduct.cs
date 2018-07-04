using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace OP.Web.Component
{
    internal sealed class HttpUp
    {
        public static async System.Threading.Tasks.Task<string> UpProduct(string URL,string jsonstring)
        {
            using (var myHttpClient = new HttpClient())
            {
                string responsestring = string.Empty;
                myHttpClient.BaseAddress = new Uri(URL);
                myHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
                request.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                await myHttpClient.SendAsync(request)
                    .ContinueWith(async responseTask =>
                    { responsestring = await responseTask.Result.Content.ReadAsStringAsync(); });
                return responsestring;
            }
        }
    }
    //public abstract class UpProduct
    //{
    //    public abstract async System.Threading.Tasks.Task<string> UpAction(string json);

    //}

    public class UpKwinerProduct
    {
        public static async System.Threading.Tasks.Task<string> UpAction(string json)
        {
            string URL = ConfigurationManager.AppSettings["UpOptionsProductURL"].ToString();
            return await HttpUp.UpProduct(URL, json);
        }
    }
}
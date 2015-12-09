using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace NestedWorld.Classes.Request
{
    public enum RequestType
    {
        GET,
        POST,
        DELETE,
    }
    public class HttpRequest
    {
        private string BaseAddress = "http://eip-api.kokakiwi.net/v1";
        protected Uri uri;
        protected string url;
        protected HttpWebRequest request;
        protected HttpStringContent content;

        protected Dictionary<string, string> collection;
        private RequestType type;

        public HttpRequest(string url, RequestType type)
        {
            this.url = BaseAddress + url;
            this.type = type;
        }

        public async Task<JObject> GetJsonAsync()
        {
            Debug.WriteLine(uri);
            using (var client = new System.Net.Http.HttpClient())
            {
                string jsonString = "";
                if (type == RequestType.GET)
                {
                    jsonString = await client.GetStringAsync(uri);
                    Debug.WriteLine(jsonString);
                }
                else if (type == RequestType.POST)
                {
                    var content = new FormUrlEncodedContent(collection);
                    System.Net.Http.HttpResponseMessage response = await client.PostAsync(uri, content);
                    Debug.WriteLine("response : " + response.ToString());
                    jsonString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(jsonString);
                }
                else if (type == RequestType.DELETE)
                {
                    System.Net.Http.HttpResponseMessage response = await client.DeleteAsync(uri);
                    Debug.WriteLine("response : " + response.StatusCode.ToString());
                    jsonString = await response.Content.ReadAsStringAsync();
                }
                Debug.WriteLine("jsonstring : " + jsonString);
                return JObject.Parse(jsonString);
            }
        }

        internal static string GetURLParam(Dictionary<string, string> Params)
        {
            string ret = "?";

            foreach (KeyValuePair<string, string> param in Params)
            {
                ret += param.Key + "=" + param.Value + "&";
            }

            ret.Remove(ret.Length - 1);

            return ret;
        }

       
    }
}

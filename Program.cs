using System;
using System.Net;
using System.Net.Http;

namespace DiscordWebhookIPUpdater_NETCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ip = "";
                try
                {
                    WebClient wc = new WebClient();
                    ip = wc.DownloadString("https://api.ipify.org");
                }
                catch (Exception err)
                {
                    ip = "ERROR CONNECTING TO API.IPIFY.ORG: " + err.Message + Environment.NewLine + err;
                }

                HttpClient Http = new HttpClient();
                string Webhook = "YOUR_WEBHOOK_LINK";
                string Webhook_Name = "YOUR_WEBHOOK_USERNAME";

                MultipartFormDataContent Payload = new MultipartFormDataContent();
                Payload.Add(new StringContent(Webhook_Name), "username");
                Payload.Add(new StringContent(string.Concat(new string[] {
                ip}
                )), "content");
                try
                {
                    HttpResponseMessage result = Http.PostAsync(Webhook, Payload).Result;
                }
                catch (Exception)
                {
                    return;
                }
            }
            catch
            {

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using GuitarTabsAndChords.Model;
using Xamarin.Forms;

namespace GuitarTabsAndChords.Mobile
{
    public class APIService
    {

        private string APIUrl;
        private readonly string _route;
        public APIService(string route)
        {
            _route = route;
            APIUrl = getApiURL();
        }

        public string getApiURL()
        {
            string local = "http://localhost:16/api";
            string API = "http://192.168.1.16:16/api";

            if (Device.RuntimePlatform == Device.UWP)
                return local;
            else
                return API;
        }


        public async Task<T> Get<T>(object search, string action = null)
        {
            var url = $"{APIUrl}/{_route}";
            if(action != null)
            {
                url += "/" + action;
            }

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{APIUrl}/{_route}/{id}";

            return await url.GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request, string action = null)
        {
            var url = $"{APIUrl}/{ _route}";
            if(action != null)
            {
                url += $"/{action}";
            }
            try
            {
                return await url.PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
            catch(Exception)
            {
                return default(T);

            }

        }

        public async Task<T> Update<T>(int id, object request, string action = null)
        {
            try
            {
                var url = $"{APIUrl}/{ _route}";
                if (action != null)
                {
                    url += $"/{action}";
                }
                url += $"/{id}";

                return await url.PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }

        }
        public async Task<T> Delete<T>(int id)
        {
            var url = $"{APIUrl}/{_route}/{id}";

            return await url.DeleteAsync().ReceiveJson<T>();
        }

    }
}

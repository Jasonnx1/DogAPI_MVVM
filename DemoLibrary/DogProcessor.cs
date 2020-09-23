using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class DogProcessor
    {

        public static async Task<DogModel> LoadDogImage()
        {
            string url;

            url = $"https://dog.ceo/api/breeds/image/random";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DogModel result = await response.Content.ReadAsAsync<DogModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}

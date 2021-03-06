﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SunProcessor
    {

        public static async Task<SunModel> LoadSunInformation(double latitude = 46.7201600, double longitude = -72.4203400)
        {
            string url;
           
            url = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}&date=today";
           

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();
                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}

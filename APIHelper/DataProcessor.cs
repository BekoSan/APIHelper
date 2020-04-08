using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace APIHelper
{
    /// <summary>
    /// This class is used to connect with api endpoints.
    /// </summary>
    public class DataProcessor
    {
        /// <summary>
        /// Get list of data stored in end point.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <param name="endPointURL">The url of api endpoint to get list of data.</param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> Get<T>(string endPointURL)
        {
            using (HttpResponseMessage response = await ApiHelperConfig.ApiClient.GetAsync(endPointURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<T>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Post an object content into the api.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <param name="content">The object that contains content data.</param>
        /// <param name="endPointURL">The url of api endpoint to post data in.</param>
        /// <returns></returns>
        public static async Task<bool> Post<T>(T content, string endPointURL)
        {
            bool output = false;

            var data = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());

            using (HttpResponseMessage response = await ApiHelperConfig.ApiClient.PostAsync(endPointURL, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Put an object content into the api.
        /// </summary>
        /// <typeparam name="T">Object Type.</typeparam>
        /// <param name="content">The object that contains content data.</param>
        /// <param name="endPointURL">The url of api endpoint to put data in.</param>
        /// <returns></returns>
        public static async Task<bool> Put<T>(T content, string endPointURL)
        {
            bool output = false;

            var data = new ObjectContent(content.GetType(), content, new JsonMediaTypeFormatter());

            using (HttpResponseMessage response = await ApiHelperConfig.ApiClient.PutAsync(endPointURL, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Deletes an object from  api data.
        /// </summary>
        /// <param name="endPointURL">The url of api endpoint to delete data.</param>
        /// <returns></returns>
        public static async Task<bool> Delete(string endPointURL)
        {
            bool output = false;

            using (HttpResponseMessage response = await ApiHelperConfig.ApiClient.DeleteAsync(endPointURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
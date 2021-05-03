using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Utils.APICaller
{
    public static class ApiCaller<T> where T : class
    {
        public static async Task<APICallResponseModel<T>> GetAsync(APICallRequestModel request)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var queryString = request.RequestObject.ToQueryString();
                    var url = RequestHelpers.GetRequestUrl(request.Url, request.Endpoint, queryString);

                    client.DefaultRequestHeaders.Accept.Clear();

                    if (!string.IsNullOrEmpty(request.Token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.ApplicationJson.GetDescription()));

                    if (request.RequestHeader != null)
                        foreach (var parameter in request.RequestHeader)
                        {
                            client.DefaultRequestHeaders.Add(parameter.Key, parameter.Value);
                        }

                    using (HttpResponseMessage httpResponse = (await client.GetAsync(url)))
                    {
                        using HttpContent content = httpResponse.Content;
                        var json = await content.ReadAsStringAsync();

                        var apiResponse = new APICallResponseModel<T>();
                        apiResponse.StatusCode = (int)httpResponse.StatusCode;

                        if (httpResponse.IsSuccessStatusCode)
                            apiResponse.Body = JsonConvert.DeserializeObject<T>(json);
                        else
                            apiResponse.Error = JsonConvert.DeserializeObject<T>(json); ;

                        return apiResponse;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<APICallResponseModel<T>> PostAsync(APICallRequestModel request)
        {
            try
            {
                using HttpClient client = new HttpClient();
                var url = RequestHelpers.GetRequestUrl(request.Url, request.Endpoint);
                var postContent = RequestHelpers.CreateRequestBodyContent(request.RequestObject, request.ContentType);

                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(request.Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.ApplicationJson.GetDescription()));

                if (request.RequestHeader != null)
                    foreach (var parameter in request.RequestHeader)
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation(parameter.Key, parameter.Value);
                    }

                var requestJson = JsonConvert.SerializeObject(request.RequestObject);

                using (HttpResponseMessage httpResponse = (await client.PostAsync(url, postContent)))
                {
                    using HttpContent content = httpResponse.Content;
                    var json = await content.ReadAsStringAsync();

                    var apiResponse = new APICallResponseModel<T>();
                    apiResponse.StatusCode = (int)httpResponse.StatusCode;

                    if (httpResponse.IsSuccessStatusCode)
                        apiResponse.Body = JsonConvert.DeserializeObject<T>(json);
                    else
                        apiResponse.Error = JsonConvert.DeserializeObject<T>(json); ;

                    return apiResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<APICallResponseModel<T>> PutAsync(APICallRequestModel request)
        {
            try
            {
                using HttpClient client = new HttpClient();
                var url = RequestHelpers.GetRequestUrl(request.Url, request.Endpoint);
                var postContent = RequestHelpers.CreateRequestBodyContent(request.RequestObject, request.ContentType);
                var contentJson = JsonConvert.SerializeObject(request);
                client.DefaultRequestHeaders.Accept.Clear();

                if (!string.IsNullOrEmpty(request.Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.ApplicationJson.GetDescription()));

                if (request.RequestHeader != null)
                    foreach (var parameter in request.RequestHeader)
                    {
                        client.DefaultRequestHeaders.Add(parameter.Key, parameter.Value);
                    }

                using (HttpResponseMessage httpResponse = (await client.PutAsync(url, postContent)))
                {
                    using HttpContent content = httpResponse.Content;
                    var json = await content.ReadAsStringAsync();

                    var apiResponse = new APICallResponseModel<T>();
                    apiResponse.StatusCode = (int)httpResponse.StatusCode;

                    if (httpResponse.IsSuccessStatusCode)
                        apiResponse.Body = JsonConvert.DeserializeObject<T>(json);
                    else
                        apiResponse.Error = JsonConvert.DeserializeObject<T>(json); ;

                    return apiResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<APICallResponseModel<T>> DeleteAsync(APICallRequestModel request)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var queryString = request.RequestObject.ToQueryString();
                    var url = RequestHelpers.GetRequestUrl(request.Url, request.Endpoint, queryString);

                    client.DefaultRequestHeaders.Accept.Clear();

                    if (!string.IsNullOrEmpty(request.Token))
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType.ApplicationJson.GetDescription()));

                    if (request.RequestHeader != null)
                        foreach (var parameter in request.RequestHeader)
                        {
                            client.DefaultRequestHeaders.Add(parameter.Key, parameter.Value);
                        }

                    using (HttpResponseMessage httpResponse = (await client.DeleteAsync(url)))
                    {
                        using HttpContent content = httpResponse.Content;
                        var json = await content.ReadAsStringAsync();

                        var apiResponse = new APICallResponseModel<T>();
                        apiResponse.StatusCode = (int)httpResponse.StatusCode;

                        if (httpResponse.IsSuccessStatusCode)
                            apiResponse.Body = JsonConvert.DeserializeObject<T>(json);
                        else
                            apiResponse.Error = JsonConvert.DeserializeObject<T>(json); ;

                        return apiResponse;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

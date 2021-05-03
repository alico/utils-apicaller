using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils.APICaller;

namespace Utils.APICaller.Test
{
    class Program
    {
        private static string url = "https://reqres.in/api/";
        private static string registerEndpoint = "register";
        private static string userEndpoint = "users";

        static async Task Main(string[] args)
        {

            await TestGetMethod();
            await TestPostMethod();
            await TestPutMethod();
            await TestDeleteMethod();
            await TestErrorRespnse();

        }
        private static APICallRequestModel GetRequestModel()
        {
            return new APICallRequestModel()
            {
                ContentType = ContentType.ApplicationJson,
                Endpoint = userEndpoint,
                Url = url,
            };
        }

        public static async Task<Root> TestGetMethod()
        {
            var requestModel = GetRequestModel();
            requestModel.RequestObject = new UserListRequestModel()
            {
                Page = 2
            };

            var response = await ApiCaller<Root>.GetAsync(requestModel);
            return response.Body;
        }

        public static async Task<UserRequestModel> TestPostMethod()
        {
            var requestModel = GetRequestModel();
            requestModel.RequestObject = new UserRequestModel()
            {
                Name = "John",
                Job = "Team Leader"
            };

            var response = await ApiCaller<UserRequestModel>.PostAsync(requestModel);
            return response.Body;
        }

        public static async Task<UserRequestModel> TestPutMethod()
        {
            var requestModel = GetRequestModel();
            requestModel.RequestObject = new UserRequestModel()
            {
                Name = "John",
                Job = "Team Leader"
            };

            var response = await ApiCaller<UserRequestModel>.PutAsync(requestModel);
            return response.Body;
        }

        public static async Task TestDeleteMethod()
        {
            var requestModel = GetRequestModel();
            requestModel.Endpoint = $"{requestModel.Endpoint}/2";
            var response = await ApiCaller<object>.DeleteAsync(requestModel);
        }

        public static async Task TestErrorRespnse()
        {
            var requestModel = GetRequestModel();
            requestModel.Endpoint =registerEndpoint;
            requestModel.RequestObject = new SignIn()
            {
                Email = "test@test"
            };

            var response = await ApiCaller<object>.PostAsync(requestModel);
        }
    }
}

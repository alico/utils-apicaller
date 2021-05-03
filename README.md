# <b>API Caller</b>
 
A RESTful API caller for .NET projects

Versions:  
Framework <b>.NET 5</b>  
Language <b>C# 9</b>

Test API

<b>Endpoints</b>

        private static string url = "https://reqres.in/api/";
        private static string registerEndpoint = "register";
        private static string userEndpoint = "users";


<b>HTTPGET</b>

        public static async Task<Root> TestGetMethod()
        {
            var requestModel = new APICallRequestModel()
            {
                ContentType = ContentType.ApplicationJson,
                Endpoint = userEndpoint,
                Url = url,
                RequestObject = new UserListRequestModel()
                {
                    Page = 2
                }
            };
           
            var response = await ApiCaller<Root>.GetAsync(requestModel);
            return response.Body;
        }

<b>HTTPPOST</b>

        public static async Task<UserRequestModel> TestPostMethod()
        {
           var requestModel = new APICallRequestModel()
           {
              ContentType = ContentType.ApplicationJson,
              Endpoint = userEndpoint,
              Url = url,
              RequestObject = new UserRequestModel()
              {
                  Name = "John",
                  Job = "Team Leader"
              }
           };
            var response = await ApiCaller<UserRequestModel>.PostAsync(requestModel);
            return response.Body;
        }

<b>HTTPPUT</b>

        public static async Task<UserRequestModel> TestPutMethod()
        {
            var requestModel = new APICallRequestModel()
            {
               ContentType = ContentType.ApplicationJson,
               Endpoint = userEndpoint,
               Url = url,
               RequestObject = new UserRequestModel()
               {
                  Name = "John",
                  Job = "Team Leader"
               };
            };

            var response = await ApiCaller<UserRequestModel>.PutAsync(requestModel);
            return response.Body;
        }

<b>HTTPDELETE</b>

        public static async Task TestDeleteMethod()
        {
            var requestModel = new APICallRequestModel()
            {
               ContentType = ContentType.ApplicationJson,
               Endpoint = $"{requestModel.Endpoint}/2";
               Url = url
            };
            var response = await ApiCaller<object>.DeleteAsync(requestModel);
        }


<b>Error State</b>

        public static async Task TestErrorRespnse()
        {
            var requestModel = new APICallRequestModel()
            {
               ContentType = ContentType.ApplicationJson,
               Endpoint = registerEndpoint,
               Url = url,
               RequestObject = new SignIn()
               {
                   Email = "test@test"
               };
            };
           
            var response = await ApiCaller<object>.PostAsync(requestModel);
        }

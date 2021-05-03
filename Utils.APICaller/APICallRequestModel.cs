using System.Collections.Generic;

namespace Utils.APICaller
{
    public class APICallRequestModel
    {
        public string Url { get; set; }
        public string Endpoint{ get; set; }
        public Dictionary<string, string> RequestHeader { get; set; }
        public object RequestObject { get; set; }
        public ContentType ContentType { get; set; }
        public string Token { get; set; }

        public APICallRequestModel()
        {
            ContentType = ContentType.ApplicationJson;
            Token = string.Empty;
            RequestHeader = new Dictionary<string, string>();
        }
    }
}

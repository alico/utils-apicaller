namespace Utils.APICaller
{
    public class APICallResponseModel<T> where T : class
    {
        public bool IsSucceded { get { return StatusCode >= 200 && StatusCode < 300; } }

        public int StatusCode { get; set; }
        public T Body { get; set; }
        public object Error { get; set; }
    }
}

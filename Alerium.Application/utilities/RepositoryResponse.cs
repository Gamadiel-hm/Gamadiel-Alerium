namespace Alerium.Application.utilities
{
    public class RepositoryResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }

        public static RepositoryResponse ResponseAll<T>(List<T> data, string message = null) where T : class 
        {
            return new RepositoryResponse() {Data = data, Message = message };
        }
        public static RepositoryResponse Response<T>(T data, string message = null) where T : class
        {
            return new RepositoryResponse() { Data = data, Message = message };
        }
    }
}

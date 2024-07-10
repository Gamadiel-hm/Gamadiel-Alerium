namespace Alerium.Presentation.Utilities
{
    public class ApiResponse
    {
        private ApiResponse(Object data, InfoResponse infoResponse)
        {
            Data = data;
            InfoResponse = infoResponse;
        }

        public Object Data { get; set; }
        public InfoResponse InfoResponse { get; set; }

        public static ApiResponse ResponseAll<T>(List<T> data, int status, int page, string message = null) where T : class
        {
            InfoResponse response = new ()
            {
                Status = status,
                Message = message,
                Page = page,
                Results = data.Count
            };

            ApiResponse baseResponse = new(data, response);

            return baseResponse;
        }

        public static ApiResponse ResponseById<T>(T data, int status, string message = null) where T : class
        {
            InfoResponse response = new()
            {
                Status = status,
                Message = message,
                Page = 1,
                Results = 1
            };

            ApiResponse baseResponse = new(data, response);
            return baseResponse;
        }

        public static ApiResponse Response(int status, object data, string message = null)
        {
            InfoResponse response = new()
            {
                Status = status,
                Message = message,
                Page = 1,
                Results = 1
            };

            ApiResponse baseResponse = new(data, response);
            return baseResponse;
        }

    }
}

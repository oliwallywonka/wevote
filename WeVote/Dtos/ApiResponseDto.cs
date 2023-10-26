using System.Net;

namespace WeVote.Dtos
{
    public class ApiResponseDto<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}

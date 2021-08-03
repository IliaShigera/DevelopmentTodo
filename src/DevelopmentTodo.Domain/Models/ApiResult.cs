using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace DevelopmentTodo.Domain.Models
{
    public class ApiResult<T>
    {
        [JsonPropertyName("succeeded")]
        public bool Succeeded { get; set; }


        [JsonPropertyName("code")]
        public HttpStatusCode Code { get; set; }


        [JsonPropertyName("errors")]
        public IEnumerable<string> Errors { get; set; }


        [JsonPropertyName("data")]
        public T Data { get; set; }

        private ApiResult(bool succeeded, HttpStatusCode code, IEnumerable<string> errors, T data)
        {
            Succeeded = succeeded;
            Code = code;
            Errors = errors;
            Data = data;
        }

        public ApiResult() { }

        public static ApiResult<T> Success(T data)
            => new ApiResult<T>(true, HttpStatusCode.OK, Enumerable.Empty<string>(), data);

        public static ApiResult<T> Failure(HttpStatusCode code, IEnumerable<string> errors)
            => new ApiResult<T>(false, code, errors, default);
    }
}

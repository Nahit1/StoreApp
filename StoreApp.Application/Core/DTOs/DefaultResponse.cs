using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Application.Core.DTOs
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }

        public string ResultText { get; set; }
    }

    public abstract class PaginationResponse : BaseResponse
    {
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
    }

    public class DefaultPaginationResponse<T> : PaginationResponse
    {
        public T Result { get; set; }

        public static DefaultPaginationResponse<T> Successful(
            T data,
            int pageCount,
            int totalCount
        ) =>
            new()
            {
                Success = true,
                ResultText = "Success",
                Result = data,
                PageCount = pageCount,
                TotalCount = totalCount
            };

        public static DefaultPaginationResponse<T> Failure(string resultMessage) =>
            new DefaultPaginationResponse<T> { Success = false, ResultText = resultMessage };
    }

    public class DefaultResponse<T> : BaseResponse
    {
        public T Result { get; set; }

        public static DefaultResponse<T> Successful() =>
            new DefaultResponse<T> { Success = true, ResultText = "Success" };

        public static DefaultResponse<T> Successful(string result) =>
            new DefaultResponse<T> { Success = true, ResultText = result };

        public static DefaultResponse<T> Successful(T data) =>
            new DefaultResponse<T>
            {
                Success = true,
                ResultText = "Success",
                Result = data
            };

        public static DefaultResponse<T> Failure(string resultMessage) =>
            new DefaultResponse<T> { Success = false, ResultText = resultMessage };

        public static DefaultResponse<T> Failure(List<string> errors) =>
            new DefaultResponse<T> { Success = false, ResultText = "Fail", };
    }

    public class DefaultResponse : BaseResponse
    {
        public static DefaultResponse Successful() =>
            new DefaultResponse { Success = true, ResultText = "Success" };

        public static DefaultResponse Successful(string result) =>
            new DefaultResponse { Success = true, ResultText = result };

        public static DefaultResponse Failure(string resultMessage) =>
            new DefaultResponse { Success = false, ResultText = resultMessage };

        public static DefaultResponse Failure(List<string> errors) =>
            new DefaultResponse { Success = false, ResultText = "Fail" };
    }
}

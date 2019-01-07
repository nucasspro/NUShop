using RestSharp;
using System;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Extensions
{
    public static class RestClientExtensions
    {
        public static Task<IRestResponse> ExecuteTaskAsync(this RestClient restClient, RestRequest request)
        {
            if (restClient == null)
                throw new NullReferenceException();

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            restClient.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                    taskCompletionSource.TrySetException(response.ErrorException);
                else
                    taskCompletionSource.TrySetResult(response);
            });

            return taskCompletionSource.Task;
        }
    }
}
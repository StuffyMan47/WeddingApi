using Application.Exception.Base;
using Application.Extensions.HttpResponseDes;
using WeddingApi.Models;

namespace Tests.Base;

public partial class TestAppFactory
{
    private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
    {

        if (typeof(T) == typeof(byte[]) && response.IsSuccessStatusCode)
        {
            await using var stream = await response.Content.ReadAsStreamAsync();
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return (T)Convert.ChangeType(ms.ToArray(), typeof(T));
        }

        var responseData = await response.DeserializeResponseAsync<BaseApiResponseModel<T>>();

        if (!response.IsSuccessStatusCode)
            throw new InternalServerException($"Запрос завершился неудачей.\r {responseData?.Errors?.Message}. Подробности: [{string.Join(",", responseData?.Errors?.Descriptions ?? [])}]");

        if (responseData == null || responseData.Data == null)
            throw new InternalServerException("Ответ не содержит данных");

        return responseData.Data;
    }

    private static async Task ParseResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var responseData = await response.DeserializeResponseAsync<ApiResponseModel>();
            throw new InternalServerException($"Запрос завершился неудачей.\r {responseData?.Errors?.Message}. Детали: {string.Join(",", responseData?.Errors?.Descriptions ?? [])}");
        }

    }
}
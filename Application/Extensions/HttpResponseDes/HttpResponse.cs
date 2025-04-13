using System.Text.Json;
using System.Xml.Serialization;
using Application.JsonSerialization;

namespace Application.Extensions.HttpResponseDes;

public static class HttpResponseMessageExtensions
{
    public static async Task<T?> DeserializeResponseAsync<T>(
        this Task<HttpResponseMessage> message,
        JsonSerializerOptions? options = null)
        where T : class
    {
        if (options == null)
            options = JsonSerializationOptions.GetDefault();
        return await (await message).DeserializeResponseAsync<T>(options);
    }

    public static async Task<T?> DeserializeResponseAsync<T>(
        this HttpResponseMessage message,
        JsonSerializerOptions? options = null)
        where T : class
    {
        if (options == null)
            options = JsonSerializationOptions.GetDefault();
        string json = await message.Content.ReadAsStringAsync();
        return !(typeof (T) == typeof (string)) ? JsonSerializer.Deserialize<T>(json, options) : json as T;
    }

    public static async Task<T?> DeserializeXmlResponseAsync<T>(
        this Task<HttpResponseMessage> message)
        where T : class
    {
        return await (await message).DeserializeXmlResponseAsync<T>();
    }

    private static async Task<T?> DeserializeXmlResponseAsync<T>(this HttpResponseMessage message) where T : class
    {
        string s = await message.Content.ReadAsStringAsync();
        T obj;
        using (StringReader stringReader = new StringReader(s))
            obj = new XmlSerializer(typeof (T)).Deserialize((TextReader) stringReader) as T;
        return obj;
    }
}
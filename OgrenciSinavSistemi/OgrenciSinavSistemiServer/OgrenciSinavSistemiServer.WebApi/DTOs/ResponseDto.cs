namespace OgrenciSinavSistemiServer.WebApi.DTOs;

public sealed class ResponseDto<T>
{
    public T? Data { get; set; }
}

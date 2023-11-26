using GenericFileService.Files;
using Microsoft.AspNetCore.Http;
using RestaurantServer.Domain.Abstractions;
using RestaurantServer.Domain.Shared;


namespace RestaurantServer.Domain.Produts;
public sealed class Product : Entity
{
    public Product(
         string name,
         decimal price,
         string category) : base(Guid.NewGuid())
    {
        Name = new(name);
        Price = new(price);
        Category = category;
    }

    public Name Name { get; private set; }
    public string? CoverImage { get; private set; }
    public Money Price { get; private set; }
    public string Category { get; private set; }

    public void SetCoverImage(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();

            // JPG dosyaları genellikle FF D8 FF DB veya FF D8 FF E0 ile başlar
            if (fileBytes.Length >= 3 && fileBytes[0] == 0xff && fileBytes[1] == 0xd8 && fileBytes[2] == 0xff && (fileBytes[3] == 0xdb || fileBytes[3] == 0xe0 || fileBytes[3] == 0xe1))
            {
                
            }
            if (fileBytes.Length >= 8 && fileBytes[0] == 0x89 && fileBytes[1] == 0x50 && fileBytes[2] == 0x4e && fileBytes[3] == 0x47 && fileBytes[4] == 0x0d && fileBytes[5] == 0x0a && fileBytes[6] == 0x1a && fileBytes[7] == 0x0a)
            {

            }
            else
            {
                throw new ArgumentException("Sadece JPG ve PNG Formatında dosya yükleyebilirsiniz!");
            }
        }

        CoverImage = FileService.FileSaveToServer(file, @"C:\CareerHubt\RestaurantApp\RestaurantClient\src\assets\");
    }

}

public sealed record Name
{
    public string Value { get; init; }

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Ürün adı boş olamaz!");
        }

        if(value.Length < 3)
        {
            throw new ArgumentException("Ürün adı 3 karakterden küçük olamaz!");
        }

        Value = value;
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantServer.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public IActionResult Test(IFormFile file)
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

        return NoContent();
    }
}

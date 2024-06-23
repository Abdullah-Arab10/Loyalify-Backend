using Loyalify.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Loyalify.Infrastructure.Services;

public class PhotoService(IWebHostEnvironment environment) : IPhotoService
{
    private readonly IWebHostEnvironment _environment = environment;
    private static string GetUniqueFileName(string fileName)
    {
        var guid = Guid.NewGuid().ToString();
        var extension = Path.GetExtension(fileName).ToLower();
        return guid + extension;
    }

    public string SaveImage(IFormFile imageFile)
    {

        var uniqueFileName = GetUniqueFileName(imageFile.FileName);
        var filePath = Path.Combine(_environment.ContentRootPath, "Uploads");

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        var fileWithPath = Path.Combine(filePath, uniqueFileName);
        var stream = new FileStream(fileWithPath, FileMode.Create);
        imageFile.CopyTo(stream);
        stream.Close();
        var name = "/Uploads/" + Path.GetFileName(uniqueFileName);

        return name;
    }
}

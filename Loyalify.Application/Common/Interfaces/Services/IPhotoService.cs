using Microsoft.AspNetCore.Http;

namespace Loyalify.Application.Common.Interfaces.Services;

public interface IPhotoService
{
    public string SaveImage(IFormFile imageFile);
}

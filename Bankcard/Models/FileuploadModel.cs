using Microsoft.AspNetCore.Http;

namespace Bankcard.Models
{
    public class FileuploadModel
    {
        public IFormFile Image { get; set; }
    }
}

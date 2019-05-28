using Microsoft.AspNetCore.Http;

namespace Exam1.Models
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public IFormFile Avatar { get; set; }
    }
}

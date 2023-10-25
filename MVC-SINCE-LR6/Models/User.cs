using System.ComponentModel.DataAnnotations;

namespace mvcLR6.Models
{
    public class User
    {
        public string Name { get; set; }

        [Range(15, 90, ErrorMessage = "Less than 16 years old or bigger than 90")]
        public int Age { get; set; }
    }
}

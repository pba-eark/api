using System.ComponentModel.DataAnnotations;

namespace pba_api.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public String Name { get; set; }
    }
}

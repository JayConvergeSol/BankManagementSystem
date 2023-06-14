using System.ComponentModel.DataAnnotations;

namespace BankManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is Complasory")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is Complasory")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date Of Birth is Complasory")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address is Complasory")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Compalsory to add")]
        public string PhoneNumber { get; set; }
    }
}

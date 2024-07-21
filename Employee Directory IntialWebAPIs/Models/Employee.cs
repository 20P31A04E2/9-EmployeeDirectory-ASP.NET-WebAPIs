using System.ComponentModel.DataAnnotations;

namespace Concerns
{
    public class Employee
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Za-z\s]+$")]
        [Required]
        public string? FirstName { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        [Required]
        public string? LastName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [Required]
        public string? Email { get; set; }


        [RegularExpression(@"^\d{10}$")]
        public string? Phone { get; set; }


        [DataType(DataType.DateTime)]
        [Required]
        public DateTime JoinDate { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        [Required]
        public string? Location { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        [Required]
        public string? JobTitle { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        [Required]
        public string? Department { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string? Manager { get; set; }


        [RegularExpression(@"^[A-Za-z\s]+$")]
        public string? Project { get; set; }


    }
}

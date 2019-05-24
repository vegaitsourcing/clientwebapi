using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("client")]
    public class Client
    {
        [Key]
        [Column("ClientId")]
        public Guid Id { get; set; }

        [NotMapped]
        public string ClientName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Email can't be longer than 60 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(60, ErrorMessage = "First name can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(60, ErrorMessage = "Last name can't be longer than 60 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(60, ErrorMessage = "Phone number can't be longer than 60 characters")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Mobile phone number is required")]
        [StringLength(60, ErrorMessage = "Mobile phone number can't be longer than 60 characters")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Street address is required")]
        [StringLength(100, ErrorMessage = "Street address can't be longer than 100 characters")]
        public string StreetAddr { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(60, ErrorMessage = "City can't be longer than 60 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(60, ErrorMessage = "State can't be longer than 60 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(60, ErrorMessage = "Country can't be longer than 60 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Industry is required")]
        [StringLength(60, ErrorMessage = "Industry can't be longer than 60 characters")]
        public string Industry { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200, ErrorMessage = "Description can't be longer than 200 characters")]
        public string Description { get; set; }
    }
}

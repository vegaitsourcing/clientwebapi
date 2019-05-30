using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("user")]
    public class User : IEntity
    {
        [Key]
        [Column("UserId")]
        public Guid Id { get; set; }

        public string Username { get; set; }
        
        public string HashedPassword { get; set; }

        public string Salt { get; set; }
    }
}

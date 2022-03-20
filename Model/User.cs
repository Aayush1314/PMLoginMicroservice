using System.ComponentModel.DataAnnotations;

namespace LoginMicroservice.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }

    }
}

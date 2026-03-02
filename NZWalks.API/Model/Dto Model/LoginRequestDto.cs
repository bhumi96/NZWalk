using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.Dto_Model
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Uusename { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

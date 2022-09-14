using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.MODELS
{
    [Serializable]
    public class User
    {
        private const char DELIMITER = '|';
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Insert password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Insert email")]
        [EmailAddress(ErrorMessage ="Not email type")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insert phonenumber")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Insert address")]
        public string Address { get; set; }

        public string Details { get; set; }
        public string FirstName
        {
            get
            {
                return UserName.Split(' ')[0];
            }        
        }
        public string LastName
        {
            get
            {
                if (!UserName.Contains(" "))
                    return UserName.Split(' ')[0];

                return UserName.Split(' ')[1];
            }
        }
        public override string ToString() => $"{Id}{DELIMITER}{UserName}";
    }
}

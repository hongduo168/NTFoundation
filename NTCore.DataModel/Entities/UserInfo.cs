using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 注册用户
    /// </summary>
    [Table((DataEnum.DbTablePrefix + "User"))]
    public class UserInfo : SiteEntity
    {
        [Required(AllowEmptyStrings = true), MaxLength(50)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(50)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(50)]
        public string Nickname { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(255)]
        public string Avatar { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        [Required]
        public bool IsChecked { get; set; }


        [Required]
        public DataEnum.UserLevelType Level { get; set; }

    }
}

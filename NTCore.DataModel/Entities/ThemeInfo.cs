using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 主题
    /// </summary>
    [Table((DataEnum.DbTablePrefix + "Theme"))]
    public class ThemeInfo : BaseEntity
    {
        [Required(AllowEmptyStrings = true), MaxLength(255)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(255)]
        public string Folder { get; set; }
    }
}

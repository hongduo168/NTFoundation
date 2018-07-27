using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 系统语言支持
    /// </summary>
    [Table((DataEnum.DbTablePrefix + "Language"))]
    public class LanguageInfo : BaseEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string CultureName { get; set; }

    }
}

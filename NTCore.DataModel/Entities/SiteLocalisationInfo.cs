using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 多主题支持
    /// </summary>
    [Table(DataEnum.DbTablePrefix + "SiteLocalisation")]
    public class SiteLocalisationInfo : SiteEntity
    {
        [Required, MaxLength(255)]
        public string ThemeId { get; set; }

        [Required, MaxLength(255)]
        public string LanguageId { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string MetaDescription { get; set; }

        [Required, MaxLength(255)]
        public string MetaKeywords { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 多站点支持
    /// </summary>
    [Table((DataEnum.DbTablePrefix + "Site"))]
    public class SiteInfo : BaseEntity
    {
        /// <summary>
        /// 站点名称
        /// </summary>
        [Required(AllowEmptyStrings = true), MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 站点地址
        /// </summary>
        [Required, MaxLength(255)]
        public string Url { get; set; }

        [Required, MaxLength(255)]
        public string Copyright { get; set; }

        public string LogoUrl { get; set; }


        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string MetaDescription { get; set; }

        [Required, MaxLength(255)]
        public string MetaKeywords { get; set; }


        /// <summary>
        /// 站点状态
        /// DataEnum.SiteStateType
        /// </summary>
        [Required]
        public int SiteState { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [Required]
        public DateTime ExpireDate { get; set; }




        [NotMapped]
        public virtual ICollection<SiteLocalisationInfo> SiteLocalisations { get; set; } = new List<SiteLocalisationInfo>();
    }
}

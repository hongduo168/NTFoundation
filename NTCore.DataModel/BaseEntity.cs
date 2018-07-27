using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NTCore.DataModel
{
    /// <summary>
    /// 表基础
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key, Column(nameof(Id)), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required, Column(nameof(AddDate))]
        public DateTime AddDate { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required, Column(nameof(UpdateDate))]

        public DateTime UpdateDate { get; set; }

        [Required, Column(nameof(AddUserId))]
        public int AddUserId { get; set; }


        [Required, Column(nameof(LastUpdateUserId))]
        public int LastUpdateUserId { get; set; }

        /// <summary>
        /// 状态
        /// DataEnum.DataStateType
        /// </summary>
        [Required, Column(nameof(DataState))]
        public DataEnum.DataStateType DataState { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        [Required, Column(nameof(DataSort))]
        public int DataSort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Required, Column(nameof(IsShow))]
        public bool IsShow { get; set; }

    }

    public partial class SiteEntity : BaseEntity
    {
        [Required, DefaultValue(0), Column(nameof(SiteId))]
        public long SiteId { get; set; }
    }
}

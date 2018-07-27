using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NTCore.DataModel.Entities
{
    /// <summary>
    /// 收藏夹
    /// </summary>
    public class FavoriteInfo : SiteEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required, MaxLength(255)]
        public string Title { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        [Required, MaxLength(30)]
        public string GroupName { get; set; }

        /// <summary>
        /// 关联ID
        /// </summary>
        public long RelationId { get; set; }

        /// <summary>
        /// 关联类型
        /// </summary>
        public DataEnum.FavoriteRelationType RelationType { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        [Required, MaxLength(255)]
        public string LinkUrl { get; set; }

    }
}

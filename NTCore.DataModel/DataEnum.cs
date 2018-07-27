using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NTCore.DataModel
{
    public class DataEnum
    {
        /// <summary>
        /// 数据库默认值
        /// </summary>
        public const string DbTablePrefix = ("NF_");

        /// <summary>
        /// 全局日期格式
        /// </summary>
        public static readonly string DateFormatString = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 数据库默认值
        /// </summary>
        public const string DbDefaultDate = ("1970-01-01 00:00:00");


        #region model枚举

        public enum SiteStateType
        {
            /// <summary>
            /// 正常访问
            /// </summary>
            Normal = 0,


            /// <summary>
            /// 暂停服务
            /// </summary>
            PauseService = 10,


            /// <summary>
            /// 停止服务
            /// </summary>
            StopService = 20,
        }



        /// <summary>
        /// 数据状态
        /// </summary>
        public enum DataStateType
        {
            /// <summary>
            /// 删除
            /// </summary>
            Delete = 0,

            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1,
        }

        /// <summary>
        /// 收藏信息类型
        /// </summary>
        public enum FavoriteRelationType
        {
            [Description("微博动态")]
            Weibo = 1,

            [Description("新闻信息")]
            Information = 10
        }

        public enum UserLevelType
        {
            [Description("个人用户")]
            Persional = 1,

            [Description("企业用户")]
            Enterpress = 10,
        }
        #endregion

    }
}

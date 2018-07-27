using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.DataModel
{
    public class SystemStatus
    {
        /// <summary>
        /// 系统繁忙
        /// </summary>
        public const int Error = -1;

        /// <summary>
        /// 请求成功
        /// </summary>
        public const int Success = 0;


        public readonly static Dictionary<int, string> Description = new Dictionary<int, string>
        {
            { Error, "系统繁忙" },
            { Success, string.Empty },
        };


    }
}

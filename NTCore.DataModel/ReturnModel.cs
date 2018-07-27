using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NTCore.DataModel
{
    public class ReturnModel<T> where T : class, new()
    {
        protected Stopwatch sw = new Stopwatch();

        public ReturnModel(int errorCode)
        {
            sw.Start();
            this.ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }

        public string Message
        {
            get
            {
                if (SystemStatus.Description.ContainsKey(this.ErrorCode))
                {
                    return SystemStatus.Description[this.ErrorCode];
                }

                return string.Empty;
            }
        }

        public T Data { get; set; }

        /// <summary>
        /// 接口处理时间
        /// </summary>
        public long Milliseconds
        {
            get
            {
                sw.Stop();
                return sw.ElapsedMilliseconds;
            }
        }


    }
}

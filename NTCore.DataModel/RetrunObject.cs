using System;
using System.Collections.Generic;
using System.Text;

namespace NTCore.DataModel
{
    public class RetrunObject : ReturnModel<object>
    {
        public RetrunObject(int errorCode) : base(errorCode)
        {
        }
    }
}

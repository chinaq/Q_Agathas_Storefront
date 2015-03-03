using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Infrastructure.Domain
{
    /// <summary>
    /// 值类型的异常
    /// </summary>
    public class ValueObjectIsInvalidException:Exception
    {
        public ValueObjectIsInvalidException(string message) : base(message) { }
    }
}

using Api.Weixin.Pay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    public interface IWePayConfigAdapter
    {
        WePayConfig Get();
    }
}

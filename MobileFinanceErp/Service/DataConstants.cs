using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Service
{
    public struct DataConstants
    {
        public struct CodeMaintain
        {
            public const string Customer = "Customer";
        }

        public struct FinanceStatus
        {
            public const string Active = "FN_AC";
            public const string Closed = "FN_CS";
            public const string Paid = "FN_PD";
        }
    }
}
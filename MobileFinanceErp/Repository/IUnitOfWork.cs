using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
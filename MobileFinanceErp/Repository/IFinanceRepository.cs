using MobileFinanceErp.Models;
using MobileFinanceErp.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IFinanceRepository : IBaseTenantRepository<FinanceModel>
    {
        bool IsPageNumberValid(string pageNo, string bookNo);
        IQueryable<FinanceDetailsModel> GetFinanceDetails(int financeId);
        decimal GetActualEmiAmount(int financeId);
        decimal GetCarryForward(int financeId);
        decimal GetLoanRemainingAmount(int financeId);
        FinanceDetailsModel GetFinanceDetailCreate();
        void AddReceivedAmount(FinanceDetailsModel entity);
        decimal GetLoanAmount(int financeId);
        decimal GetMonthCollectedAmount(int month, int year);
        decimal GetTotalLoanAmount();
    }

    public class FinanceRepository : BaseTenantRepository<FinanceModel>, IFinanceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FinanceRepository(ApplicationDbContext applicationDbContext, IIdentityHelper identityHelper)
            : base(applicationDbContext, identityHelper)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddReceivedAmount(FinanceDetailsModel entity)
        {
            _applicationDbContext.Set<FinanceDetailsModel>().Add(entity);
        }

        public decimal GetActualEmiAmount(int financeId)
        {
            return GetAllNoTracking()
                .Where(w => w.Id == financeId)
                .Select(w => w.EMI)
                .DefaultIfEmpty()
                .FirstOrDefault();
        }

        public decimal GetCarryForward(int financeId)
        {
            throw new NotImplementedException();
        }

        public FinanceDetailsModel GetFinanceDetailCreate()
        {
            return _applicationDbContext.Set<FinanceDetailsModel>().Create();
        }

        public IQueryable<FinanceDetailsModel> GetFinanceDetails(int financeId)
        {
            return _applicationDbContext.Set<FinanceDetailsModel>()
                .Where(w => w.FinanceMasterId == financeId);
        }

        public decimal GetLoanAmount(int financeId)
        {
            return GetAllNoTracking().Where(w => w.Id == financeId).Select(w => w.LoanAmount).DefaultIfEmpty().FirstOrDefault();
        }

        public decimal GetLoanRemainingAmount(int financeId)
        {
            decimal loanAmount = GetLoanAmount(financeId);
            decimal recievedAmount = _applicationDbContext.Set<FinanceDetailsModel>().Where(w => w.FinanceMasterId == financeId).Select(w => w.ReceivedAmount).DefaultIfEmpty().Sum(w => w);
            return loanAmount - recievedAmount;
        }

        public decimal GetMonthCollectedAmount(int month, int year)
        {
            //var startDate = new DateTime(year, month, 1);
            //var endDate = startDate.AddMonths(1).AddDays(-1);

            return _applicationDbContext.Set<FinanceDetailsModel>()
                //.Where(w => DbFunctions.TruncateTime(w.ReceivedDate) >= DbFunctions.TruncateTime(startDate) &&
                //DbFunctions.TruncateTime(w.ReceivedDate) <= DbFunctions.TruncateTime(endDate))
                .Select(w => w.ReceivedAmount).DefaultIfEmpty().Sum();
        }

        public decimal GetTotalLoanAmount()
        {
            return GetAllNoTracking().Select(w => w.LoanAmount).DefaultIfEmpty().Sum();
        }

        public bool IsPageNumberValid(string pageNo, string bookNo)
        {
            return GetAllNoTracking().Where(w => w.PageNo == pageNo && w.BookNo == bookNo).Count() == 0;
        }
    }
}
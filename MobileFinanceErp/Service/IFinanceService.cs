using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface IFinanceService
    {
        List<FinanceListViewModel> GetAll();
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        Tuple<bool, int> Insert(AddEditFinanceViewModel model);
        AddEditFinanceViewModel GetById(int id);
        bool Update(AddEditFinanceViewModel model);
        bool Delete(int id);
        bool IsPageNumberValid(string pageNo, string bookNo);
        List<ReceiveFinanceViewModel> GetFinanceDetails(int financeId);
        ReceiveFinanceViewModel GetReceiveModel(int financeId);
        bool ReceiveAmount(ReceiveFinanceViewModel model, string userId);
        decimal GetMonthCollectedAmount(int month, int year);
        decimal GetMonthTotalAmount(int month, int year);
    }

    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _FinanceRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public FinanceService(IFinanceRepository FinanceRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _FinanceRepository = FinanceRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            var entity = _FinanceRepository.GetById(id);
            _FinanceRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<FinanceModel, FinanceListViewModel>
                (_FinanceRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public List<FinanceListViewModel> GetAll()
        {
            return _dataMapper.Project<FinanceModel, FinanceListViewModel>
                (_FinanceRepository.GetAllNoTracking()).ToList();
        }

        public AddEditFinanceViewModel GetById(int id)
        {
            var entity = _FinanceRepository.GetById(id);
            return _dataMapper.Map<FinanceModel, AddEditFinanceViewModel>(entity);
        }

        public List<ReceiveFinanceViewModel> GetFinanceDetails(int financeId)
        {
            IQueryable<FinanceDetailsModel> data = _FinanceRepository.GetFinanceDetails(financeId);
            return _dataMapper.Project<FinanceDetailsModel, ReceiveFinanceViewModel>(data)
                .ToList();
        }

        public decimal GetMonthCollectedAmount(int month, int year)
        {
            return _FinanceRepository.GetMonthCollectedAmount(month, year);
        }

        public decimal GetMonthTotalAmount(int month, int year)
        {
            return _FinanceRepository.GetTotalLoanAmount();
        }

        public ReceiveFinanceViewModel GetReceiveModel(int financeId)
        {
            var result = new ReceiveFinanceViewModel
            {
                FinanceMasterId = financeId,
                ReceivedDate = DateTime.Now,
            };

            result.ActualEmiAmount = _FinanceRepository.GetActualEmiAmount(financeId);
            result.CarryForwardAmount = 0;//TODO: Need to discuss with geet. _FinanceRepository.GetCarryForward(financeId);
            result.RemainingAmount = _FinanceRepository.GetLoanRemainingAmount(financeId);
            result.EMIAmount = result.RemainingAmount > result.ActualEmiAmount ? result.ActualEmiAmount - result.CarryForwardAmount : result.RemainingAmount;
            result.RemainingAmountAfterEMI = result.RemainingAmount - result.EMIAmount;
            result.LoanAmount = _FinanceRepository.GetLoanAmount(financeId);
            return result;
        }

        public Tuple<bool, int> Insert(AddEditFinanceViewModel model)
        {
            var entity = _FinanceRepository.Create();
            _dataMapper.Map(model, entity);
            _FinanceRepository.Insert(entity);
            return new Tuple<bool, int>(_unitOfWork.Commit() > 0, entity.Id);
        }

        public bool IsPageNumberValid(string pageNo, string bookNo)
        {
            return _FinanceRepository.IsPageNumberValid(pageNo, bookNo);
        }

        public bool ReceiveAmount(ReceiveFinanceViewModel model, string userId)
        {
            FinanceDetailsModel entity = _FinanceRepository.GetFinanceDetailCreate();
            entity.CreatedOn = DateTime.Now;
            entity.FinanceMasterId = model.FinanceMasterId;
            entity.Notes = model.Notes;
            entity.ReceivedAmount = model.EMIAmount;
            entity.ReceivedBy = userId;
            entity.ReceivedDate = model.ReceivedDate;

            _FinanceRepository.AddReceivedAmount(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditFinanceViewModel model)
        {
            var entity = _FinanceRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _FinanceRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
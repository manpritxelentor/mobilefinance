using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface IFinanceService
    {
        List<FinanceListViewModel> GetAll();
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        bool Insert(AddEditFinanceViewModel model);
        AddEditFinanceViewModel GetById(int id);
        bool Update(AddEditFinanceViewModel model);
        bool Delete(int id);
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

        public bool Insert(AddEditFinanceViewModel model)
        {
            var entity = _FinanceRepository.Create();
            _dataMapper.Map(model, entity);
            _FinanceRepository.Insert(entity);
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
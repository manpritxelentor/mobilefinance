using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Service
{
    public interface IGuarantorService
    {
        List<GuarantorListViewModel> GetAll();
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        bool Insert(AddEditGuarantorViewModel model);
        AddEditGuarantorViewModel GetById(int id);
        bool Update(AddEditGuarantorViewModel model);
        bool Delete(int id);
    }

    public class GuarantorService : IGuarantorService
    {
        private readonly IGuarantorRepository _guarantorRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public GuarantorService(IGuarantorRepository guarantorRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _guarantorRepository = guarantorRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            var entity = _guarantorRepository.GetById(id);
            _guarantorRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<GuarantorModel, GuarantorListViewModel>
                (_guarantorRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public List<GuarantorListViewModel> GetAll()
        {
            return _dataMapper.Project<GuarantorModel, GuarantorListViewModel>
                (_guarantorRepository.GetAllNoTracking()).ToList();
        }

        public AddEditGuarantorViewModel GetById(int id)
        {
            var entity = _guarantorRepository.GetById(id);
            return _dataMapper.Map<GuarantorModel, AddEditGuarantorViewModel>(entity);
        }

        public bool Insert(AddEditGuarantorViewModel model)
        {
            var entity = _guarantorRepository.Create();
            _dataMapper.Map(model, entity);
            _guarantorRepository.Insert(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditGuarantorViewModel model)
        {
            var entity = _guarantorRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _guarantorRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
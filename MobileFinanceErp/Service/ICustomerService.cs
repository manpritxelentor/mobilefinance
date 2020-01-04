using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface ICustomerService
    {
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        List<CustomerListViewModel> GetAll();
        Tuple<bool, int> Insert(AddEditCustomerViewModel model);
        AddEditCustomerViewModel GetById(int id);
        bool Update(AddEditCustomerViewModel model);
        bool Delete(int id);
        int GetCustomerCount();
        string GetNewCustomerIdentityNumber();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICodeMaintainRepository _codeMaintainRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupCodesRepository _groupCodesRepository;

        public CustomerService(ICustomerRepository customerRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork
            , ICodeMaintainRepository codeMaintainRepository
            , IGroupCodesRepository groupCodesRepository)
        {
            _customerRepository = customerRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
            _codeMaintainRepository = codeMaintainRepository;
            _groupCodesRepository = groupCodesRepository;
        }

        public bool Delete(int id)
        {
            var entity = _customerRepository.GetById(id);
            _customerRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<CustomerModel, CustomerListViewModel>
                (_customerRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public List<CustomerListViewModel> GetAll()
        {
            return _dataMapper.Project<CustomerModel, CustomerListViewModel>
                (_customerRepository.GetAllNoTracking()).ToList();
        }

        public AddEditCustomerViewModel GetById(int id)
        {
            var entity = _customerRepository.GetById(id);
            return _dataMapper.Map<CustomerModel, AddEditCustomerViewModel>(entity);
        }

        public int GetCustomerCount()
        {
            return _customerRepository.GetAllNoTracking().Count();
        }

        public string GetNewCustomerIdentityNumber()
        {
            return _codeMaintainRepository.GetNewCustomerIdentityNumber();
        }

        public Tuple<bool, int> Insert(AddEditCustomerViewModel model)
        {
            var entity = _customerRepository.Create();
            _dataMapper.Map(model, entity);
            model.CustomerIdentificationNumber = _codeMaintainRepository.GetNewCustomerIdentityNumber();
            _customerRepository.Insert(entity);
            _codeMaintainRepository.BurnCustomerNumber();
            return new Tuple<bool, int>(_unitOfWork.Commit() > 0, entity.Id);
        }

        public bool Update(AddEditCustomerViewModel model)
        {
            var entity = _customerRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _customerRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
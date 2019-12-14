using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface ICustomerService
    {
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        List<CustomerListViewModel> GetAll();
        bool Insert(AddEditCustomerViewModel model);
        AddEditCustomerViewModel GetById(int id);
        bool Update(AddEditCustomerViewModel model);
        bool Delete(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository CustomerRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _CustomerRepository = CustomerRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            var entity = _CustomerRepository.GetById(id);
            _CustomerRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<CustomerModel, CustomerListViewModel>
                (_CustomerRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public List<CustomerListViewModel> GetAll()
        {
            return _dataMapper.Project<CustomerModel, CustomerListViewModel>
                (_CustomerRepository.GetAllNoTracking()).ToList();
        }

        public AddEditCustomerViewModel GetById(int id)
        {
            var entity = _CustomerRepository.GetById(id);
            return _dataMapper.Map<CustomerModel, AddEditCustomerViewModel>(entity);
        }

        public bool Insert(AddEditCustomerViewModel model)
        {
            var entity = _CustomerRepository.Create();
            _dataMapper.Map(model, entity);
            _CustomerRepository.Insert(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditCustomerViewModel model)
        {
            var entity = _CustomerRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _CustomerRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
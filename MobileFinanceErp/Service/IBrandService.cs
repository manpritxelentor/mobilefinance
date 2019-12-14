using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface IBrandService
    {
        List<BrandListViewModel> GetAll();
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        bool Insert(AddEditBrandViewModel model);
        AddEditBrandViewModel GetById(int id);
        bool Update(AddEditBrandViewModel model);
        bool Delete(int id);
    }

    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(int id)
        {
            var entity = _brandRepository.GetById(id);
            _brandRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<BrandModel, BrandListViewModel>
                (_brandRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public List<BrandListViewModel> GetAll()
        {
            return _dataMapper.Project<BrandModel, BrandListViewModel>
                (_brandRepository.GetAllNoTracking()).ToList();
        }

        public AddEditBrandViewModel GetById(int id)
        {
            var entity = _brandRepository.GetById(id);
            return _dataMapper.Map<BrandModel, AddEditBrandViewModel>(entity);
        }

        public bool Insert(AddEditBrandViewModel model)
        {
            var entity = _brandRepository.Create();
            _dataMapper.Map(model, entity);
            _brandRepository.Insert(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditBrandViewModel model)
        {
            var entity = _brandRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _brandRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
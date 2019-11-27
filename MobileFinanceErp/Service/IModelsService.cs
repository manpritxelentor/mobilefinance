using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFinanceErp.Service
{
    public interface IModelsService
    {
        DataSourceResult GetAll(DataSourceRequest dataSourceRequest);
        bool Insert(AddEditModelsViewModel model);
        AddEditModelsViewModel GetById(int id);
        bool Update(AddEditModelsViewModel model);
        bool Delete(int id);
    }

    public class ModelsService : IModelsService
    {
        private readonly IModelsRepository _modelsRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public ModelsService(IModelsRepository modelsRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _modelsRepository = modelsRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }
        public bool Delete(int id)
        {
            var entity = _modelsRepository.GetById(id);
            _modelsRepository.Remove(entity);
            return _unitOfWork.Commit() > 0;
        }

        public DataSourceResult GetAll(DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<ModelsModel, ModelsListViewModel>
                (_modelsRepository.GetAllNoTracking()).ToDataSourceResult(dataSourceRequest);
        }

        public AddEditModelsViewModel GetById(int id)
        {
            var entity = _modelsRepository.GetById(id);
            return _dataMapper.Map<ModelsModel, AddEditModelsViewModel>(entity);
        }

        public bool Insert(AddEditModelsViewModel model)
        {
            var entity = _modelsRepository.Create();
            _dataMapper.Map(model, entity);
            _modelsRepository.Insert(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditModelsViewModel model)
        {
            var entity = _modelsRepository.GetById(model.Id);
            _dataMapper.Map(model, entity);
            _modelsRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}

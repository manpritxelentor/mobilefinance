using MobileFinanceErp.Controllers;
using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface IGroupCodeService
    {
        List<GroupCodeSelectListModel> GetAll(string codeName);
        string GetCode(int id);
        DataSourceResult GetAll(string codeName, DataSourceRequest dataSourceRequest);
        bool Update(AddEditGroupCodeViewModel model);
        bool Insert(AddEditGroupCodeViewModel model);
    }

    public class GroupCodeService : IGroupCodeService
    {
        private readonly IGroupCodesRepository _groupCodeRepository;
        private readonly IDataMapper _dataMapper;
        private readonly IUnitOfWork _unitOfWork;

        public GroupCodeService(IGroupCodesRepository groupCodeRepository
            , IDataMapper dataMapper
            , IUnitOfWork unitOfWork)
        {
            _groupCodeRepository = groupCodeRepository;
            _dataMapper = dataMapper;
            _unitOfWork = unitOfWork;
        }

        public List<GroupCodeSelectListModel> GetAll(string codeName)
        {
            return _dataMapper.Project<GroupCodeModel, GroupCodeSelectListModel>
                (_groupCodeRepository.GetByGroup(codeName)).ToList();
        }

        public DataSourceResult GetAll(string codeName, DataSourceRequest dataSourceRequest)
        {
            return _dataMapper.Project<GroupCodeModel, GroupCodeSelectListModel>
                (_groupCodeRepository.GetByGroup(codeName))
                .ToDataSourceResult(dataSourceRequest);
        }

        public string GetCode(int id)
        {
            return _groupCodeRepository.GetAllNoTracking()
                .Where(w => w.Id == id)
                .Select(w => w.Code)
                .FirstOrDefault();
        }

        public bool Insert(AddEditGroupCodeViewModel model)
        {
            var entity = _groupCodeRepository.Create();
            entity.Code = model.DisplayName;
            entity.DisplayName = model.DisplayName;
            entity.Name = model.Name;
            _groupCodeRepository.Insert(entity);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(AddEditGroupCodeViewModel model)
        {
            var entity = _groupCodeRepository.GetById(model.Id);
            entity.Code = model.DisplayName;
            entity.DisplayName = model.DisplayName;
            _groupCodeRepository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }
    }
}
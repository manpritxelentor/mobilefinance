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
    }

    public class GroupCodeService : IGroupCodeService
    {
        private readonly IGroupCodesRepository _groupCodeRepository;
        private readonly IDataMapper _dataMapper;

        public GroupCodeService(IGroupCodesRepository groupCodeRepository
            , IDataMapper dataMapper)
        {
            _groupCodeRepository = groupCodeRepository;
            _dataMapper = dataMapper;
        }

        public List<GroupCodeSelectListModel> GetAll(string codeName)
        {
            return _dataMapper.Project<GroupCodeModel, GroupCodeSelectListModel>
                (_groupCodeRepository.GetByGroup(codeName)).ToList();
        }

        public string GetCode(int id)
        {
            return _groupCodeRepository.GetAllNoTracking()
                .Where(w => w.Id == id)
                .Select(w => w.Code)
                .FirstOrDefault();
        }
    }
}
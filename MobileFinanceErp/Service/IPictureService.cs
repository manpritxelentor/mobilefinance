using MobileFinanceErp.Models;
using MobileFinanceErp.Repository;
using MobileFinanceErp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Service
{
    public interface IPictureService
    {
        bool Insert(PictureViewModel pictureViewModel);
    }

    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataMapper _dataMapper;

        public PictureService(IPictureRepository pictureRepository
            , IUnitOfWork unitOfWork
            , IDataMapper dataMapper)
        {
            _pictureRepository = pictureRepository;
            _unitOfWork = unitOfWork;
            _dataMapper = dataMapper;
        }

        public bool Insert(PictureViewModel pictureViewModel)
        {
            var entity = _pictureRepository.Create();
            _dataMapper.Map(pictureViewModel, entity);
            entity.CreatedDate = DateTime.Now;
            return _unitOfWork.Commit() > 0;
        }
    }
}
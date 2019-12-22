using MobileFinanceErp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileFinanceErp.Repository
{
    public interface IPictureRepository : IBaseRepository<PictureModel>
    {
    }

    public class PictureRepository : BaseRepository<PictureModel>, IPictureRepository
    {
        public PictureRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
        }
    }
}
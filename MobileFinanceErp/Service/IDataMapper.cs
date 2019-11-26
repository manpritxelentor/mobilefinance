using AutoMapper;
using AutoMapper.QueryableExtensions;
using MobileFinanceErp.Models;
using MobileFinanceErp.ViewModel;
using System.Linq;

namespace MobileFinanceErp.Service
{
    public interface IDataMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        IQueryable<TDestination> Project<TSource, TDestination>(IQueryable<TSource> source);
    }

    public class DataMapper : IDataMapper
    {
        private readonly IMapper _mapper;
        public DataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

        public IQueryable<TDestination> Project<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>(_mapper.ConfigurationProvider);
        }
    }

    public class AutoMapperConfiguration
    {
        public static IMapper Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BrandModel, BrandListViewModel>();
                cfg.CreateMap<AddEditBrandViewModel, BrandModel>();
                cfg.CreateMap<BrandModel, AddEditBrandViewModel>();
            });
            return config.CreateMapper();
        }
    }
}
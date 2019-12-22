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

                cfg.CreateMap<ModelsModel, ModelsListViewModel>()
                .ForMember(src => src.BrandName, opt => opt.MapFrom(dest => dest.Brand.Name))
                ;
                cfg.CreateMap<AddEditModelsViewModel, ModelsModel>();
                cfg.CreateMap<ModelsModel, AddEditModelsViewModel>()
                ;

                cfg.CreateMap<AddEditModelsViewModel, BrandModel>()
                   .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.BrandName))
                ;

                cfg.CreateMap<CustomerModel, CustomerListViewModel>()
                    .ForMember(src => src.Address, opt => opt.MapFrom(dest => (dest.Address1 != null ? dest.Address1 : "") + (dest.Address2 != null ? " , " + dest.Address2 : "") + (dest.Address3 != null ? " ," + dest.Address3 : "")))
                ;
                cfg.CreateMap<AddEditCustomerViewModel, CustomerModel>();
                cfg.CreateMap<CustomerModel, AddEditCustomerViewModel>();

                cfg.CreateMap<FinanceModel, FinanceListViewModel>()
                    .ForMember(src => src.CustomerName, opt => opt.MapFrom(dest => dest.Customer.FirstName))
                    .ForMember(src => src.BookNoPageNumber, opt => opt.MapFrom(dest => dest.BookNo + " / " + dest.PageNo));
                cfg.CreateMap<AddEditFinanceViewModel, FinanceModel>();
                cfg.CreateMap<GuarantorModel, GuarantorListViewModel>();
                cfg.CreateMap<AddEditGuarantorViewModel, GuarantorModel>();
                cfg.CreateMap<GuarantorModel, AddEditGuarantorViewModel>();
                cfg.CreateMap<FinanceModel, AddEditFinanceViewModel>()
                    .ForMember(src => src.BrandId, opt => opt.MapFrom(dest => dest.Model.BrandId))
                    .ForMember(src => src.CustomerName, opt => opt.MapFrom(dest => dest.Customer.FirstName))
                    .ForMember(src => src.CustomerMobile, opt => opt.MapFrom(dest => dest.Customer.Mobile1))
                    .ForMember(src => src.CustomerAddress, opt => opt.MapFrom(dest => (dest.Customer.Address1 != null ? dest.Customer.Address1 : "") + (dest.Customer.Address2 != null ? " , " + dest.Customer.Address2 : "") + (dest.Customer.Address3 != null ? " ," + dest.Customer.Address3 : "")))
                ;

                cfg.CreateMap<GroupCodeModel, GroupCodeSelectListModel>()
                    .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.DisplayName));


                cfg.CreateMap<FinanceDetailsModel, ReceiveFinanceViewModel>()
                    .ForMember(dest => dest.Notes, opt => opt.Ignore())
                    .ForMember(dest => dest.RemainingAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.CarryForwardAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.EMIAmount, opt => opt.MapFrom(src=> src.ReceivedAmount));
            });
            return config.CreateMapper();
        }
    }
}
using AutoMapper;
using SystemEmail.DTO;
using SystemEmail.Model;

namespace SystemEmail.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserDTO>().
                ForMember(destination => destination.RolDescription,
                option => option.MapFrom(origin => origin.IdRolNavigation.Name)).
                ForMember(destination => destination.IsActive,
                option => option.MapFrom(origin => origin.IsActive == true ? 1 : 0));

            CreateMap<User, SessionDTO>().
                ForMember(destination => destination.RolDescription,
                option => option.MapFrom(origin => origin.IdRolNavigation.Name));

            CreateMap<UserDTO, User>().
             ForMember(destination => destination.IdRolNavigation, option => option.Ignore()).ForMember(destination => destination.IsActive,
                option => option.MapFrom(origin => origin.IsActive == 1 ? true : false));

            #endregion

            #region Client
            CreateMap<Client, ClientDTO>()
            .ForMember(destinationMember => destinationMember.CategoryDescription,
             option => option.MapFrom(origin => origin.IdCategoryNavigation.Name))
            .ForMember(destinationMember => destinationMember.IsActive,
               option => option.MapFrom(origin => origin.IsActive == true ? 1 : 0));



            CreateMap<ClientDTO, Client>()
            .ForMember(destinationMember => destinationMember.IdCategoryNavigation, option => option.Ignore())
            .ForMember(destination => destination.IsActive,
                option => option.MapFrom(origin => origin.IsActive == 1 ? true : false));
            

            #endregion

            #region Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion

            #region Email
            CreateMap<Email, EmailDTO>().ForMember(destinationMember => destinationMember.DateLog, 
                option => option.MapFrom(origin => origin.DateLog.Value.ToString("dd/MM/yyyy")));

            #endregion

            #region DetailEmail
            CreateMap<DetailEmail, DetailEmailDTO>().ForMember(destination => destination.EmailDescription,
                option => option.MapFrom(origin => origin.IdEmailNavigation.EmailType));

            #endregion


            #region Report

            CreateMap<DetailEmail, ReportDTO>().
                ForMember(destinationMember => destinationMember.DateLog,
                option => option.MapFrom(origin => origin.IdEmailNavigation.DateLog.Value.ToString("dd/MM/yyyy")))

                .ForMember(destinationMember => destinationMember.SpecialId,
                option => option.MapFrom(origin => origin.IdEmailNavigation.SpecialId))

                .ForMember(destinationMember => destinationMember.EmailService,
                option => option.MapFrom(origin => origin.IdEmailNavigation.EmailType));
                
            #endregion







        }




    }
}

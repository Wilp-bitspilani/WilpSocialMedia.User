using AutoMapper;
using WilpSocialMedia.Common;
using WilpSocialMedia.Common.Securities;
using WilpSocialMedia.User.Application.DTO;
using WilpSocialMedia.User.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilpSocialMedia.User
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountUser, AccountUserRespond>();
            CreateMap<AccountUserRequest, AccountUser>();

            CreateMap<AccountUserCreateRequest, AccountUser>()
                .ForMember(x => x.Id, o => o.MapFrom(s => Guid.NewGuid()))                  
                .ForMember(x => x.Password, o => o.MapFrom(s => Encryptor.Encrypt(s.Password, Global.Key.EncryptDecrypt)));  
            
            CreateMap<AccountUserUpdateRequest, AccountUser>();
        }
    }
}

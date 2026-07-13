using AutoMapper;
using Microsoft.Extensions.Logging;
using VidyaMitra.Domain.Dto;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application
{
    public class MappingConfig
    {
        private static ILoggerFactory loggerFactory = new LoggerFactory();

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonalInfoDto, StudentProfile>();
                config.CreateMap<StudentProfile, PersonalInfoDto>();

                config.CreateMap<ContactDetailDto, StudentContactDetail>().ReverseMap();
                config.CreateMap<EmergencyContactDto, StudentEmeregencyContact>().ReverseMap();
                config.CreateMap<ParentDetailDto, StudentParentDetail>().ReverseMap();
                config.CreateMap<NotificationDto, StudentNotification>().ReverseMap();

            }, loggerFactory);

            return mappingConfig;
        }
    }
}

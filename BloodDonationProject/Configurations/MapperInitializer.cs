using AutoMapper;
using BloodDonationProject.Data;
using BloodDonationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Hospital, CreateHospitalDTO>().ReverseMap();
            CreateMap<Donation, DonationDTO>().ReverseMap();
            CreateMap<Donation, CreateDonationDTO>().ReverseMap();
            CreateMap<ApiUser, AccountDTO>().ReverseMap();
        }
    }
}

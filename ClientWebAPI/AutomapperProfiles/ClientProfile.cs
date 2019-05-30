using AutoMapper;
using ClientWebAPI.Model.Dto;
using ClientWebAPI.Models.Dto;
using Entities.Models;

namespace ClientWebAPI.AutomapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDtoForCreation, Client>();
            CreateMap<ClientDtoForUpdate, Client>();
        }
    }
}

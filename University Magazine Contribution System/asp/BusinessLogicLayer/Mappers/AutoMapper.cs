using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
            CreateMap<Contribution, ContributionsDTO>() 
                .ReverseMap();
            CreateMap<Student, StudentDTO>() 
                .ReverseMap();
            CreateMap<Faculty, FacultyDTO>()
                .ReverseMap();
            CreateMap<Comment, CommentDTO>()
                .ReverseMap();
            CreateMap<SystemParameter, SystemParameterDTO>() 
                .ReverseMap();
            CreateMap<Comment, CommentDTO>()
                .ReverseMap();
        }
    }
}


using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlog.WebApi.Controllers;

namespace MyBlog.WebApi.Utility._AutoMapper
{
    public class CustomAutoMapperProfile:Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<WriterInfo, WriterDTO>();
        }
    }
}

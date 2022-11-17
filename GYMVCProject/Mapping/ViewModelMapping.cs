using AutoMapper;
using GYMVCProject.Models;
using GYMVCProject.ViewModels;

namespace GYMVCProject.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {

            CreateMap<Products, ProductViewModel>().ReverseMap();

        }
    }
}

using AutoMapper;
using Practical_18.Models;
using Practical_18.ViewModels;

namespace Practical_18.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
        }
        
    }
}

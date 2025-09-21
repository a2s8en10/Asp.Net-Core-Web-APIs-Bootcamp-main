using AutoMapper;
using OldBookStore.Data;
using OldBookStore.Model;

namespace OldBookStore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
 
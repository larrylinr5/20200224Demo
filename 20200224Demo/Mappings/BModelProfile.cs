using _20200224Demo.Models;
using AutoMapper;

namespace _20200224Demo.Mappings
{
    class BModelProfile : Profile
    {
        public BModelProfile()
        {
            this.CreateMap<AModel, BModel>();
            //以後多的都加在這邊
            //EX:
            //this.CreateMap<AModel2, BModel2>();
            //this.CreateMap<AModel3, BModel3>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using YachmanAPI.Models;
namespace YachmanAPI.App_Start
{
    public class AutoMapperBase
    {
        public IMapper _mapper;

        public AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Harbor, HarborDto>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
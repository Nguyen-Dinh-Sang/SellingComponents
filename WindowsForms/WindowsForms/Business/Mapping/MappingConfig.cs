using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapping
{
    public class MappingConfig
    {
        public IMapper config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            return config.CreateMapper();
        }
    }
}

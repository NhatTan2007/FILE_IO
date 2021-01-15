using AutoMapper;
using READ_AND_WRITE_FILE_CSV.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace READ_AND_WRITE_FILE_CSV.Services
{
    public static class MapperServices
    {
        public static desType MapperData<sourceType, desType>(sourceType sourceFile)
        {
            MapperConfiguration configAutoMapper = new MapperConfiguration(cfg => { cfg.CreateMap<Student, ReStudent>(); });
            IMapper iMapper = configAutoMapper.CreateMapper();
            return iMapper.Map<sourceType, desType>(sourceFile);
        }
    }
}

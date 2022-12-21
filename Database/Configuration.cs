using AutoMapper;
using Database.Data.Entities;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public sealed class Configuration
    {
        private static Configuration _instance;
        public MapperConfiguration MapperConfiguration { get; set; }

        private Configuration()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Budget, BudgetDto>();
            });
        }

        public static Configuration GetInstance()
        {
            if (_instance is null)
                _instance = new Configuration();

            return _instance;
        }
    }
}

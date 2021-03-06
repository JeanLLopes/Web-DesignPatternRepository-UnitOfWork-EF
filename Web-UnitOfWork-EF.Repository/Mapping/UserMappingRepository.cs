﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_UnitOfWork_EF.Model;
using Web_UnitOfWork_EF.Repository.Interface;

namespace Web_UnitOfWork_EF.Repository.Mapping
{
    public class UserMappingRepository : EntityTypeConfiguration<UserModel>, IMapping
    {
        public UserMappingRepository()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Id);
            Property(x => x.Nome).IsRequired().HasMaxLength(255);
            Property(x => x.Email).IsRequired().HasMaxLength(255);
            Property(x => x.DtNascimento).IsRequired();
            //HasMany(x => x.Recipes).WithOptional().HasForeignKey(x => x.UserId);
        }
    }

}

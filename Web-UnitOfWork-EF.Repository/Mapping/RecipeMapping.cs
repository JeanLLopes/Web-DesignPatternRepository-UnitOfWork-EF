using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_UnitOfWork_EF.Model;

namespace Web_UnitOfWork_EF.Repository.Mapping
{
    public class RecipeMapping: EntityTypeConfiguration<RecipeModel>,IMapping
    {
        public RecipeMapping()
        {
            ToTable("Recipe");
            HasKey(x => x.Id);
            Property(x => x.Id);
            Property(x => x.Ingredients).HasMaxLength(1024);
            Property(x => x.Steps).HasMaxLength(1024);
            Property(x => x.Title).IsRequired().HasMaxLength(150);
        }
    }
}

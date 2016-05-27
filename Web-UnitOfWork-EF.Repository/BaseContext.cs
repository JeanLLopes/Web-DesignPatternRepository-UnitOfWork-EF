using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_UnitOfWork_EF.Repository.Mapping;

namespace Web_UnitOfWork_EF.Repository
{
    public class BaseContext<T> : DbContext where T : class 
    {
        public DbSet<T> DbSet { get; set; }

        public BaseContext() : base("")
        {
            //Caso a base de dados não tenha sido criada
            Database.SetInitializer<BaseContext<T>>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new RecipeMapping());

            base.OnModelCreating(modelBuilder);
        }

        public virtual void ChangeObjectState(Object model, EntityState state)
        {
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter) this).ObjectContext.ObjectStateManager.ChangeObjectState(model, state);
        }
    }
}

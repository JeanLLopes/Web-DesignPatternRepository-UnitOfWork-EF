using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web_UnitOfWork_EF.Model;
using Web_UnitOfWork_EF.Repository.Mapping;

namespace Web_UnitOfWork_EF.Repository
{
    public class BaseContext<TEntity> : DbContext where TEntity : class
    {
        public BaseContext(): base("ConnectionUnitOfWork")
        {
            //Caso a base de dados não tenha sido criada
            Database.SetInitializer<BaseContext<TEntity>>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //O evento acima está implementado na classe BaseContext.cs que acabamos de criar, porém isso 
            //não é muito inteligente concorda ? Se nosso banco tiver 30 tabelas vamos fazer isso na mão ? Se fosse 50 tabelas ?
            //modelBuilder.Configurations.Add(new UserMappingRepository());
            //modelBuilder.Configurations.Add(new RecipeMappingRepository());

            //base.OnModelCreating(modelBuilder);







            //Para resolver essa situação que iremos criar o mapeamento 
            //dinâmico, a principal ideia é caso seja criado um novo 
            //mapeamento não será necessário alterar o evento 
            //OnModelCreating, ele será capaz de identificar um novo modelo e 
            //carregá-lo dinamicamente


            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos
            var typesToMapping = (from types in Assembly.GetExecutingAssembly().GetTypes()
                                  where types.IsClass && typeof(IMapping).IsAssignableFrom(types)
                                  select types).ToList();



            //// Com ajuda do Reflection criamos as instancias 
            //// e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }

        }

        public virtual void ChangeObjectState(Object model, EntityState state)
        {
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(model, state);
        }




        public DbSet<TEntity> DbSet { get; set; }

        public virtual int Add(TEntity model)
        {
            DbSet.Add(model);
            return SaveChanges();
        }

        public virtual int Update(TEntity model)
        {
            var data = Entry(model);
            if (data.State == EntityState.Detached)
            {
                DbSet.Attach(model);
            }

            ChangeObjectState(model, EntityState.Modified);
            return SaveChanges();
        }

        public virtual void Delete(TEntity model)
        {
            var data = Entry(model);
            if (data.State == EntityState.Detached)
            {
                DbSet.Attach(model);
            }

            ChangeObjectState(model, EntityState.Modified);
            SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(Int32 id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public virtual IEnumerable<TEntity> OrderBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.OrderBy(expression);
        }
    }
}

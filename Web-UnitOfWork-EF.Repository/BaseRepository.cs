using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_UnitOfWork_EF.Model;

namespace Web_UnitOfWork_EF.Repository
{
    public class BaseRepository
    {
        public class UserRepository : BaseContext<UserModel>, IUnitOfWork<UserModel>
        {
            public DbSet<UserModel> DbSet { get; set; }

            public virtual int Add(UserModel model)
            {
                DbSet.Add(model);
                return SaveChanges();
            }

            public virtual int Update(UserModel model)
            {
                var data = Entry(model);
                if (data.State == EntityState.Detached)
                {
                    DbSet.Attach(model);
                }

                ChangeObjectState(model, EntityState.Modified);
                return SaveChanges();
            }

            public virtual void Delete(UserModel model)
            {
                var data = Entry(model);
                if (data.State == EntityState.Detached)
                {
                    DbSet.Attach(model);
                }

                ChangeObjectState(model, EntityState.Modified);
                SaveChanges();
            }

            public virtual IEnumerable<UserModel> GetAll()
            {
                return DbSet.ToList();
            }

            public virtual UserModel GetById(object id)
            {
                return DbSet.Find(id);
            }

            public virtual IEnumerable<UserModel> Where(System.Linq.Expressions.Expression<Func<UserModel, bool>> expression)
            {
                return DbSet.Where(expression);
            }

            public virtual IEnumerable<UserModel> OrderBy(System.Linq.Expressions.Expression<Func<UserModel, bool>> expression)
            {
                return DbSet.OrderBy(expression);
            }

        }

        //public class RecipeRepository : BaseContext<RecipeModel>, IUnitOfWork<RecipeModel>
        //{

        //}
    }
}

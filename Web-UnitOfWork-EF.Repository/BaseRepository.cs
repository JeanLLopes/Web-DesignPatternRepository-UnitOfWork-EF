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
        public class UserRepository : BaseContext<UserModel>
        {

        }

        public class RecipeRepository : BaseContext<RecipeModel>
        {

        }
    }
}

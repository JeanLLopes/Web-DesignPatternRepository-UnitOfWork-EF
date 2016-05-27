using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web_UnitOfWork_EF.Model
{
    public class UserModel
    {
            public Int32 Id { get; set; }
            public String Nome { get; set; }
            public String Email { get; set; }
            public DateTime DtNascimento { get; set; }
            //public virtual IList<RecipeModel> Recipes { get; set; }
    }
}

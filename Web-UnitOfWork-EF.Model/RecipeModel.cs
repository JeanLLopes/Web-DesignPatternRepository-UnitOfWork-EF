using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web_UnitOfWork_EF.Model
{
    public class RecipeModel
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Ingredients { get; set; }
        public String Steps { get; set; }
        public Guid UserId { get; set; }
    }
}

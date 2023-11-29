using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface ICategoryRepo:IGenericRepo<Category>
{
   new List<Category> GetAll();
   new Category? GetById(int id);
}

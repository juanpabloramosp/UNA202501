using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CategoryDALImpl : GenericDALImpl<Category>, ICategoryDAL
    {
        NorthWindContext _context;

        public CategoryDALImpl(NorthWindContext context): base(context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var query = "sp_GetAllCategories";

            var result = _context.Categories
                            .FromSqlRaw(query);

            return result.ToList();



        }


        public  new  bool Add(Category category)
        {
            try
            {
                string query = "EXEC [dbo].[sp_AddCategory]@CategoryName";

                var parameters = new SqlParameter[]
                {
                new SqlParameter()
                {
                    ParameterName = "@CategoryName",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = category.CategoryName
                }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(query, parameters);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }

    }
}

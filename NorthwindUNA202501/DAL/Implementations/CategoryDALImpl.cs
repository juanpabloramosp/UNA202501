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


        public Category AddCategory(Category category)
        {
            try
            {
                string query = "EXEC [dbo].[sp_AddCategory]@CategoryName, @CategoryId out";

                var parameters = new SqlParameter[]
                {
                new SqlParameter()
                {
                    ParameterName = "@CategoryName",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = category.CategoryName
                },
                     new SqlParameter()
                    {
                        ParameterName = "@CategoryId",
                        SqlDbType= System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    }
                };
                
                _context
                    .Database
                    .ExecuteSqlRaw(query, parameters);

                category.CategoryId = Convert.ToInt32(parameters[1].Value);

                return category;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}

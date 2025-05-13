using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using AssessmentApp.Models;

namespace AssessmentApp.Repository
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public List<CustomerProduct> GetAll()
        {
            using var db = Connection;
            return db.Query<CustomerProduct>("SELECT * FROM CustomerProducts").ToList();
        }

        public void Insert(CustomerProduct cp)
        {
            using var db = Connection;
            string query = @"INSERT INTO CustomerProducts (CustomerName, ProductName, Rate, Quantity, MobileNo) 
                             VALUES (@CustomerName, @ProductName, @Rate, @Quantity, @MobileNo)";
            db.Execute(query, cp);
        }

        public void Update(CustomerProduct cp)
        {
            using var db = Connection;
            string query = @"UPDATE CustomerProducts 
                             SET CustomerName = @CustomerName, ProductName = @ProductName, 
                                 Rate = @Rate, Quantity = @Quantity, MobileNo = @MobileNo 
                             WHERE Id = @Id";
            db.Execute(query, cp);
        }

        public void Delete(int id)
        {
            using var db = Connection;
            db.Execute("DELETE FROM CustomerProducts WHERE Id = @Id", new { Id = id });
        }
    }
}

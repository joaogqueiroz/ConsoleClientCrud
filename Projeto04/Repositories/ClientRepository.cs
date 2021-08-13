using Dapper;
using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {

        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projeto04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
        
        public override void Alter(Client obj)
        {
            var query = @"
            UPDATE CLIENT 
            SET
                NAME = @Name,
                EMAIL = @Email,
                BIRTHDATE = @BirthDate,
                DOC = @Doc 
            WHERE
                IDCLIENT = @IdClient
            ";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj); //executing sql update command
            }
        }

        public override void Delete(Client obj)
        {
            var query = @"
            DELETE FROM CLIENT
            WHERE
                IDCLIENT = @IdClient
            ";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj); //executing sql delete command
            }
        }

        public override void Insert(Client obj)
        {
            var query = @"
                INSERT INTO CLIENT(
                    IDCLIENT, 
                    NAME, 
                    EMAIL, 
                    DOC, 
                    BIRTHDATE)
                VALUES(
                    NEWID(), 
                    @Name,
                    @Email,
                    @Doc,
                    @BirthDate
                    )
                   ";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, obj); //executing sql insert command
            }
        }
        public override List<Client> Consult()
        {
            var query = @"
            SELECT * FROM CLIENT
            ORDER BY NAME
            ";
            using (var connection = new SqlConnection(_connectionString))
            {
               return connection.Query<Client>(query).ToList(); //executing sql insert command
            }
        }

        public override Client ConsultByID(Guid id)
        {
            var query = @"
            SELECT * FROM CLIENT
            WHERE IDCLIENT = @id
            ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Client>(query, new {id}).FirstOrDefault(); //executing sql insert command
            }
        }

        public List<Client> ConsultByBirthDate(DateTime minDate, DateTime maxDate) 
        {
            var query = @"
            SELECT * FROM CLIENT
            WHERE BIRTHDATE BETWEEN @MinDate AND @MaxDate  
            ";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Client>(query, new { minDate, maxDate }).ToList(); //executing sql insert command
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Whatsapp.BLL.Interface;
using WhatsAppDAL;
using WhatsAppDAL.Model;

namespace Whatsapp.BLL.Implementation
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly WhatsAppDbContext _dbContext;
        private bool _disposed;

        public WhatsAppService() { }
        public WhatsAppService(WhatsAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateUser(UserViewModel user)
        {

            SqlConnection sqlConn = await _dbContext.OpenConnection();


            string insertQuery =
                $"INSERT INTO USERS (UserID, FirstName, LastName, UserName, PhoneNumber, Country, ProfileImage)" +
                $" VALUES (@UserID, @FirstName, @LastName, @UserName, @Phone, @Image); SELECT CAST(SCOPE_IDENTITY() AS BIGINT)";


            await using SqlCommand command = new SqlCommand(insertQuery, sqlConn);

            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = user.UserID,
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = user.LastName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = user.Country,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@ProfilePicture",
                    Value = user.ProfilePicture,
                    SqlDbType = SqlDbType.VarBinary,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            long userId = (long)await command.ExecuteScalarAsync();
            Console.WriteLine(userId > 0 ? $"User Created Successfully" : $"User not created");

        }

        public async Task<long> UpdateUser(int userId, UserViewModel user)
        {

            SqlConnection sqlConn = await _dbContext.OpenConnection();



            string insertQuery =
                $"UPDATE Users SET FirstName = @FirstName, LastName = @LastName, UserName = UserName, Country = @Country, PhoneNumber = @Phone WHERE UserID = @UserID";

            await using SqlCommand command = new SqlCommand(insertQuery, sqlConn);

            command.Parameters.AddRange(new SqlParameter[]
             {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = user.UserID,
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = user.LastName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = user.FirstName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@UserName",
                    Value = user.UserName,
                    SqlDbType = SqlDbType.VarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },
                new SqlParameter
                {
                    ParameterName = "@Country",
                    Value = user.Country,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                },

                new SqlParameter
                {
                    ParameterName = "@ProfilePicture",
                    Value = user.ProfilePicture,
                    SqlDbType = SqlDbType.VarBinary,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }

             });

            var result = command.ExecuteNonQuery();
            return result;
        }

        public async Task DeleteUser(int UserId)
        {
            SqlConnection sqlConn = await _dbContext.OpenConnection();

            string deleteQuery = $"DELETE FROM Users WHERE UserId = @UserId ";
            await using SqlCommand command = new SqlCommand(deleteQuery, sqlConn);

            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = UserId,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });

            var result = command.ExecuteNonQuery();
            Console.WriteLine(result > 0 ? $"Successfully Deleted" : $"Not Successfully Deleted");
        }

        public async Task<UserViewModel> GetUser(int id)
        {
            SqlConnection sqlConn = await _dbContext.OpenConnection();
            string getUserQuery = $"SELECT Users.FirstName, Users.LastName, Users.UserName, Users.PhoneNumber, Users.ProfilePicure, Users.Country FROM Users WHERE UserId = @UserId ";
            await using SqlCommand command = new SqlCommand(getUserQuery, sqlConn);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@UserId",
                    Value = id,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Size = 50
                }
            });
            UserViewModel user = new UserViewModel();
            using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    user.FirstName = dataReader["FirstName"].ToString();
                    user.LastName = dataReader["LastName"].ToString();
                    user.UserName = dataReader["UserName"].ToString();
                    user.Country = dataReader["Country"].ToString();
                    user.PhoneNumber = dataReader["PhoneNumber"].ToString();
                    user.ProfilePicture = dataReader["ProfileImage"].ToString();
                }
            }

            return user;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {

            SqlConnection sqlConn = await _dbContext.OpenConnection();
            string getAllUsersQuery = $"SELECT Users.FirstName, Users.LastName, Users.UserName, Users.PhoneNumber, Users.ProfilePicure, Users.Country FROM Users WHERE UserId = @UserId ";
            await using SqlCommand command = new SqlCommand(getAllUsersQuery, sqlConn);
            List<UserViewModel> users = new List<UserViewModel>();
            using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
            {
                while (dataReader.Read())
                {
                    users.Add(
                        new UserViewModel()
                        {
                            FirstName = dataReader["FirstName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            UserName = dataReader["UserName"].ToString(),
                            Country = dataReader["Country"].ToString(),
                            PhoneNumber = dataReader["PhoneNumber"].ToString(),
                            ProfilePicture = dataReader["ProfileImage"].ToString()
                        }
                        );
                }

            }

            return users;
        }




        protected virtual void Dispose(bool disposing)
        {

            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
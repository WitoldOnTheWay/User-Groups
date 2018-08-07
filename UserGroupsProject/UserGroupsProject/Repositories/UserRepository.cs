using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserGroupsProject.Models;
using System.Data.SqlClient;

namespace UserGroupsProject.Repositories
{
    public class UserRepository
    {
        public List<User> GetAll()
        {
            List<User> user = new List<User>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From [User]";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    user.Add(new User()
                    {
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        CreationDate = DateTime.Parse(reader["CreationDate"].ToString()),
                        Id = int.Parse(reader["Id"].ToString())
                    });
                }
                return user;
            }




        }
        public User Details(int Id)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select Name,Email,CreationDate,Id FROM [User] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                user.Name = reader["Name"].ToString();
                user.Email = reader["Email"].ToString();
                user.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
                user.Id = int.Parse(reader["Id"].ToString());
                return user;
            }

        }
        public User Edit(User user, int Id)
        {
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                String query = "UPDATE [User] SET Name=@Name,Email=@Email,CreationDate=@CreationDate WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@CreationDate", user.CreationDate);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return user;
            }
        }
        public void Create(User user)
        {
            using (SqlConnection conn = new SqlConnection("Server = DESKTOP-FH5G1I2\\SQLEXPRESS; Database=Users&Groups; Trusted_Connection = True; "))
            {
                conn.Open();
                string query = "Insert Into [User](Name,Email,CreationDate) values(@Name, @Email,@CreationDate)";
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@CreationDate", user.CreationDate);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void Delete(User user, int Id)
        {
            User userToDelete = new User();
            using (SqlConnection conn = new SqlConnection("Server = DESKTOP-FH5G1I2\\SQLEXPRESS; Database=Users&Groups; Trusted_Connection = True; "))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete From [User] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
            }
        }
        public List<Group> GetGroupNames(Group group,int Id)
        {
            List<Group> groupToReturn = new List<Group>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from [Group] g inner join UserGroupRelation UGR on g.Id=UGR.Group_ID where User_ID=@Id;";
                //cmd.CommandText = @"Select * from[Group] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Group temp = new Group();
                    groupToReturn.Add(temp);
                    temp.Name = reader["Name"].ToString();
                    temp.Id = int.Parse(reader["Id"].ToString());
                };
            }
            return groupToReturn;
        }

    }
}
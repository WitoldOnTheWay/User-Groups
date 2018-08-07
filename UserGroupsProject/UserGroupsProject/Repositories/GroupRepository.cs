using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserGroupsProject.Models;
using System.Data.SqlClient;


namespace UserGroupsProject.Repositories
{
    public class GroupRepository
    {
        public List<Group> GetAll()
        {
            List<Group> group = new List<Group>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select* From [Group]";
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    group.Add(new Group()
                    {
                        Name = reader["Name"].ToString(),
                        Id = int.Parse(reader["Id"].ToString()),
                    });
                }
                return group;
            }

        }
        public Group Details(int Id)
        {
            Group group = new Group();
            using(SqlConnection conn=new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select Name,Id FROM [Group] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                group.Name = reader["Name"].ToString();
                group.Id = int.Parse(reader["Id"].ToString());
                return group;
            }
        }
        public void Delete(Group group,int Id)
        {
            Group groupToDelete = new Group();
            using (SqlConnection conn = new SqlConnection("Server = DESKTOP-FH5G1I2\\SQLEXPRESS; Database=Users&Groups; Trusted_Connection = True; "))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Delete From [Group] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                conn.Close();
            }
        }
        public Group Edit(Group group, int Id)
        {
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                String query = "UPDATE [Group] SET Name=@Name WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", group.Id);
                    cmd.Parameters.AddWithValue("@Name", group.Name);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return group;
            }
        }
        public void Create(Group group)
        {
            using (SqlConnection conn = new SqlConnection("Server = DESKTOP-FH5G1I2\\SQLEXPRESS; Database=Users&Groups; Trusted_Connection = True; "))
            {
                conn.Open();
                string query = "Insert Into [Group](Name) values(@Name)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Name", group.Name);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public List<User> GetUserNames(User user,int Id)
        {
            List<User> userNamesToReturn = new List<User>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-FH5G1I2\\SQLEXPRESS;Database=Users&Groups;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"Select * from [User] u inner join UserGroupRelation UGR on u.Id=UGR.User_ID where Group_ID=@Id;";
                //cmd.CommandText = @"Select * from[Group] where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User temp = new User();
                    userNamesToReturn.Add(temp);
                    {
                        temp.Name = reader["Name"].ToString();
                        temp.Id = int.Parse(reader["Id"].ToString());
                    }
                };
            }
            return userNamesToReturn;
        }

    }

}
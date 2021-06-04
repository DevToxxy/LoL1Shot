using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;

namespace LoL1Shot.Data_Access_Layer
{
    public class ComboSqlDB : IComboDB
    {
        IConfiguration configuration;

        public ComboSqlDB(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Combo> List
        {
            get
            {
                List<Combo> ComboList = new List<Combo>();

                SqlConnection con = new SqlConnection(configuration.GetConnectionString("OneShotDB")); ;
                SqlCommand cmd = new SqlCommand("sp_ComboList", con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComboList.Add(new Combo());
                }

                reader.Close();
                con.Close();

                return ComboList;
            }
        }

        public void Add(Combo _Combo)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = _Combo.name;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = _Combo.price;
            cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = 5;

            SqlParameter ComboID_SqlParam = new SqlParameter("@ComboID", SqlDbType.Int);
            ComboID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(ComboID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int _id)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ComboID", SqlDbType.Int).Value = _id;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Combo Get(int _id)
        {
            Combo Combo = null;

            SqlConnection con = new SqlConnection(configuration.GetConnectionString("OneShotDB"));
            SqlCommand cmd = new SqlCommand("sp_ComboGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComboID", SqlDbType.Int).Value = _id;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Combo = new Combo();
            }

            reader.Close();
            con.Close();

            return Combo;
        }

        public void Update(Combo _Combo)
        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboEdit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ComboID", SqlDbType.Int).Value = _Combo.id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = _Combo.name;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = _Combo.price;
            cmd.Parameters.Add("@categoryID", SqlDbType.Int).Value = 5;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

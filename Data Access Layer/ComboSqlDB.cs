﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LoL1Shot.Models;
using Newtonsoft.Json;

namespace LoL1Shot.Data_Access_Layer
{
    public class ComboSqlDB : IComboDB
    {
        private IConfiguration _configuration;

        public ComboSqlDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Combo> List
        {
            get
            {
                //throw new NotImplementedException();

                List<Combo> ComboList = new List<Combo>();

                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB")); ;
                SqlCommand cmd = new SqlCommand("sp_ComboList", con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   ComboList.Add(new Combo(int.Parse(reader["Id"].ToString()),reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }

                reader.Close();
                con.Close();

                return ComboList;
            }
        }

        public void Add(Combo _Combo)
        {
            //throw new NotImplementedException();

            //JsonConvert.SerializeObject(_Combo); //<<<<<<<<<<<<<<<<NALEŻY DODAĆ POLE W TABELI NA JSON

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboAdd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.NChar).Value = _Combo.name;
            cmd.Parameters.Add("@actionList", SqlDbType.NChar).Value = _Combo.actionsString;
            cmd.Parameters.Add("@championKey", SqlDbType.NVarChar).Value = _Combo.championKey;

            SqlParameter ComboID_SqlParam = new SqlParameter("@comboID", SqlDbType.Int);
            ComboID_SqlParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(ComboID_SqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int _id)
        {
            //throw new NotImplementedException();

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@comboID", SqlDbType.Int).Value = _id;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Combo Get(int _id)
        {
            Combo Combo = null;

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));
            SqlCommand cmd = new SqlCommand("sp_ComboGet", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ComboID", SqlDbType.Int).Value = _id;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Combo = new Combo(int.Parse(reader["Id"].ToString()), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }

            reader.Close();
            con.Close();

            return Combo;
        }

        public void Update(Combo _Combo)
        {
            //throw new NotImplementedException();

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("OneShotDB"));

            SqlCommand cmd = new SqlCommand("sp_ComboUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@name", SqlDbType.Int).Value = _Combo.name;


            cmd.Parameters.Add("@actionList", SqlDbType.Int).Value = _Combo.actionsString;


            cmd.Parameters.Add("@championKey", SqlDbType.Int).Value = _Combo.championKey;

            cmd.Parameters.Add("@comboID", SqlDbType.Int).Value = _Combo.id;



            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

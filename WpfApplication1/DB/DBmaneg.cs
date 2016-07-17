using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace WpfApplication1.DB
{
    class DBmaneg
    {
        public void repository()
        {
            //データベースに接続するための処理（情報）
            var connString = @"Server=localhost;Port=5431;User Id=postgres;Password#;Database=student";
            //DataReaderを利用したＳＥＬＥＣＴ
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var command = new NpgsqlCommand(@"select * from table_name", conn);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine("value : {0},", dataReader["column_name"]);
                }
            }
            //DataAdapterを利用したSELECT
                using (var conn =new NpgsqlConnection(connString))
                {
                    conn.Open();

                var dataAdapter = new NpgsqlDataAdapter(@"SELECT * table_name",conn);

                var dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                Console.WriteLine(dataSet.Tables[0].Rows[0]["column_name"]);

                }
            }
        }

         

    }


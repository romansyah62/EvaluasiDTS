using System;
using EvaluasiDTS.Models;



namespace EvaluasiDTS
{
    public class PilihanKaryawan
    {
        SqlConnection sqlConnection;
        string connectionString = "Data Source=TEDDY;Initial Catalog=DataKaryawan;User ID=mccdts1;Password=mccdts1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        static string[] arrString = new string[6] { "Id", "Nama", "Email", "JenisKelamin", "NomorTelepon", "Agama", "Alamat" };

        public void ProsesInput()
        {
            string[] arrayKaryawan = new string[6];
            for (int i = 0; i < arrString.Length; i++)
            {

                Console.Write(arrString[i] + " :  ");
                string isi = Console.ReadLine();
                arrayKaryawan[i] = isi;
            }
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            pilihanKaryawan.ProsesInputData(arrayKaryawan);

        }

        public void ProsesInputData(string[] arrayKaryawan)
        {
            PilihanKaryawan pilihanKaryawan = new PilihanKaryawan();
            DataKaryawan karyawan = new DataKaryawan();
            {
                Id = int.Parse(arrayKaryawan[0]),
                Nama = arrayKaryawan[1],
                Email = arrayKaryawan[2],
                jenisKelamin = arrayKaryawan[3],
                NomorTelepon = arrayKaryawan[4],
                Agama = arrayKaryawan[5],
                Alamat = arrayKaryawan[6]
            };
            pilihanKaryawan.Insert(pilihanKaryawan);
        }

    }

    void GetAll()
    {
        sqlConnection = new SqlConnection(connectionString);
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = "select * from DataKaryawan ";


        try
        {
            sqlConnection.Open();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1] + " - " + sqlDataReader[2] + " - " + sqlDataReader[3] + " - " + sqlDataReader[4] + " - " + sqlDataReader[5] + " - " + sqlDataReader[6]);
                    }
                }
                else
                {
                    Console.WriteLine("No Data Found");
                }
                sqlDataReader.Close();
            }

            sqlConnection.Close();
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.InnerException);
        }
    }
    void Insert(DataKaryawan karyawan)
        {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Transaction = sqlTransaction;

                    try
                    {
                        sqlCommand.CommandText =
                            "insert into DataKaryawan " +
                            "(Id, Nama, Email, JenisKelamin, NomorTelepon, Agama, Alamat) " +
                            "VALUES (@datakaryawanId, @datakaryawanNama, @datakaryawanEmail, @datakaryawanJenisKelamin, @datakaryawanNomorTelepon, @datakaryawanAgama, @datakaryawanAlamat)";

                        SqlParameter sqlParameter1 = new SqlParameter();
                        sqlParameter1.ParameterName = "@datakaryawanId";
                        sqlParameter1.Value = karyawan.Id;

                        SqlParameter sqlParameter2 = new SqlParameter();
                        sqlParameter2.ParameterName = "@datakaryawanNama";
                        sqlParameter2.Value = karyawan.Nama;

                        SqlParameter sqlParameter3 = new SqlParameter();
                        sqlParameter3.ParameterName = "@datakaryawanEmail";
                        sqlParameter3.Value = karyawan.Email;

                        SqlParameter sqlParameter4 = new SqlParameter();
                        sqlParameter4.ParameterName = "@datakaryawanJenisKelamin";
                        sqlParameter4.Value = karyawan.JenisKelamin;

                        SqlParameter sqlParameter5 = new SqlParameter();
                        sqlParameter5.ParameterName = "@datakaryawanNomorTelepon";
                        sqlParameter5.Value = karyawan.NomorTelepon;

                        SqlParameter sqlParameter6 = new SqlParameter();
                        sqlParameter6.ParameterName = "@datakaryawanAgama";
                        sqlParameter6.Value = karyawan.Agama;

                        SqlParameter sqlParameter7 = new SqlParameter();
                        sqlParameter7.ParameterName = "@datakaryawanAlamat";
                        sqlParameter7.Value = karyawan.Alamat;

                        sqlCommand.Parameters.Add(sqlParameter1);
                        sqlCommand.Parameters.Add(sqlParameter2);
                        sqlCommand.Parameters.Add(sqlParameter3);
                        sqlCommand.Parameters.Add(sqlParameter4);
                        sqlCommand.Parameters.Add(sqlParameter5);
                        sqlCommand.Parameters.Add(sqlParameter6);
                        sqlCommand.Parameters.Add(sqlParameter7);

                        sqlCommand.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                        try
                        {
                            sqlTransaction.Rollback();

                        }
                        catch (Exception exRollBack)
                        {
                            Console.WriteLine(exRollBack.Message);
                        }
                    }
                }
        }
        

    }

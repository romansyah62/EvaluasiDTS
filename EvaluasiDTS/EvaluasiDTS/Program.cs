using EvaluasiDTS.Models;
using System;
using System.Data.SqlClient;

namespace EvaluasiDTS
{
    public class Program
    {
        private static string pilihan;
        SqlConnection sqlConnection;
        string connectionString = "Data Source=TEDDY;Initial Catalog=TUGAS_DATA_KANTOR;User ID=mccdts1;Password=mccdts1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        

        static void Main(string[] args)
        {
            Console.WriteLine("===========Menu Perusahaan========");
            Console.WriteLine("1. Registrasi");
            Console.WriteLine("2. Data Karyawan");
            Console.WriteLine("3. Absensi");
            Console.WriteLine("Masukkan Pilihan (1/2/3) :");
            do
            {
                int pilih = int.Parse(Console.ReadLine());
                switch (pilih)
                {
                    case 1:
                        Registration registration = new Registration();
                        Karyawan.DisplayInput();;
                        break;
                    case 2:
                        Employee Karyawan = new Employee();
                        Karyawan.DisplayInput();
                        break;
                    case 3:
                        Present Absensi = new Present();
                        Absensi.DisplayInput();
                        break;
                    default: 
                        MenuUtama ItemMenu = new MenuUtama();
                        ItemMenu.Menu();

                        break;
                }
                Console.WriteLine("Apa Anda Ingin Melanjutkan? y/t");
                
                string pilihan = Console.ReadLine();
            } while (pilihan == "y");
        }


    class MenuUtama
    {
            public void Menu()
            {
                Console.WriteLine("Silahkan Masukkan Input Benar");
                Console.WriteLine("1. Registrasi");
                Console.WriteLine("2. Data Karyawan");
                Console.WriteLine("3. Absensi");
                Console.ReadLine();
                Console.WriteLine("Masukkan Pilihan (1/2/3) :");
            }


    }
    
    public class Registration
    {
         
       public void DisplayInput()
       {
          Console.WriteLine("1. Lihat Data");
          Console.WriteLine("2. Registrasi");
          Console.WriteLine("3. Login");
          Console.WriteLine("Masukkan Pilihan (1/2/3) :");
       }
    }
    
    public class Employee
    {
            public void DisplayInput()
            {
                Console.WriteLine("1. Lihat Data");
                Console.WriteLine("2. Input Baru");
                Console.WriteLine("3. Update Data");
                Console.WriteLine("Masukkan Pilihan (1/2/3) :");
            }
    }


    public class Present
    {
         
            public void DisplayInput()
            {
                Console.WriteLine("1. Lihat Data Absen");
                Console.WriteLine("Masukkan Pilihan (1/2/3) :");
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

        void Update(DataKaryawan karyawan)
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
                        "update DataKaryawan " +
                        "set Alamat = @datakaryawanAlamat " +
                        "where Id = @datakaryawanId";

                    SqlParameter sqlParameter1 = new SqlParameter();
                    sqlParameter1.ParameterName = "@datakaryawanId";
                    sqlParameter1.Value = karyawan.Id;

                    SqlParameter sqlParameter7 = new SqlParameter();
                    sqlParameter7.ParameterName = "@datakaryawanAlamat";
                    sqlParameter7.Value = karyawan.Alamat;

                    sqlCommand.Parameters.Add(sqlParameter1);
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
}

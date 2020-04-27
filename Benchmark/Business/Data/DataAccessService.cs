using Benchmark.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Benchmark.Business.Data
{
    public class DataAccessService : IDataAccess
    {
        public Verse getText(Verse v)
        {
            Verse returnedVerse = new Verse();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=benchmark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = "SELECT * FROM dbo.Bible WHERE TESTAMENT = '" + v.Testament + "' AND BOOK = '" + v.Book + "' AND CHAPTER = " + v.Chapter + " AND VERSE = " + v.VerseNumber;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            returnedVerse.Testament = sqlDataReader.GetString(1);
                            returnedVerse.Book = sqlDataReader.GetString(2);
                            returnedVerse.Chapter = sqlDataReader.GetInt32(3);
                            returnedVerse.VerseNumber = sqlDataReader.GetInt32(4);
                            returnedVerse.VerseText = sqlDataReader.GetString(5);

                        }
                        sqlDataReader.Close();
                        sqlConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failue!");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return returnedVerse;
        }

        public bool insertVerse(Verse v)
        {
            bool success = false;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=benchmark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = "INSERT INTO dbo.bible (TESTAMENT, BOOK, CHAPTER, VERSE, TEXT) VALUES (@testament, @book, @chapter, @verse, @text)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@testament", SqlDbType.VarChar).Value = v.Testament;
                    sqlCommand.Parameters.Add("@book", SqlDbType.VarChar).Value = v.Book;
                    sqlCommand.Parameters.Add("@chapter", SqlDbType.Int).Value = v.Chapter;
                    sqlCommand.Parameters.Add("@verse", SqlDbType.Int).Value = v.VerseNumber;
                    sqlCommand.Parameters.Add("@text", SqlDbType.VarChar).Value = v.VerseText;

                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failue!");
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            return success;
        }
    }
}
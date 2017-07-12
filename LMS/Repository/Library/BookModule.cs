using DomainLayer;
using DomainLayer.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Configuration.Assemblies;

namespace Repository.Library
{
    
    internal class BookModule : IBookModule
    {
        static string dbstring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        public string AddBook(BookModel bookObj)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddNewBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", bookObj.Name);
                    cmd.Parameters.AddWithValue("@author", bookObj.AuthorName);
                    cmd.Parameters.AddWithValue("@department", bookObj.Department);
                    cmd.Parameters.AddWithValue("@remarks", bookObj.Remarks);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return StringLiterals.SuccesMsg;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            
           /* try
            {
                bookObj.BookID=StaticDatabase._booksList.Count+1;
                StaticDatabase._booksList.Add(bookObj);

                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;

            }*/
        }

        public DataTable GetAllBooks(int _selector)
        {
            SqlCommand cmd=new SqlCommand();
            SqlDataAdapter adapter=new SqlDataAdapter();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("GetBookList", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@selector", _selector);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(table);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            return table;
        }

        public string IssueBook(BookHistoryModel obj)
        {
 
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                SqlCommand cmd = new SqlCommand("CheckBookAvailability", connection);
                cmd.Parameters.AddWithValue("@bookID", obj.BookID);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    int choice = (int)cmd.ExecuteScalar();
                    if (choice == 1)
                    {
                        cmd = new SqlCommand("IssueBook", connection);
                        cmd.Parameters.AddWithValue("@bookID", obj.BookID);
                        cmd.Parameters.AddWithValue("@userID", obj.UserID);
                        cmd.Parameters.AddWithValue("@operationPerformedAt", obj.OperationPerformedAt);
                        cmd.Parameters.AddWithValue("@remarks", obj.Remarks);
                        cmd.Parameters.AddWithValue("@performedbyID", obj.PerformedByID);
                        cmd.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            cmd.ExecuteNonQuery();
                            return StringLiterals.SuccesMsg;
                        }
                        catch
                        {
                            throw;
                        }

                    }
                    else
                        return StringLiterals.BookNotAvailable;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            /*try
            {
                if (StaticDatabase._bookHistoryList.Any(m => m.BookID == obj.BookID && m.ReturnedAt == null))
                {
                    return StringLiterals.BookIsAssignedToUser;
                }
                else
                {
                    obj.PerformedByID=1;
                    obj.Issued="Issued";
                    obj.Returned="NA";
                    StaticDatabase._bookHistoryList.Add(obj);
                    BookModel _issueupdate=StaticDatabase._booksList.Where(m=>m.BookID==obj.BookID).FirstOrDefault();
                    if(_issueupdate.IsAvailable==true) _issueupdate.IsAvailable=false;

                    return StringLiterals.SuccesMsg;
                 }
            }
            catch
            {
                throw;

            }*/
        }

        public string RemoveBook(int bookID)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RemoveBook", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookID", bookID);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return StringLiterals.RemoveMsg;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
           /* try
            {
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookID).FirstOrDefault();
                bookObj.IsActive = false;
                return StringLiterals.RemoveMsg;
            }
            catch
            {
                throw;

            }*/

            // add entry into history table
        }

        public string ReturnBook(int retID)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                SqlCommand cmd = new SqlCommand("ReturnBook", connection);
                cmd.Parameters.AddWithValue("@bookID", retID);
                cmd.Parameters.AddWithValue("@returnTime", DateTime.Now);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return StringLiterals.ReturnedMsg;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                    cmd.Dispose();
                }
            }
            // access the list, get that record , fill the returned at
        }
        public DataTable SearchBook(string _searchArg)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                SqlCommand cmd = new SqlCommand("SearchBook", connection);
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", _searchArg);
                    adapter.SelectCommand = cmd;
                    adapter.Fill(table);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                return table;
            }

            /*try
            {  
                List<BookModel> retList=new List<BookModel>();
                foreach(BookModel srchObj in StaticDatabase._booksList.Where(m=>Convert.ToString(m.BookID)==_searchArg || m.Name.Contains(_searchArg)))
                {
                    retList.Add(srchObj);
                }
                return retList;
            }
            catch
            {
                throw;
            }*/


        }
       public  DataTable HistoryOfBook (int choice)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand("HistoryofBook", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", choice);
                try
                {
                    connection.Open();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(table);
                    return table;
                }
                catch
                {
                    throw;

                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        public  DataTable HistoryOfUser(int _userID)
        {
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                DataTable _historyInfo = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("UserHistory", connection);
                cmd.Parameters.AddWithValue("@userID", _userID);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(_historyInfo);
                    return _historyInfo;

                }
                catch
                {
                    throw;

                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        public string CheckBookAvailability(int bookID)
        {

            int checker=0;
            using (SqlConnection connection=new SqlConnection(dbstring))
            {
                SqlCommand cmd = new SqlCommand("CheckBookAvailability", connection);
                cmd.Parameters.AddWithValue("@bookID", bookID);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    checker = (int)cmd.ExecuteScalar();
                }
                catch
                {
                    throw;

                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            if(checker==1)
            return StringLiterals.BookAvailable;
            else
            return StringLiterals.BookNotAvailable;
        }
    }
}

using DomainLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Repository
{
    internal static class StaticDatabase
    {

        internal static List<BookModel> _booksList = new List<BookModel>()
        {
            new BookModel() {  BookID=1, Name="Book1", AuthorName="Author1", Department="IT", IsActive=true   },
            new BookModel() {  BookID=2, Name="Book2", AuthorName="Author2", Department="IT", IsActive=true   },
            new BookModel() {  BookID=3, Name="Book3", AuthorName="Author3", Department="CSE", IsActive=false },
            new BookModel() {  BookID=4, Name="Book4", AuthorName="Author4", Department="IT", IsActive=true },
            new BookModel() {  BookID=5, Name="Book5", AuthorName="Author1", Department="ECE", IsActive=false  }
        };

        internal static List<UserModel> _usersList = new List<UserModel>()
        {
            new UserModel() {  UserID=1, Name="User1", Email="admin", IsActive=true, Password="password", IsAdmin=true },
            new UserModel() {  UserID=2, Name="User2", Email="Author2", IsActive=true, Password="Pwd2"  ,IsAdmin=false  },
            new UserModel() {  UserID=3, Name="User3", Email="Author3", IsActive=false, Password="Pwd3" ,IsAdmin=false },
            new UserModel() {  UserID=4, Name="User4", Email="Author4", IsActive=true, Password="Pwd4"  ,IsAdmin=false},
            new UserModel() {  UserID=5, Name="User5", Email="Author5", IsActive=false, Password="Pwd5" , IsAdmin=false }
        };

        internal static List<BookHistoryModel> _bookHistoryList = new List<BookHistoryModel>()
        {
            
        };
        

    }

}


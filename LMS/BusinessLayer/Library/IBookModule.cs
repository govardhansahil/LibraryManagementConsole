using DomainLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);

        string ReturnBook(int retID);

        string AddBook(BookModel bookObj);

        string RemoveBook(int bookID);

        DataTable GetAllBooks(int selector);
        DataTable SearchBook(string _searchArg);
        DataTable HistoryOfBook (int choice);
       DataTable HistoryOfUser(int _userID);
        string CheckBookAvailability(int bookID);
    }
}

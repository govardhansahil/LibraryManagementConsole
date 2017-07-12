using DomainLayer.Models;
using System.Data;
using Repo = Repository.Library;

namespace BusinessLayer.Library
{
    internal class BookModule : IBookModule
    {
        Repo.IBookModule _bookObj;

        public BookModule()
        {
            _bookObj = Repository.RepoFactory.GetBookModuleObject();
        }

        public string AddBook(BookModel bookObj)
        {
            return _bookObj.AddBook(bookObj);
        }

        public DataTable GetAllBooks(int selector)
        {
            return _bookObj.GetAllBooks(selector);
        }

        public string IssueBook(BookHistoryModel obj)
        {
            return _bookObj.IssueBook(obj);
        }

        public string RemoveBook(int bookID)
        {
            return _bookObj.RemoveBook(bookID);
        }

        public string ReturnBook(int retID)
        {
            return _bookObj.ReturnBook(retID);
        }
        public DataTable SearchBook(string _searchArg)
        {

            return _bookObj.SearchBook(_searchArg);
        }
        public DataTable HistoryOfBook (int choice)
        {
            return _bookObj.HistoryOfBook(choice);
        }
         public DataTable HistoryOfUser(int _userID)
        {
            return _bookObj.HistoryOfUser(_userID);
        }
        public string CheckBookAvailability(int bookID)
        {
            return _bookObj.CheckBookAvailability(bookID);
        }
    }
}

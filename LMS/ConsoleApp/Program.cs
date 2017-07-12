using BusinessLayer;
using BusinessLayer.Auth;
using DomainLayer;
using BusinessLayer.Library;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp
{
    class Program
    {
        static int result;
        static void Main(string[] args)
        {
            Console.Title=StringLiterals.ConsoleTitle;
            IAuthentication obj = BALFactory.GetAuthenticationObject();
            AuthModel argObj = new AuthModel();
Login:      Console.WriteLine(StringLiterals.EnterCredentials);
            Console.Write(StringLiterals.EmailEntry);
            argObj.Email = Console.ReadLine();
            Console.Write(StringLiterals.PasswordEntry);
            argObj.Password = Console.ReadLine();
            result = obj.Authenticate(argObj);
            if (result==1)
            {
                Console.Clear();
                int iterer;
                do
                {
                    iterer=AdminChoiceSelect();
                } while (iterer != 1);
            }
            else if(result==2)
            {
                Console.Clear();
                int iterer;
                do
                {
                    iterer=UserChoiceSelect();
                } while (iterer != 1);
            }
            else if(result==0)
            {
                Console.Clear();
                Console.WriteLine(StringLiterals.InvalidCredentials);
                goto Login;
            }
            Console.WriteLine(StringLiterals.ExitApp);
            Console.ReadKey();

        }

        public static  int AdminChoiceSelect()
        {
            IBookModule BookChoice = BALFactory.GetBookModuleObject();
            int choice;
            Console.WriteLine(StringLiterals.Welcome);
            Console.WriteLine(StringLiterals.AdminChoice);
            Console.Write(StringLiterals.ChoiceEntry);
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.EnterBookDetails);
                    Console.Write(StringLiterals.BookName);
                    string _bookName = Console.ReadLine();
                    Console.Write(StringLiterals.BookAuthor);
                    string _bookAuthor = Console.ReadLine();
                    Console.Write(StringLiterals.BookDepartment);
                    string _bookDept = Console.ReadLine();
                    Console.Write(StringLiterals.Remarks);
                    string _bookRemarks=Console.ReadLine();
                    Console.Write(StringLiterals.NumberofBooks);
                    int _bookCount=Int32.Parse(Console.ReadLine());
                    for(int _loopAdd=0;_loopAdd<_bookCount;_loopAdd++)
                    {
                        BookChoice.AddBook(new BookModel{
                            Name=_bookName,
                            AuthorName=_bookAuthor,
                            Department=_bookDept,
                            Remarks=_bookRemarks,
                            IsActive=true
                        });
                    }
                    break;

                case 2:
                    Console.Clear();
                    BookHistoryModel issueInfo = new BookHistoryModel();
                    Console.WriteLine(StringLiterals.IssuingDetails);
                    Console.Write(StringLiterals.BookID);
                    issueInfo.BookID = Int32.Parse(Console.ReadLine());
                    Console.Write(StringLiterals.UserID);
                    issueInfo.UserID = Int32.Parse(Console.ReadLine());
                    Console.Write(StringLiterals.IssueTime);
                    issueInfo.OperationPerformedAt = DateTime.Now;
                    Console.WriteLine(issueInfo.OperationPerformedAt);
                    Console.Write(StringLiterals.Validity);
                    issueInfo.ReturnedAt = DateTime.Now.AddDays(30);
                    Console.WriteLine(issueInfo.ReturnedAt);
                    Console.Write(StringLiterals.Remarks);
                    issueInfo.Remarks = Console.ReadLine();
                    Console.Write(StringLiterals.AuthorityID);
                    issueInfo.PerformedByID=Int32.Parse(Console.ReadLine());
                    string _issuemsg=BookChoice.IssueBook(issueInfo);
                    Console.WriteLine(_issuemsg);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.EnterBookDetails);
                    Console.Write(StringLiterals.BookID);
                    int _returnID=Int32.Parse(Console.ReadLine());
                    string _retMsg=BookChoice.ReturnBook(_returnID);
                    Console.WriteLine(_retMsg);
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.BookID);
                    int _removeID = Int32.Parse(Console.ReadLine());
                    string _removemsg=BookChoice.RemoveBook(_removeID);
                    Console.WriteLine(_removemsg);
                    break;

                case 5:
                    Console.Clear();
                    int _getList=0;
                    Console.WriteLine(StringLiterals.BookListChoice);
                    int _listChoice=Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    if(_listChoice==1) _getList=1;
                    else if(_listChoice==2) _getList=2; 
                    else if (_listChoice==3) _getList=3;
                    else Console.WriteLine(StringLiterals.InvalidEntry);
                    DataTable BookList = BookChoice.GetAllBooks(_getList);
                    foreach (DataRow item in BookList.Rows) {
                        Console.WriteLine(StringLiterals.BookListOut,item[0],item[1],item[3],item[2]);
                    }
                    Console.Write(StringLiterals.PressContinue);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 6:
historylabel:       Console.Clear();
                    Console.WriteLine(StringLiterals.BookHistoryChoice);
                    _listChoice=Int32.Parse(Console.ReadLine());
                    DataTable histList = BookChoice.HistoryOfBook(_listChoice);
                    if(_listChoice==1)
                    {
                    foreach(DataRow item in histList.Rows)
                    {
                        Console.WriteLine(StringLiterals.IssueOut,item[0],item[1],item[2],item[7]);
                    }
                    }
                    
                    else if(_listChoice==2)
                    {
                    foreach(DataRow item in histList.Rows)
                    {
                        Console.WriteLine(StringLiterals.ReturnOut,item[0],item[1],item[3],item[7]);
                    }
                    }
                    else if(_listChoice==3)
                    {
                        foreach(DataRow item in histList.Rows)
                        {
                        Console.WriteLine(StringLiterals.AllLog,item[0],item[1],item[2],item[3],item[7]);
                        } 
                    }
                    else
                    {
                        Console.Write(StringLiterals.InvalidEntry); goto historylabel;
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 7:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.BookName);
                    string _searcharg=Console.ReadLine();
                    DataTable _srchList=BookChoice.SearchBook(_searcharg);
                    foreach(DataRow item in _srchList.Rows){
                        Console.WriteLine(StringLiterals.SearchResult,item[0],item[1],item[3],item[2]);
                    }
                    Console.WriteLine(StringLiterals.PressContinue);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 8:
                    Console.Clear();
                    IAuthentication _userEntry=BALFactory.GetAuthenticationObject();
                    UserModel _newuser=new UserModel();
                    Console.WriteLine(StringLiterals.UserEntry);
                    Console.Write(StringLiterals.UserName);
                    _newuser.Name=Console.ReadLine();
                    Console.Write(StringLiterals.UserEmail);
                    _newuser.Email=Console.ReadLine();
                    Console.WriteLine(_userEntry.Register(_newuser));
                    break;

                case 9:
                    Console.WriteLine(StringLiterals.SignOut);
                    return 1;

            } return 0;
            
        }
        
        public static  int UserChoiceSelect()
        {
            IBookModule BookChoice = BALFactory.GetBookModuleObject();
            int choice;
            Console.WriteLine(StringLiterals.UserChoice);
            Console.Write(StringLiterals.ChoiceEntry);
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                     Console.Clear();
                    Console.WriteLine(StringLiterals.BookName);
                    string _searcharg=Console.ReadLine();
                    DataTable _srchList=BookChoice.SearchBook(_searcharg);
                    foreach(DataRow item in _srchList.Rows){
                        Console.WriteLine(StringLiterals.SearchResult,item[0],item[1],item[3],item[2]);
                    }
                    Console.WriteLine(StringLiterals.PressContinue);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.UserID);
                    int _userID=Int32.Parse(Console.ReadLine());
                    DataTable histList = BookChoice.HistoryOfUser(_userID);
                    foreach(DataRow item in histList.Rows)
                    {
                        Console.WriteLine(StringLiterals.UserHistory,item[0],item[2],item[3],item[7]);
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.EnterBookDetails);
                    Console.Write(StringLiterals.BookID);
                    int _bookID=Int32.Parse(Console.ReadLine());
                    Console.WriteLine(BookChoice.CheckBookAvailability(_bookID));
                    break;
                case 4:
                    Console.WriteLine(StringLiterals.SignOut);
                    return 1;

            } return 0;
            
        }

        
    }
}

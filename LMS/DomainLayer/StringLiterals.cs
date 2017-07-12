namespace DomainLayer
{
    public static class StringLiterals
    {
        public static string BookIsAssignedToUser { get { return "Book is assigned to user"; } }

        public static string SuccesMsg { get { return "Success"; } }
        public static string RemoveMsg { get { return "Book Removed..."; } }
        public static string ReturnedMsg {get {return "Book Returned...";} }
        public static string RegisteredMsg{get {return "Successfully registered...";}}
        public static string BookAvailable{get {return "Book is Available for issue...";}}
        public static string BookNotAvailable{get {return "Book is not available for issue...";}}
        public static string NoHistoryAvailabl{get {return "No History found with this UserID...";}}
        public static string ExceptionOccured{get{return "Unhandled Exception Occured";}}
        public static string EnterCredentials{get{return "Enter Credentials\n";}}
        public  static string InvalidCredentials{get{return "Invalid Credentials\n";}}
        public static string EmailEntry{get{return "Email: ";}}
        public static string PasswordEntry{get{return "Password: ";}}
        public static string ExitApp{get{return "Press Enter to Exit the Application...";}}
        public static string Welcome{get{return "Welcome to Library\n";}}
        public static string AdminChoice{get{return "\nSelect the choice of operation\n\n" +
                "1. Add Book\n" +
                "2. Issue Book\n" +
                "3. Return Book\n" +
                "4. Remove Book\n" +
                "5. Get All Books\n"+
                "6. Get Issue or Return History\n"+
                "7. Search a Book\n"+
                "8. New User Registration\n"+
                "9. Log Out\n";}}
        public static string ChoiceEntry{get{return "Enter choice : ";}}
        public static string EnterBookDetails{get{return "Enter the Book Details: \n";}}
        public static string BookName{get{return "Book Name: ";}}
        public static string BookID{get{return "Book ID: ";}}
        public static string UserID{get{return "UserId: ";}}
        public static string BookAuthor{get{return "Book Author: ";}}
        public static string BookDepartment{get{return "Department: ";}}
        public static string Remarks{get{return "Remarks: ";}}
        public static string NumberofBooks{get{return "Number of Books: ";}}
        public static string IssuingDetails{get{return "Enter issuing details\n";}}
        public static string IssueTime{get{return "Issue Time: ";}}
        public static string Validity{get{return "Validity: ";}}
        public static string AuthorityID{get{return "Issuing Authority ID: ";}}
        public static string BookListChoice{get{return "1.List all Active books\n"
                    +"2.List available books\n"
                    +"3.Archieved Books\n"
                    +"Enter your choice: ";}}
        public static string InvalidEntry{get{return "Invalid Entry..\n";}}
        public static string BookListOut{get{return "\nBook ID: {0}\n" +
                            "Book Name: {1}\n" +
                            "Author: {2}\n" +
                            "Department: {3}\n";}}
        public static string PressContinue{get{return "Press any key to continue...";}}
        public static string BookHistoryChoice{get{return "1. Book Issue History\n"+"2. Book Return History\n"+"3.History Log\n";}}
        public static string IssueOut{get{return 
                        "Book ID: {0}\n"+
                        "User ID: {1}\n"+
                        "Issue Time: {2}\n"+
                        "Issued Authority ID: {3}\n";}}
        public static string ReturnOut{get{return "Book ID: {0}\n"+"User ID: {1}\n"+"Return Time: {2}\n"+"Issued Authority ID: {3}\n";}}
        public static string AllLog{get{return "Book ID:{0}\n"+"User ID:{1}\n"+"Issue Time:{2}\n"+"Returned Time:{3}\n"+"Issued Authority ID:{4}\n";}}
        public static string SearchResult{get{return "\nBookID: {0}\n"+
                        "Book Name: {1}\n"+
                        "Author: {2}\n"+
                        "Department: {3}\n";}}
        public static string UserEntry{get{return "\n_____Enter details of the User_____";}}
        public static string UserName{get{return "User Name: ";}}
        public static string UserEmail{get{return "User Email: ";}}
        public static string SignOut{get{return "Signing Out...";}}
        public static string UserChoice{get{return "\nWelcome to Library!\n\n" +
                "Select the choice of operation\n\n" +
                "1. Search a Book\n"+
                "2. Issue and Return History\n"+
                "3. Check Book availability\n"+
                "4. Log Out\n";}}
    
        public static string UserHistory{get{return "Book ID: {0}\n"+
                        "Issue Time: {1}\n"+
                        "Return Time: {2}\n"+
                        "Issued Authority ID: {4}\n";}}
        public static string ConsoleTitle{get{return "Library Management System";}}
    }
}

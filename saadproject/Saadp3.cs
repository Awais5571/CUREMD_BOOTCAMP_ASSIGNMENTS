using System;
using System.Collections.Generic;
using System.Linq;

// Abstract base class for Book
abstract class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int BookID { get; set; }
    public bool BookIssued { get; set; } = false;

    public Book(string title, string author, int bookID)
    {
        Title = title;
        Author = author;
        BookID = bookID;
    }

    public abstract void display_info();
}

class FictionBook : Book
{
    public string Genre { get; set; }

    public FictionBook(string title, string author, int bookID, string genre)
        : base(title, author, bookID)
    {
        Genre = genre;
    }

    public override void display_info()
    {
        Console.WriteLine($"**********Book ID: {BookID}, Title: {Title}, Author: {Author}, Genre: {Genre}, Issued: {BookIssued}**********");
    }
}

class NonFictionBook : Book
{
    public string Subject { get; set; }

    public NonFictionBook(string title, string author, int bookID, string subject)
        : base(title, author, bookID)
    {
        Subject = subject;
    }

    public override void display_info()
    {
        Console.WriteLine($"**********Book ID: {BookID}, Title: {Title}, Author: {Author}, Subject: {Subject}, Issued: {BookIssued}**********");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int PersonID { get; set; }

    public Person(string name, int age, int personID)
    {
        Name = name;
        Age = age;
        PersonID = personID;
    }
}

class Librarian : Person
{
    public int EmployeeID { get; set; }
    public string Code { get; set; }

    public Librarian(string name, int age, int personID, int employeeID, string code)
        : base(name, age, personID)
    {
        EmployeeID = employeeID;
        Code = code;
    }

    public void issue_book(Book book, User user, Library library)
    {
        if (!book.BookIssued)
        {
            book.BookIssued = true;
            user.IssuedBooks.Add(book);
            string transaction = $"**********Book '{book.Title}' issued to {user.Name} by {Name}**********";
            library.TransactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine($"Book '{book.Title}' is already issued.");
        }
    }

    public void return_books(Book book, User user, Library library)
    {
        if (book.BookIssued)
        {
            book.BookIssued = false;
            user.IssuedBooks.Remove(book);
            string transaction = $"**********Book '{book.Title}' returned by {user.Name}**********";
            library.TransactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine($"**********Book '{book.Title}' was not issued**********");
        }
    }

    public void add_book(Book book, Library library)
    {
        library.Books.Add(book);
        string transaction = $"Book '{book.Title}' added to the library by {Name}.";
        library.TransactionHistory.Add(transaction);
        Console.WriteLine(transaction);
    }

    public void remove_book(int bookID, Library library)
    {
        Book bookToRemove = library.Books.Find(b => b.BookID == bookID);
        if (bookToRemove != null)
        {
            library.Books.Remove(bookToRemove);
            string transaction = $"**********Book ID {bookID} removed from the library by {Name}**********";
            library.TransactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine($"Book ID {bookID} not found in the library.");
        }
    }
}

class User : Person
{
    public List<Book> IssuedBooks { get; set; }

    public User(string name, int age, int personID)
        : base(name, age, personID)
    {
        IssuedBooks = new List<Book>();
    }

    public void issue_book(Book book, Library library)
    {
        if (!book.BookIssued)
        {
            book.BookIssued = true;
            IssuedBooks.Add(book);
            string transaction = $"**********Book '{book.Title}' issued by {Name}**********";
            library.TransactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine($"**********Book '{book.Title}' is already issued**********");
        }
    }

    public void return_books(Book book, Library library)
    {
        if (book.BookIssued)
        {
            book.BookIssued = false;
            IssuedBooks.Remove(book);
            string transaction = $"**********Book '{book.Title}' returned by {Name}**********";
            library.TransactionHistory.Add(transaction);
            Console.WriteLine(transaction);
        }
        else
        {
            Console.WriteLine($"**********Book '{book.Title}' was not issued**********");
        }
    }
}

class Library
{
    public string LibraryName { get; set; }
    public int LibraryID { get; set; }
    public List<Book> Books { get; set; }
    public Librarian Librarian { get; set; }
    public List<User> Users { get; set; }
    public List<string> TransactionHistory { get; set; }

    public Library(string libraryName, int libraryID)
    {
        LibraryName = libraryName;
        LibraryID = libraryID;
        Books = new List<Book>();
        Users = new List<User>();
        TransactionHistory = new List<string>();
    }

    public void add_book(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"**********Book '{book.Title}' added to the library**********");
    }

    public void remove_book(int bookID)
    {
        Book bookToRemove = Books.Find(b => b.BookID == bookID);
        if (bookToRemove != null)
        {
            Books.Remove(bookToRemove);
            Console.WriteLine($"**********Book ID {bookID} removed from the library**********");
        }
        else
        {
            Console.WriteLine($"**********Book ID {bookID} not found in the library**********");
        }
    }

    public void view_books()
    {
        if (Books.Count == 0)
        {
            Console.WriteLine("**********No books in the library**********");
        }
        else
        {
            Console.WriteLine("**********Books in the library**********");
            foreach (Book book in Books)
            {
                book.display_info();
            }
        }
    }

    public void search_books(string title)
    {
        bool found = false;
        foreach (Book book in Books)
        {
            if (book.Title.ToLower().Contains(title.ToLower()))
            {
                book.display_info();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine($"**********No books found with title '{title}'**********");
        }
    }

    public void list_issued_books()
    {
        bool found = false;
        foreach (Book book in Books)
        {
            if (book.BookIssued)
            {
                book.display_info();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("**********No books are currently issued**********\n");
        }
    }

    public void DisplayTransactionHistory()
    {
        if (TransactionHistory.Count == 0)
        {
            Console.WriteLine("**********No transactions recorded**********\n");
        }
        else
        {
            Console.WriteLine("**********Transaction History**********\n");
            foreach (string transaction in TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }

    public User register_user(string name, int age, int userID)
    {
        User user = new User(name, age, userID);
        Users.Add(user);
        Console.WriteLine($"**********User '{name}' registered successfully**********\n");
        return user;
    }

    public User login_user_check(int userID)
    {
        return Users.Find(user => user.PersonID == userID);
    }

    public void list_all_books()
    {
        bool found = false;
        foreach (Book book in Books)
        {
            if (!book.BookIssued)
            {
                book.display_info();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("**********No available books**********");
        }
    }

    public Librarian register_librarian(string name, int age, int personID, int employeeID, string code)
    {
        Librarian librarian = new Librarian(name, age, personID, employeeID, code);
        Librarian = librarian; // Assigning the registered librarian to the library
        Console.WriteLine($"**********Librarian '{name}' registered successfully**********\n");
        return librarian;
    }

    public Librarian login_librarian_check(int employeeID, string code)
    {
        if (Librarian != null && Librarian.EmployeeID == employeeID && Librarian.Code == code)
        {
            return Librarian;
        }
        return null;
    }

    public void register_self()
    {
        Console.Write("**********Enter Name*****************\n");
        string name = Console.ReadLine();
        Console.Write("**********Enter Age******************\n");
        int age = int.Parse(Console.ReadLine());
        Console.Write("**********Enter Employee ID**********\n");
        int employeeID = int.Parse(Console.ReadLine());
        Console.Write("**********Enter Code*****************\n");
        string code = Console.ReadLine();

        Librarian = new Librarian(name, age, -1, employeeID, code); // Assuming -1 for personID as it's not used here
        Console.WriteLine($"**********Librarian '{name}' registered successfully**********\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library("Central Library", 1);

        while (true)
        {

            Console.WriteLine("\nWelcome to the  Library Management System\n\n");
            Console.WriteLine("********** 1. Register as Librarian **********\n");
            Console.WriteLine("********** 2. Login as Librarian *************\n");
            Console.WriteLine("********** 3. Register as User ***************\n");
            Console.WriteLine("********** 4. Login as User ******************\n");
            Console.WriteLine("********** 5. Exit ***************************\n");
            Console.Write("********** >< Select an option ***************\n");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    library.register_self();
                    break;
                case "2":
                    login_librarian(library);
                    break;
                case "3":
                    register_user(library);
                    break;
                case "4":
                    login_user(library);
                    break;
                case "5":
                    Console.WriteLine("********** Thank you for using the Library Management System **********");
                    return;
                default:
                    Console.WriteLine("********** Invalid option. Please try again ***************************");
                    break;
            }
        }
    }

    static void register_user(Library library)
    {
        Console.Write("********** Enter Name *************\n");
        string name = Console.ReadLine();
        Console.Write("********** Enter Age **************\n");
        int age = int.Parse(Console.ReadLine());
        Console.Write("********** Enter User ID **********\n");
        int userID = int.Parse(Console.ReadLine());

        library.register_user(name, age, userID);
    }

    static void login_librarian(Library library)
    {
        Console.Write("********** Enter Employee ID **********\n");
        int employeeID = int.Parse(Console.ReadLine());
        Console.Write("********** Enter Code **********\n");
        string code = Console.ReadLine();

        Librarian librarian = library.login_librarian_check(employeeID, code);
        if (librarian != null)
        {
            Console.WriteLine($"********** Librarian '{librarian.Name}' logged in successfully **********");
            LibrarianMenu(library, librarian);
        }
        else
        {
            Console.WriteLine("********** Invalid Employee ID or Code **********");
        }
    }

    static void login_user(Library library)
    {
        Console.Write("********** Enter User ID **********\n");
        int userID = int.Parse(Console.ReadLine());

        User user = library.login_user_check(userID);
        if (user != null)
        {
            Console.WriteLine($"********** User '{user.Name}' logged in successfully **********\n");
            UserMenu(library, user);
        }
        else
        {
            Console.WriteLine("********** Invalid User ID **********");
        }
    }

    static void LibrarianMenu(Library library, Librarian librarian)
    {
        while (true)
        {
            Console.WriteLine("\nLibrarian Menu");
            Console.WriteLine("********** 1. Add Book **********\n");
            Console.WriteLine("********** 2. Remove Book **********\n");
            Console.WriteLine("********** 3. View Books **********\n");
            Console.WriteLine("********** 4. Search Book **********\n");
            Console.WriteLine("********** 5. List Issued Books **********\n");
            Console.WriteLine("********** 6. View Transaction History **********\n");
            Console.WriteLine("********** 7. Logout **********\n");
            Console.Write("********** Select an option **********\n");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    add_book(library, librarian);
                    break;
                case "2":
                    remove_book(library, librarian);
                    break;
                case "3":
                    library.view_books();
                    break;
                case "4":
                    search_books(library);
                    break;
                case "5":
                    library.list_issued_books();
                    break;
                case "6":
                    library.DisplayTransactionHistory();
                    break;
                case "7":
                    Console.WriteLine("Logging out...");
                    return;
                default:
                    Console.WriteLine("********** Invalid option. Please try again **********\n");
                    break;
            }
        }
    }

    static void UserMenu(Library library, User user)
    {
        while (true)
        {
            Console.WriteLine("\nUser Menu");
            Console.WriteLine("********** 1. View Books **********");
            Console.WriteLine("********** 2. Search Book **********");
            Console.WriteLine("********** 3. List Available Books **********");
            Console.WriteLine("********** 4. Issue Book **********");
            Console.WriteLine("********** 5. Return Book **********");
            Console.WriteLine("********** 6. Logout");
            Console.Write("Select an option **********\n");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    library.view_books();
                    break;
                case "2":
                    search_books(library);
                    break;
                case "3":
                    library.list_all_books();
                    break;
                case "4":
                    issue_book(library, user);
                    break;
                case "5":
                    return_books(library, user);
                    break;
                case "6":
                    Console.WriteLine("********** Logging out.. **********");
                    return;
                default:
                    Console.WriteLine("********** Invalid option. Please try again **********");
                    break;
            }
        }
    }

    static void add_book(Library library, Librarian librarian)
    {
        Console.Write("********** Enter Book Title **************\n");
        string title = Console.ReadLine();
        Console.Write("********** Enter Author ******************\n");
        string author = Console.ReadLine();
        Console.Write("********** Enter Book ID *****************\n");
        int bookID = int.Parse(Console.ReadLine());
        Console.Write("********** Enter Genre/Subject ***********\n");
        string genreOrSubject = Console.ReadLine();

        Console.WriteLine("********** Select Book Type **********\n");
        Console.WriteLine("********** 1. Fiction ****************");
        Console.WriteLine("********** 2. Non-Fiction ************");
        Console.Write("********** Select an option **************\n");
        string bookTypeOption = Console.ReadLine();

        switch (bookTypeOption)
        {
            case "1":
                FictionBook fictionBook = new FictionBook(title, author, bookID, genreOrSubject);
                librarian.add_book(fictionBook, library);
                break;
            case "2":
                NonFictionBook nonFictionBook = new NonFictionBook(title, author, bookID, genreOrSubject);
                librarian.add_book(nonFictionBook, library);
                break;
            default:
                Console.WriteLine("********** Invalid option **********");
                break;
        }
    }

    static void remove_book(Library library, Librarian librarian)
    {
        Console.Write(" ********** Enter Book ID to remove **********");
        int bookID = int.Parse(Console.ReadLine());
        librarian.remove_book(bookID, library);
    }

    static void search_books(Library library)
    {
        Console.Write("********** Enter Book Title to search *********\n");
        string title = Console.ReadLine();
        library.search_books(title);
    }

    static void issue_book(Library library, User user)
    {
        Console.Write("********** Enter Book ID to issue **********\n");
        int bookID = int.Parse(Console.ReadLine());
        Book bookToIssue = library.Books.Find(b => b.BookID == bookID);
        if (bookToIssue != null)
        {
            user.issue_book(bookToIssue, library);
        }
        else
        {
            Console.WriteLine($"********** Book ID {bookID} not found in the library **********");
        }
    }

    static void return_books(Library library, User user)
    {
        Console.Write("********** Enter Book ID to return **********\n");
        int bookID = int.Parse(Console.ReadLine());
        Book bookToReturn = library.Books.Find(b => b.BookID == bookID);
        if (bookToReturn != null)
        {
            user.return_books(bookToReturn, library);
        }
        else
        {
            Console.WriteLine($"********** Book ID {bookID} not found in the library **********\n");
        }
    }
}

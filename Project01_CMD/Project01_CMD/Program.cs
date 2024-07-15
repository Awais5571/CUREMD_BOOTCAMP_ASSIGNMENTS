using System;
//using System.Collections.Generic;
//using System.Linq;

namespace MyApp
{
    // Abstract base class for Book
    abstract class Book
    {
        // Properties for Book
        public string Title { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }

        // Constructor for Book
        public Book(string title, string author, int bookID)
        {
            Title = title;
            Author = author;
            BookID = bookID;
        }

        // Abstract method to display book information
        public abstract void DisplayInfo();
    }

    // Derived class for FictionBook
    class FictionBook : Book
    {
        public string Genre { get; set; }

        // Constructor for FictionBook
        public FictionBook(string title, string author, int bookID, string genre)
            : base(title, author, bookID)
        {
            Genre = genre;
        }

        // Override method to display fiction book information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Fiction Book: {Title}, Author: {Author}, Genre: {Genre}, ID: {BookID}");
        }
    }

    // Derived class for NonFictionBook
    class NonFictionBook : Book
    {
        public string Subject { get; set; }

        // Constructor for NonFictionBook
        public NonFictionBook(string title, string author, int bookID, string subject)
            : base(title, author, bookID)
        {
            Subject = subject;
        }

        // Override method to display non-fiction book information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Non-Fiction Book: {Title}, Author: {Author}, Subject: {Subject}, ID: {BookID}");
        }
    }

    // Class representing a Person
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonID { get; set; }

        // Constructor for Person
        public Person(string name, int age, int personID)
        {
            Name = name;
            Age = age;
            PersonID = personID;
        }
    }

    // Derived class for Librarian
    class Librarian : Person
    {
        public int EmployeeID { get; set; }

        // Constructor for Librarian
        public Librarian(string name, int age, int personID, int employeeID)
            : base(name, age, personID)
        {
            EmployeeID = employeeID;
        }

        // Method to issue a book to a user
        public void IssueBook(Book book, Person user)
        {
            Console.WriteLine($"{Name} issued book '{book.Title}' to {user.Name}");
        }

        // Method to return a book from a user
        public void ReturnBook(Book book, Person user)
        {
            Console.WriteLine($"{Name} returned book '{book.Title}' from {user.Name}");
        }
    }

    // Class representing a Library
    class Library
    {
        public string LibraryName { get; set; }
        public int LibraryID { get; set; }
        private List<Book> books; // List to store books in the library
        private List<Book> issuedBooks; // List to store issued books
        private List<Book> returnedBooks; // List to store returned books
        public Librarian Librarian { get; set; }

        // Constructor for Library
        public Library(string libraryName, int libraryID, Librarian librarian)
        {
            LibraryName = libraryName;
            LibraryID = libraryID;
            Librarian = librarian;
            books = new List<Book>();
            issuedBooks = new List<Book>();
            returnedBooks = new List<Book>();
        }

        // Method to add a book to the library
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to {LibraryName}");
        }

        // Method to remove a book from the library
        public void RemoveBook(int bookID)
        {
            Book book = books.FirstOrDefault(b => b.BookID == bookID);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"Book '{book.Title}' removed from {LibraryName}");
            }
            else
            {
                Console.WriteLine($"Book with ID {bookID} not found in {LibraryName}");
            }
        }

        // Method to view all books in the library
        public void ViewBooks()
        {
            Console.WriteLine($"Books in {LibraryName}:");
            foreach (var book in books)
            {
                book.DisplayInfo();
            }
        }

        // Method to search for a book by title
        public void SearchBook(string title)
        {
            var foundBooks = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            if (foundBooks.Any())
            {
                Console.WriteLine($"Books found with title containing '{title}':");
                foreach (var book in foundBooks)
                {
                    book.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine($"No books found with title containing '{title}'");
            }
        }

        // Method to issue a book to a user
        public void IssueBook(int bookID, Person user)
        {
            Book book = books.FirstOrDefault(b => b.BookID == bookID);
            if (book != null)
            {
                Librarian.IssueBook(book, user);
                issuedBooks.Add(book);
                books.Remove(book);
            }
            else
            {
                Console.WriteLine($"Book with ID {bookID} not found in {LibraryName}");
            }
        }

        // Method to return a book from a user
        public void ReturnBook(int bookID, Person user)
        {
            Book book = issuedBooks.FirstOrDefault(b => b.BookID == bookID);
            if (book != null)
            {
                Librarian.ReturnBook(book, user);
                returnedBooks.Add(book);
                books.Add(book);
                issuedBooks.Remove(book);
            }
            else
            {
                Console.WriteLine($"Book with ID {bookID} not currently issued in {LibraryName}");
            }
        }

        // Method to view all issued books
        public void ViewIssuedBooks()
        {
            Console.WriteLine($"Issued Books in {LibraryName}:");
            foreach (var book in issuedBooks)
            {
                book.DisplayInfo();
            }
        }

        // Method to view all returned books
        public void ViewReturnedBooks()
        {
            Console.WriteLine($"Returned Books in {LibraryName}:");
            foreach (var book in returnedBooks)
            {
                book.DisplayInfo();
            }
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            var libraries = new List<Library>(); // List to store libraries

            while (true)
            {
                // Main menu
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Library");
                Console.WriteLine("2. Manage Library");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    // Add a new library
                    Console.Write("Enter Library Name: ");
                    string libraryName = Console.ReadLine();
                    Console.Write("Enter Library ID: ");
                    int libraryID = int.Parse(Console.ReadLine());
                    Console.Write("Enter Librarian Name: ");
                    string librarianName = Console.ReadLine();
                    Console.Write("Enter Librarian Age: ");
                    int librarianAge = int.Parse(Console.ReadLine());
                    Console.Write("Enter Librarian Person ID: ");
                    int librarianPersonID = int.Parse(Console.ReadLine());
                    Console.Write("Enter Librarian Employee ID: ");
                    int librarianEmployeeID = int.Parse(Console.ReadLine());

                    var librarian = new Librarian(librarianName, librarianAge, librarianPersonID, librarianEmployeeID);
                    var library = new Library(libraryName, libraryID, librarian);
                    libraries.Add(library);

                    Console.WriteLine($"'{libraryName}' added successfully!");
                }
                else if (option == 2)
                {
                    // Manage an existing library
                    Console.Write("Enter Library ID to manage: ");
                    int libraryID = int.Parse(Console.ReadLine());
                    var library = libraries.FirstOrDefault(l => l.LibraryID == libraryID);

                    if (library != null)
                    {
                        while (true)
                        {
                            // Library management menu
                            Console.WriteLine($"Managing Library: {library.LibraryName}");
                            Console.WriteLine("1. Add Book");
                            Console.WriteLine("2. Remove Book");
                            Console.WriteLine("3. View Books");
                            Console.WriteLine("4. Search Book");
                            Console.WriteLine("5. Issue Book");
                            Console.WriteLine("6. Return Book");
                            Console.WriteLine("7. View Issued Books");
                            Console.WriteLine("8. View Returned Books");
                            Console.WriteLine("9. Back to Main Menu");
                            Console.Write("Choose an option: ");
                            int manageOption = int.Parse(Console.ReadLine());

                            if (manageOption == 1)
                            {
                                // Add a book to the library
                                Console.Write("Enter Book Title: ");
                                string bookTitle = Console.ReadLine();
                                Console.Write("Enter Book Author: ");
                                string bookAuthor = Console.ReadLine();
                                Console.Write("Enter Book ID: ");
                                int bookID = int.Parse(Console.ReadLine());
                                Console.WriteLine("Choose Book Type: 1. Fiction 2. Non-Fiction");
                                int bookType = int.Parse(Console.ReadLine());

                                if (bookType == 1)
                                {
                                    // Add a fiction book
                                    Console.Write("Enter Genre: ");
                                    string genre = Console.ReadLine();
                                    var book = new FictionBook(bookTitle, bookAuthor, bookID, genre);
                                    library.AddBook(book);
                                }
                                else if (bookType == 2)
                                {
                                    // Add a non-fiction book
                                    Console.Write("Enter Subject: ");
                                    string subject = Console.ReadLine();
                                    var book = new NonFictionBook(bookTitle, bookAuthor, bookID, subject);
                                    library.AddBook(book);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Book Type!");
                                }
                            }
                            else if (manageOption == 2)
                            {
                                // Remove a book from the library
                                Console.Write("Enter Book ID to remove: ");
                                int bookID = int.Parse(Console.ReadLine());
                                library.RemoveBook(bookID);
                            }
                            else if (manageOption == 3)
                            {
                                // View all books in the library
                                library.ViewBooks();
                            }
                            else if (manageOption == 4)
                            {
                                // Search for a book by title
                                Console.Write("Enter Book Title to search: ");
                                string bookTitle = Console.ReadLine();
                                library.SearchBook(bookTitle);
                            }
                            else if (manageOption == 5)
                            {
                                // Issue a book to a user
                                Console.Write("Enter Book ID to issue: ");
                                int bookID = int.Parse(Console.ReadLine());
                                Console.Write("Enter User Name: ");
                                string userName = Console.ReadLine();
                                Console.Write("Enter User Age: ");
                                int userAge = int.Parse(Console.ReadLine());
                                Console.Write("Enter User Person ID: ");
                                int userPersonID = int.Parse(Console.ReadLine());

                                var user = new Person(userName, userAge, userPersonID);
                                library.IssueBook(bookID, user);
                            }
                            else if (manageOption == 6)
                            {
                                // Return a book from a user
                                Console.Write("Enter Book ID to return: ");
                                int bookID = int.Parse(Console.ReadLine());
                                Console.Write("Enter User Name: ");
                                string userName = Console.ReadLine();
                                Console.Write("Enter User Age: ");
                                int userAge = int.Parse(Console.ReadLine());
                                Console.Write("Enter User Person ID: ");
                                int userPersonID = int.Parse(Console.ReadLine());

                                var user = new Person(userName, userAge, userPersonID);
                                library.ReturnBook(bookID, user);
                            }
                            else if (manageOption == 7)
                            {
                                // View all issued books
                                library.ViewIssuedBooks();
                            }
                            else if (manageOption == 8)
                            {
                                // View all returned books
                                library.ViewReturnedBooks();
                            }
                            else if (manageOption == 9)
                            {
                                // Go back to main menu
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Library not found!");
                    }
                }
                else if (option == 3)
                {
                    // Exit the program
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option!");
                }
            }
        }
    }
}

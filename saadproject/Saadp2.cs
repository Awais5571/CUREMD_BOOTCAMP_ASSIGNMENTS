using System; 
using System.Collections.Generic; 

class Book // Defining the Book class
{
    public string Title { get; set; } // Property to store the title of the book
    public string Author { get; set; } // Property to store the author of the book
    public int BookID { get; set; } // Property to store the ID of the book
    public bool BookIssued { get; set; } = false; // Property to check if the book is issued

    // Constructor to initialize book details
    public Book(string title, string author, int bookID)
    {
        Title = title; // Assigning the title
        Author = author; // Assigning the author
        BookID = bookID; // Assigning the book ID
    }

    // Method to display book information
    public void display_info()
    {
        Console.WriteLine("Book ID: " + BookID + ", Title: " + Title + ", Author: " + Author + ", Issued: " + BookIssued);
    }
}

class Person // Defining the Person class
{
    public string Name { get; set; } // Property to store the name of the person
    public int Age { get; set; } // Property to store the age of the person
    public int PersonID { get; set; } // Property to store the ID of the person

    // Constructor to initialize person details
    public Person(string name, int age, int personID)
    {
        Name = name; // Assigning the name
        Age = age; // Assigning the age
        PersonID = personID; // Assigning the person ID
    }
}

class Librarian : Person // Defining the Librarian class inheriting from Person
{
    public int EmployeeID { get; set; } // Property to store the employee ID

    // Constructor to initialize librarian details
    public Librarian(string name, int age, int personID, int employeeID)
        : base(name, age, personID) // Calling the base class constructor
    {
        EmployeeID = employeeID; // Assigning the employee ID
    }

    // Method to issue a book to a user
    public void issue_Book(Book book, User user)
    {
        if (!book.BookIssued) // Check if the book is not already issued
        {
            book.BookIssued = true; // Mark the book as issued
            user.IssuedBooks.Add(book); // Add the book to the user's issued books list
            Console.WriteLine("Book '" + book.Title + "' issued to " + user.Name + ".");
        }
        else
        {
            Console.WriteLine("Book '" + book.Title + "' is already issued.");
        }
    }

    // Method to return a book from a user
    public void return_Book(Book book, User user)
    {
        if (book.BookIssued) // Check if the book is issued
        {
            book.BookIssued = false; // Mark the book as not issued
            user.IssuedBooks.Remove(book); // Remove the book from the user's issued books list
            Console.WriteLine("Book '" + book.Title + "' returned by " + user.Name + ".");
        }
        else
        {
            Console.WriteLine("Book '" + book.Title + "' was not issued.");
        }
    }
}

class User : Person // Defining the User class inheriting from Person
{
    public List<Book> IssuedBooks { get; set; } // List to store issued books

    // Constructor to initialize user details
    public User(string name, int age, int personID)
        : base(name, age, personID) // Calling the base class constructor
    {
        IssuedBooks = new List<Book>(); // Initializing the list of issued books
    }
}

class Library // Defining the Library class
{
    public string LibraryName { get; set; } // Property to store the name of the library
    public int LibraryID { get; set; } // Property to store the ID of the library
    private List<Book> books; // List to store books
    public Librarian Librarian { get; set; } // Instance of librarian

    // Constructor to initialize library details
    public Library(string libraryName, int libraryID, Librarian librarian)
    {
        LibraryName = libraryName; // Assigning the library name
        LibraryID = libraryID; // Assigning the library ID
        books = new List<Book>(); // Initializing the list of books
        Librarian = librarian; // Assigning the librarian
    }

    // Method to add a book to the library
    public void add_Book(Book book)
    {
        books.Add(book); // Add the book to the list
        Console.WriteLine("Book '" + book.Title + "' added to the library.");
    }

    // Method to remove a book from the library using its ID
    public void remove_Book(int bookID)
    {
        Book bookToRemove = null; // Initializing a variable to store the book to remove
        foreach (Book book in books) // Loop through the list of books
        {
            if (book.BookID == bookID) // Check if the book ID matches
            {
                bookToRemove = book; // Assign the book to the variable
                break; // Break the loop
            }
        }
        if (bookToRemove != null) // Check if the book was found
        {
            books.Remove(bookToRemove); // Remove the book from the list
            Console.WriteLine("Book ID " + bookID + " removed from the library.");
        }
        else
        {
            Console.WriteLine("Book ID " + bookID + " not found in the library.");
        }
    }

    // Method to view all books in the library
    public void view_Books()
    {
        if (books.Count == 0) // Check if there are no books
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            Console.WriteLine("Books in the library:");
            foreach (Book book in books) // Loop through the list of books
            {
                book.display_info(); // Display book information
            }
        }
    }

    // Method to search for a book by title
    public void search_Book(string title)
    {
        bool found = false; // Flag to check if a book is found
        foreach (Book book in books) // Loop through the list of books
        {
            if (book.Title.ToLower().Contains(title.ToLower())) // Check if the title contains the search term
            {
                book.display_info(); // Display book information
                found = true; // Set the flag to true
            }
        }
        if (!found) // Check if no book was found
        {
            Console.WriteLine("No books found with title '" + title + "'.");
        }
    }

    // Method to list all issued books
    public void list_issued_books()
    {
        bool found = false; // Flag to check if any book is issued
        foreach (Book book in books) // Loop through the list of books
        {
            if (book.BookIssued) // Check if the book is issued
            {
                book.display_info(); // Display book information
                found = true; // Set the flag to true
            }
        }
        if (!found) // Check if no book is issued
        {
            Console.WriteLine("No books are currently issued.");
        }
    }
}

class Program // Defining the Program class
{
    static void Main(string[] args) // Main method, the entry point of the application
    {
        // Creating instances of books
        Book book1 = new Book("1984", "George Orwell", 1);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 2);
        Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 3);

        // Creating an instance of a librarian
        Librarian librarian = new Librarian("Alice", 30, 1, 1001);

        // Creating an instance of a library
        Library library = new Library("City Library", 101, librarian);

        // Adding books to the library
        library.add_Book(book1);
        library.add_Book(book2);
        library.add_Book(book3);

        // Viewing all books in the library
        library.view_Books();

        // Searching for a book by title
        library.search_Book("1984");

        // Creating an instance of a user
        User user = new User("Bob", 25, 2);

        // Issuing a book to a user
        librarian.issue_Book(book1, user);

        // Listing all issued books
        library.list_issued_books();

        // Returning a book from a user
        librarian.return_Book(book1, user);

        // Listing all issued books after returning
        library.list_issued_books();
    }
}

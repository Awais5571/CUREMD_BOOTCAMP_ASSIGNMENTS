using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int BookID { get; set; }

    public Book(string title, string author, int bookID)
    {
        Title = title;
        Author = author;
        BookID = bookID;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Book ID: {BookID}, Title: {Title}, Author: {Author}");
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

class Library
{
    public string LibraryName { get; set; }
    public int LibraryID { get; set; }
    private List<Book> books;

    public Library(string libraryName, int libraryID)
    {
        LibraryName = libraryName;
        LibraryID = libraryID;
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book: "+book.Title+ " is added to the library.");
    }

    public void RemoveBook(int bookID)
    {
        Book bookToRemove = books.Find(b => b.BookID == bookID);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("Book ID :"+bookID+" is removed from the library.");
        }
        else
        {
            Console.WriteLine("Book ID:"+bookID+"  is not found in the library.");
        }
    }

    public void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books have been found  in the library.");
        }
        else
        {
            Console.WriteLine("These are the Books in the library:");
            foreach (Book book in books)
            {
                book.DisplayInfo();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of Book
        Book book1 = new Book("1984", "George Orwell", 1);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 2);
        Book book3 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 3);

        // Creating an instance of Library
        Library library = new Library("City Library", 101);

        // Adding books to the library
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        // Viewing books in the library
        library.ViewBooks();

        // Removing a book from the library
        library.RemoveBook(2);

        // Viewing books in the library after removal
        library.ViewBooks();
    }
}

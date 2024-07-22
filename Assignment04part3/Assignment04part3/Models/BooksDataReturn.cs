namespace Assignment04part3.Models
{
    public class BooksDataReturn
    {
        private static List<OnlineBookStore> Books = new List<OnlineBookStore>()
            {
                new OnlineBookStore {Id=1,Title="Harry Potter",Author="A", Description ="Fiction" },
                new OnlineBookStore {Id=2,Title="Kite Runner",Author="B", Description ="Fiction" },
                new OnlineBookStore {Id=3,Title="Invicible Men",Author="C", Description ="Fiction" },
                new OnlineBookStore {Id=4,Title="40 Rules of Love",Author="D", Description ="Fiction" }
            };

        public List<OnlineBookStore> GetAllData() {
            return Books;
        }

        public OnlineBookStore GetDataById(int id)
        {

            return Books.Find(b => b.Id == id);
        }

        public void AddBooks(OnlineBookStore newbook)
        {

            Books.Add(newbook);
        }

        public void UpdateBooks(int id,string updateTitle,string updateAuthor,string updateDescription) {
            var a = Books.Find(b => b.Id == id);
            if (a != null)
            {
                a.Title=updateTitle;
                a.Author=updateAuthor;  
                a.Description=updateDescription;
            }

        }

        public void DeleteDataById(int id)
        {

            var b = Books.Find(b => b.Id == id);
            if (b != null) {
                Books.Remove(b);
            
            }

        }

        public OnlineBookStore GetDataByAuthor(string author)
        {

            return Books.Find(b => b.Author == author);
        }


    }
}

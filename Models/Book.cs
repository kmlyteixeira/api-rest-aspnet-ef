using System.Linq;
using System.Collections.Generic;
using Database;

namespace Models
{
    public class Book
    {
      public int Id { get; set; }
      public string name { get; set; }
      public string author { get; set; }
      public string publisher { get; set; }
      public string genre { get; set; }
      public int pages { get; set; }
      public int year { get; set; }

      public Book() {}

      public Book(string name, string author, string publisher, string genre, int pages, int year)
      {
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.genre = genre;
        this.pages = pages;
        this.year = year;

        Context db = new Context();
        db.Books.Add(this);
        db.SaveChanges();
      }
    }
}
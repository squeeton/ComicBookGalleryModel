using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                context.Database.Log = (message) => Debug.WriteLine(message);


                //var comicBooks = context.ComicBooks.ToList();
                var comicBooksQuery = from cb in context.ComicBooks select cb;
                var comicBooks = comicBooksQuery.ToList();
                Console.WriteLine("# of comic books: {0}", comicBooks.Count);

                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a=>a.Artist))
                //    .Include(cb=>cb.Artists.Select(a=>a.Role))
                //    .ToList();

                //foreach (var c in comicBooks)
                //{
                //    var artistRoleNames = c.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}")
                //        .ToList();
                //    var artistRoleDisplayText = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(c.DisplayText);
                //    Console.WriteLine(artistRoleDisplayText);
                //}
                Console.ReadLine();
            }
            
        }
    }
}

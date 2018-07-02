﻿using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series1 = new Series()
                {
                    Title = "The Amazing Spinder-Man"
                };

                var series2 = new Series()
                {
                    Title = "The Invincible Iron Man"
                };

                var artist1 = new Artist()
                {
                    Name = "Stan Lee"
                };

                var artist2 = new Artist()
                {
                    Name = "Steve Ditko"
                };

                var artist3= new Artist()
                {
                    Name = "Jack Kirby"
                };
                var comicBook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook1.Artists.Add(artist1);
                comicBook1.Artists.Add(artist2);

                var comicBook2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };
                comicBook2.Artists.Add(artist1);
                comicBook2.Artists.Add(artist2);

                var comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook3.Artists.Add(artist1);
                comicBook3.Artists.Add(artist3);

                context.ComicBooks.Add(comicBook1);
                context.ComicBooks.Add(comicBook2);
                context.ComicBooks.Add(comicBook3);
                context.SaveChanges();


                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists)
                    .ToList();

                foreach (var c in comicBooks)
                {
                    var artistNames = c.Artists.Select(a => a.Name).ToList();
                    var artistDisplayText = string.Join(", ", artistNames);

                    Console.WriteLine(c.DisplayText);
                    Console.WriteLine(artistDisplayText);
                }
                Console.ReadLine();
            }
            
        }
    }
}

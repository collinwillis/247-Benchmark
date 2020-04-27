using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benchmark.Models
{
    public class Verse
    {
        public string Testament { get; set; }
        public string Book { get; set; }

        public int Chapter { get; set; }

        public int VerseNumber { get; set; }

        public string VerseText { get; set; }

        public Verse()
        {
            this.Testament = "";
            this.Book = "";
            this.Chapter = 0;
            this.VerseNumber = 0;
            this.VerseText = "";
        }

        public Verse(string testament, string book, int chapter, int verseNumber, string verseText)
        {
            VerseText = verseText;
            Book = book;
            Chapter = chapter;
            VerseNumber = verseNumber;
        }
    }
}
﻿using Library.Data.Model;

namespace Library.Models
{
    public class AllBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }
        
        public string Author { get; set; }
        
        public decimal Rating { get; set; }

        public string Category { get; set; }
    }
}

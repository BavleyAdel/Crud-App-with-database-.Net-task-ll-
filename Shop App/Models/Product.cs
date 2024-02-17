﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Shop_App.Models
{
    public class Product
    {
        [key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }    
        public int Quantity { get; set; }
        public bool EnableSize { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public Company Company { get; set; }

    }
}
﻿using Microsoft.AspNetCore.Http;
using System;

namespace WebAPI.Requests
{
    public class ProductRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public int inventory { get; set; }
        public DateTime DoM { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal price { get; set; }
        public bool active { get; set; } = true;
        public IFormFile file { get; set; }
    }
}

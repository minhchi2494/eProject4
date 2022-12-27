using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace BlazorApp.Services.Request
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Id is required")]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Id must contains from 2 to 5 characters!")]
        public string id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Product Name must contains from 2 to 30 characters!")]
        public string name { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Amount invalid (1-1000).")]
        public decimal price { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Amount invalid (1-1000).")]
        public int inventory { get; set; }
        [Required(ErrorMessage = "Unit is required")]
        public string unit { get; set; }
        [Range(typeof(DateTime), "1/1/2020", "12/31/2022")]
        public DateTime DoM { get; set; } = DateTime.Now;
        [Range(typeof(DateTime), "1/1/2023", "1/1/2050")]
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public bool? active { get; set; }=false;
        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }
        [Required(ErrorMessage = "Images is required")]
        public MultipartFormDataContent file { get; set; }
    }
}

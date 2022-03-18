using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorApp.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Images { get; set; }
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

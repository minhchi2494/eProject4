using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Keyless]
    [Table("vStoreSalesDetailStoreUser")]
    public class vStoreSalesDetailStoreUser
    {
        public DateTime Date { get; set; }
        public int? StoreActualQuantity { get; set; }

        //Store name
        public string Store { get; set; }

        //User
        public string Fullname { get; set; }

        //Product
        public string Product { get; set; }
    }
}

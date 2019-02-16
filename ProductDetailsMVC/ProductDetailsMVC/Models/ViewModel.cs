using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetailsMVC.Models
{
    public class ViewModel
    {
        public IEnumerable<ProductDetails> Products { get; set; }
        public IEnumerable<Supplierinfo> Suppliers { get; set; }
    } 
}
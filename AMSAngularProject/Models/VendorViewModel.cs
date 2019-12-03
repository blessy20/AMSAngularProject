using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMSAngularProject.Models
{
    public class VendorViewModel
    {
        public int vendorId { get; set; }
        public string vendorName { get; set; }
        public string vendorType { get; set; }
        public string vendorAssetType { get; set; }
        public string validFromstr { get; set; }
        public string vaildTostr { get; set; }
        public string vendorAddress { get; set; }
    }
  
}
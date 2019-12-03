using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMSAngularProject.Models
{
    public class PurchaseViewModel
    {
        public int purchaseId { get; set; }
        public string purchaseOrderNo { get; set; }
        public Nullable<int> purchaseAssetName { get; set; }
        public Nullable<int> purchaseAssetType { get; set; }
        public Nullable<int> purchaseVendorName { get; set; }
        public string purchaseAssetNamestr { get; set; }
        public string purchaseAssetTypestr { get; set; }
        public string purchaseVendorNamestr { get; set; }
        public decimal quantity { get; set; }
        public string vendorName { get; set; }
        public string purchaseDatestr { get; set; }
        public string purchaseDelivDatestr { get; set; }
        public string purchaseStatus { get; set; }
       
    }
}
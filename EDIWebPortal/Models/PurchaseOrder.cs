using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDIWebPortal.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public string PurchaseOrderOwner { get; set; }

        public string PONumber { get; set; }

        public string Subject { get; set; }

        public string VendorName { get; set; }

        public string RequisitionNo { get; set; }

        public string TrackingNumber { get; set; }

        public string ContactName { get; set; }

        public string Carrier { get; set; }

        public DateTime PurchaseOrderDate { get; set; }

        public TimeSpan PurchaseOrderTime { get; set; }

        public DateTime DueDate { get; set; }

        public string ExciseDuty { get; set; }

        public decimal SalesCommission { get; set; }

        public string Status { get; set; }

        public string AssignedTo { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string BillingAddressStreet { get; set; }

        public string BillingAddressCity { get; set; }

        public string BillingAddressState { get; set; }

        public string BillingAddressZip { get; set; }

        public string BillingAddressCountry { get; set; }

        public string ShippingAddressStreet { get; set; }

        public string ShippingAddressCity { get; set; }

        public string ShippingAddressState { get; set; }

        public string ShippingAddressZip { get; set; }

        public string ShippingAddressCountry { get; set; }

        public string ProductName { get; set; }

        public int QuantityInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal ListPrice { get; set; }

        public decimal UPC { get; set; }

        public decimal GTIN { get; set; }

        public decimal Total { get; set; }

        public string TermsAndConditions { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

    }
}

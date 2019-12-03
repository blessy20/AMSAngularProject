using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AMSAngularProject.Models;

namespace AMSAngularProject.Controllers
{
    public class OrderController : ApiController
    {
        private AMSAngularEntities2 db = new AMSAngularEntities2();
        public OrderController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<PurchaseViewModel> GettblPurchases()
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<tblPurchase> purchaselist = db.tblPurchases.Where(x=>x.purchaseStatus=="Asset Details Registered Internally").ToList();
            List<PurchaseViewModel> viewlist = purchaselist.Select(x => new PurchaseViewModel

            {
                purchaseId = x.purchaseId,
                purchaseOrderNo = x.purchaseOrderNo,
                // purchaseAssetName = x.purchaseAssetName,
                purchaseAssetNamestr = x.tblAssetDefinition.assetName,
                //purchaseAssetType = x.purchaseAssetType,
                purchaseAssetTypestr = x.tblAssetType.assetTypeName,
                quantity = Convert.ToDecimal(x.quantity),
                //purchaseVendorName = x.purchaseVendorName,
                purchaseVendorNamestr = x.tblVendor.vendorName,
                purchaseDatestr = x.purchaseDatestr,
                purchaseDelivDatestr = x.purchaseDelivDatestr,
                purchaseStatus = x.purchaseStatus
            }).ToList();
            return viewlist;
        }

        // GET: api/Order/5
        [ResponseType(typeof(tblPurchase))]
        public PurchaseViewModel GettblPurchases(string ordno)
        {
            db.Configuration.ProxyCreationEnabled = true;
            tblPurchase porder = db.tblPurchases.Where(x => x.purchaseOrderNo == ordno).FirstOrDefault();
            PurchaseViewModel pmodel = new PurchaseViewModel();
            if (porder == null)
            {
               
            }
            else
            {
                pmodel.purchaseId = porder.purchaseId;
                pmodel.purchaseOrderNo = porder.purchaseOrderNo;
                pmodel.purchaseAssetName = porder.purchaseAssetName;
                pmodel.purchaseAssetNamestr = porder.tblAssetDefinition.assetName;
                pmodel.purchaseAssetType = porder.purchaseAssetType;
                pmodel.purchaseAssetTypestr = porder.tblAssetType.assetTypeName;
                pmodel.quantity = Convert.ToDecimal(porder.quantity);
                pmodel.purchaseVendorName = porder.purchaseVendorName;
                pmodel.purchaseVendorNamestr = porder.tblVendor.vendorName;
                pmodel.purchaseDatestr = porder.purchaseDatestr;
                pmodel.purchaseDelivDatestr = porder.purchaseDelivDatestr;
                pmodel.purchaseStatus = porder.purchaseStatus;
                
            }

            return pmodel;
        }

        // PUT: api/Order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblPurchase(int id, tblPurchase tblPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPurchase.purchaseId)
            {
                return BadRequest();
            }

            db.Entry(tblPurchase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblPurchaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Order
        [ResponseType(typeof(tblPurchase))]
        public IHttpActionResult PosttblPurchase(tblPurchase tblPurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblPurchases.Add(tblPurchase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPurchase.purchaseId }, tblPurchase);
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(tblPurchase))]
        public IHttpActionResult DeletetblPurchase(int id)
        {
            tblPurchase tblPurchase = db.tblPurchases.Find(id);
            if (tblPurchase == null)
            {
                return NotFound();
            }

            db.tblPurchases.Remove(tblPurchase);
            db.SaveChanges();

            return Ok(tblPurchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblPurchaseExists(int id)
        {
            return db.tblPurchases.Count(e => e.purchaseId == id) > 0;
        }
    }
}
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
    public class PurchasesController : ApiController
    {
        private AMSAngularEntities2 db = new AMSAngularEntities2();
        public PurchasesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<PurchaseViewModel> GettblPurchases()
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<tblPurchase> purchaselist = db.tblPurchases.ToList();
            List<PurchaseViewModel> viewlist = purchaselist.Select(x => new PurchaseViewModel

            {
                purchaseId = x.purchaseId,
                purchaseOrderNo = x.purchaseOrderNo,
               // purchaseAssetName = x.purchaseAssetName,
                purchaseAssetNamestr = x.tblAssetDefinition.assetName,
                //purchaseAssetType = x.purchaseAssetType,
                purchaseAssetTypestr=x.tblAssetType.assetTypeName,
                quantity = Convert.ToDecimal(x.quantity),
                //purchaseVendorName = x.purchaseVendorName,
                purchaseVendorNamestr=x.tblVendor.vendorName,
                purchaseDatestr = x.purchaseDatestr,
                purchaseDelivDatestr=x.purchaseDelivDatestr,
                purchaseStatus=x.purchaseStatus
            }).ToList();
            return viewlist;
        }
        public List<VendorViewModel> GettblPurchase(int id)
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<tblVendor> vendor = db.tblVendors.Where(x => x.vendorAssetType == id).ToList();
            List<VendorViewModel> vendorlist = vendor.Select(x => new VendorViewModel
            {
                vendorId = Convert.ToInt32(x.vendorId),
                vendorName = x.vendorName,
                vendorType = x.vendorType,
                vendorAssetType = x.tblAssetType.assetTypeName,
                validFromstr = x.validFromstr,
                vaildTostr = x.validTostr,
                vendorAddress = x.vendorAddress
            }).ToList();
            return vendorlist;
        }

        public List<tblAssetType> GetTblAssetTypes(string name)
        {
            db.Configuration.ProxyCreationEnabled = true;
            tblAssetDefinition assetdef = db.tblAssetDefinitions.Where(x => x.assetName == name).FirstOrDefault();
            List<tblAssetType> typelist = db.tblAssetTypes.Where(x => x.assetTypeId == assetdef.assetType).ToList();
            return typelist;
        }
        public PurchaseViewModel GetPurchase(int pid)
        {
            db.Configuration.ProxyCreationEnabled = true;
            tblPurchase porder = db.tblPurchases.Where(x => x.purchaseId == pid).FirstOrDefault();
            PurchaseViewModel pmodel = new PurchaseViewModel();
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
            return pmodel;
        }
        // PUT: api/Purchases/5
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

        // POST: api/Purchases
        [ResponseType(typeof(tblPurchase))]
        public IHttpActionResult PosttblPurchase(tblPurchase tblPurchase)
        {
           
            tblPurchase.purchaseDate = DateTime.Now;
            db.tblPurchases.Add(tblPurchase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblPurchase.purchaseId }, tblPurchase);
        }

        // DELETE: api/Purchases/5
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
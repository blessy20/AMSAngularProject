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
    public class VendorsController : ApiController
    {
        private AMSAngularEntities2 db = new AMSAngularEntities2();
        public VendorsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<VendorViewModel> GettblVendors()
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<tblVendor> vendorlist = db.tblVendors.ToList();
            List<VendorViewModel> viewlist = vendorlist.Select(x => new VendorViewModel

            {
                vendorId = Convert.ToInt32(x.vendorId),
                vendorName = x.vendorName,
                vendorType =x.vendorType,
                vendorAssetType= x.tblAssetType.assetTypeName,
                validFromstr=x.validFromstr,
                vaildTostr=x.validTostr,
                vendorAddress=x.vendorAddress
            }).ToList();
            return viewlist;
        }

        // GET: api/Vendors/5
        [ResponseType(typeof(tblVendor))]
        public IHttpActionResult GettblVendor(int id)
        {
            tblVendor tblVendor = db.tblVendors.Find(id);
            if (tblVendor == null)
            {
                return NotFound();
            }

            return Ok(tblVendor);
        }
        //search by vendor name
        public List<tblVendor> GettblVendors(string name)
        {
            List<tblVendor> vlist = db.tblVendors.Where(x => x.vendorName.StartsWith(name)).ToList();
            return vlist;

        }
        // PUT: api/Vendors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblVendor(int id, tblVendor tblVendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblVendor.vendorId)
            {
                return BadRequest();
            }

            db.Entry(tblVendor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblVendorExists(id))
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

        // POST: api/Vendors
        [ResponseType(typeof(tblVendor))]
        public int PosttblVendor(tblVendor tblVendor)
        {
            tblVendor vendor = new tblVendor();
            vendor = db.tblVendors.Where(x => x.vendorName ==tblVendor.vendorName && x.vendorAssetType==tblVendor.vendorAssetType).FirstOrDefault();
            if (vendor == null)
            {
                db.tblVendors.Add(tblVendor);
                db.SaveChanges();
                return 0;

            }
            else
            {
                return 1;
            }
        }

        // DELETE: api/Vendors/5
        [ResponseType(typeof(tblVendor))]
        public IHttpActionResult DeletetblVendor(int id)
        {
            tblVendor tblVendor = db.tblVendors.Find(id);
            if (tblVendor == null)
            {
                return NotFound();
            }

            db.tblVendors.Remove(tblVendor);
            db.SaveChanges();

            return Ok(tblVendor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblVendorExists(int id)
        {
            return db.tblVendors.Count(e => e.vendorId == id) > 0;
        }
    }
}
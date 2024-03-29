﻿using System;
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
    public class AssetDefinitionsController : ApiController
    {
        private AMSAngularEntities2 db = new AMSAngularEntities2();

        public AssetDefinitionsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<AssetDefinitionViewModel> GettblAssetDefinitions()
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<tblAssetDefinition> assetlist = db.tblAssetDefinitions.ToList();
            List<AssetDefinitionViewModel> assetviewlist = assetlist.Select(x => new AssetDefinitionViewModel

            {
                assetId = Convert.ToInt32(x.assetId),
                assetName = x.assetName,
                assetType = x.tblAssetType.assetTypeName,
                assetClass = x.assetClass
            }).ToList();
            return assetviewlist;
        }

        // GET: api/AssetDefinitions/5
        [ResponseType(typeof(tblAssetDefinition))]
        public IHttpActionResult GettblAssetDefinition(int id)
        {
            tblAssetDefinition tblAssetDefinition = db.tblAssetDefinitions.Find(id);
            if (tblAssetDefinition == null)
            {
                return NotFound();
            }

            return Ok(tblAssetDefinition);
        }

        //GET:search by name
        public List<tblAssetDefinition> GettblAssetDefinitions(string name)
        {
            List<tblAssetDefinition> assetlist = db.tblAssetDefinitions.Where(x => x.assetName.StartsWith(name)).ToList();
            return assetlist;

        }

        // PUT: api/AssetDefinitions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAssetDefinition(int id, tblAssetDefinition tblAssetDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAssetDefinition.assetId)
            {
                return BadRequest();
            }

            db.Entry(tblAssetDefinition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAssetDefinitionExists(id))
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

        // POST: api/AssetDefinitions
        [ResponseType(typeof(tblAssetDefinition))]
        public int PosttblAssetDefinition(tblAssetDefinition tblAssetDefinition)
        {
           
            tblAssetDefinition asset = new tblAssetDefinition();
                asset = db.tblAssetDefinitions.Where(x => x.assetName == tblAssetDefinition.assetName && x.assetType == tblAssetDefinition.assetType && x.assetClass ==tblAssetDefinition.assetClass).FirstOrDefault();
                if (asset == null)
                {

                    db.tblAssetDefinitions.Add(tblAssetDefinition);
                    db.SaveChanges();
                    return 0;

                }
                else
                {
                    return 1;
                }
            }

        

        // DELETE: api/AssetDefinitions/5
        [ResponseType(typeof(tblAssetDefinition))]
        public IHttpActionResult DeletetblAssetDefinition(int id)
        {
            tblAssetDefinition tblAssetDefinition = db.tblAssetDefinitions.Find(id);
            if (tblAssetDefinition == null)
            {
                return NotFound();
            }

            db.tblAssetDefinitions.Remove(tblAssetDefinition);
            db.SaveChanges();

            return Ok(tblAssetDefinition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAssetDefinitionExists(int id)
        {
            return db.tblAssetDefinitions.Count(e => e.assetId == id) > 0;
        }
    }
}
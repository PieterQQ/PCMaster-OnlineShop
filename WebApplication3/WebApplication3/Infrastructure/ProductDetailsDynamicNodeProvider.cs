using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider :DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach (Podzespol p in db.Podzespol)
            {
              
                DynamicNode n = new DynamicNode();
                n.Title = p.NazwaPodzespolu;
                n.Key = "Podzespol_" + p.PodzespolId;
                n.ParentKey = "Podzespoly_" + p.PodzespolyId;
                n.RouteValues.Add("id", p.PodzespolId);
                returnValue.Add(n);

            }
            return returnValue;
        }
    }
}
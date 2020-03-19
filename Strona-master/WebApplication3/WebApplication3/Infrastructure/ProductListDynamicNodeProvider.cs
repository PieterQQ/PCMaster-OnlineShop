using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Infrastructure
{
    public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            foreach (podzespoly p in db.Podzespoly)
            {

                DynamicNode n = new DynamicNode();
                n.Title = p.Name;
                n.Key = "Podzespoly_" + p.PodzespolyId;
                n.RouteValues.Add("genrename", p.Name);
                returnValue.Add(n);

            }
            return returnValue;
        }
    }
}
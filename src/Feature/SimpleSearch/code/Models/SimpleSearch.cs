using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;

namespace ClothingCompany.Feature.SimpleSearch.Models
{
    public class SimpleSearch
    {
        public SitecoreIndexableItem ParentItem { get; set; }

        public IEnumerable<CapsuleWardrobeItem> CapsuleWardrobeItems { get; set; }
    }
}
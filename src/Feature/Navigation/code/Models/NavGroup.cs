using System.Collections.Generic;
using Sitecore.Data.Items;

namespace ClothingCompany.Feature.Navigation.Models
{
    public class NavGroup
    {
        public Item RootItem { get; set; }

        public string RootUrl { get; set; }

        public IEnumerable<NavItem> NavItems { get; set; }
    }
}
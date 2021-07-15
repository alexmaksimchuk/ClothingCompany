using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Feature.Navigation.Models;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ClothingCompany.Feature.Navigation.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Header()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            var navigation = new NavGroup
            {
                RootItem = homeItem,
                RootUrl = LinkManager.GetItemUrl(homeItem),
                NavItems = GetNavItems(homeItem)
            };

            return View(navigation);
        }

        public ActionResult Footer()
        {
            var resources = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Resources");

            var resourcesLinks = new NavGroup
            {
                RootItem = resources,
                RootUrl = LinkManager.GetItemUrl(resources),
                NavItems = GetNavItems(resources)
            };

            return View(resourcesLinks);
        }

        private IEnumerable<NavItem> GetNavItems(Item navRoot)
        {
            var items = new List<Item> { navRoot };
            items.AddRange(navRoot.Children.Where(item => item.DescendsFrom(new Sitecore.Data.ID("{06EEF10F-DF02-4DAF-B4C2-D17B22F08A40}"))));

            var navItems = items.Select(item => new NavItem
            {
                Item = item,
                Url = LinkManager.GetItemUrl(item)
            }).ToList();

            return navItems;
        }
    }
}
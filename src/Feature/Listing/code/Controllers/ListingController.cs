using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Feature.Listing.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;

namespace ClothingCompany.Feature.Listing.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var pageList = new Models.Listing();

            if (dataSourceId != null)
            {
                var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);

                if (dataSource != null)
                {
                    var listOfArticles = dataSource.Children;

                    pageList.Posts = listOfArticles.Select(item => new NavItem
                    {
                        Item = item,
                        Url = LinkManager.GetItemUrl(item)
                    }).ToList();
                }
            }

            return View(pageList);
        }
    }
}
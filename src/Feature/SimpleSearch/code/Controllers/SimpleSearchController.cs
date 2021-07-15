using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingCompany.Feature.SimpleSearch.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Search;


namespace ClothingCompany.Feature.SimpleSearch.Controllers
{
    public class SimpleSearchController : Controller
    {
        // GET: SimpleSearch
        public ActionResult Index()
        {
            var searchList = new Models.SimpleSearch();
            var capsuleWardrobeId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            if (capsuleWardrobeId != null)
            {
                var capsuleWardrobeItem = Sitecore.Context.Database.GetItem(capsuleWardrobeId);

                if (capsuleWardrobeItem != null)
                {
                    var index = ContentSearchManager.GetIndex("sitecore_master_index");

                    using (var searchContext = index.CreateSearchContext())
                    {
                        var searchResult = searchContext
                            .GetQueryable<SearchResultItem>()
                            .Where(s => s["Page Title"].Contains("2020"))
                            .ToList()
                            .Select(item => item.GetItem())
                            .ToList();

                        searchList.CapsuleWardrobeItems = searchResult.Select(item => new CapsuleWardrobeItem
                        {
                            Item = item,
                            Url = LinkManager.GetItemUrl(item)
                        }).ToList();
                    }
                }
            }

            return View(searchList);
        }
    }
}
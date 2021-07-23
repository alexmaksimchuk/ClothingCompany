using System.Linq;
using System.Web.Mvc;
using ClothingCompany.Feature.Carousel.Models;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Query;
using Sitecore.Mvc.Presentation;

namespace ClothingCompany.Feature.Carousel.Controllers
{
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            var carouselDataViewModel = new CarouselDataViewModel();
            ChildList slideItems = null;

            var dataSourceItem = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Metadata/Carousel/Slides");

            if (dataSourceItem != null)
            {
                slideItems = dataSourceItem.GetChildren();
            }

            carouselDataViewModel.SlideItems = slideItems;

            return PartialView(carouselDataViewModel);
        }

        public ActionResult CompatibleRendering()
        {
            Item slide = null;

            var dataSourceItem = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Metadata/Carousel/Slides");

            if (dataSourceItem != null)
            {
                slide = dataSourceItem.Children.FirstOrDefault(item => item.DescendsFrom(new ID("{0E00829D-7F26-412E-8E7D-629761A71191}")));
            }

            return PartialView(slide);
        }
    }
}
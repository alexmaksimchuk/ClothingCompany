using System.Web.Mvc;
using ClothingCompany.Feature.Carousel.Models;
using Sitecore.Collections;
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
    }
}
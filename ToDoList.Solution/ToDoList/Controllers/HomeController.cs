using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet ("/")]
        public ActionResult Index () 
        {
            return View ();
        }

        [HttpGet ("/xmlTestRoute")]
        public ContentResult GetXml () 
        {
            string xmlString =
                "<NOTE><FROM>Trevor</FROM><TO>Pri</TO><MESSAGE>Yay! The xml works. Check the console for the #document</MESSAGE></NOTE>";
            return Content (xmlString, "text/xml");
        }
    }
}
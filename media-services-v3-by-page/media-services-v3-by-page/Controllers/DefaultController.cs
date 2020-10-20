using AzureMidia_v3;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace media_services_v3_by_page.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Processo(HttpPostedFileBase arquivo)
        {
            try
            {

                // Creating a unique suffix so that we don't have name collisions if you run the sample
                // multiple times without cleaning up.
                string uniqueness = Guid.NewGuid().ToString("N");

                var stream = arquivo.InputStream;
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                stream.Position = 0;

                _ = await Class1.CreateInputAssetAsyncStreaming(stream, arquivo.FileName, uniqueness);
                _ = await Class1.RunJobAsync(uniqueness);

            }
            catch (Exception ex)
            {
                //
            }

            return RedirectToAction("Index");
        }

    }
}
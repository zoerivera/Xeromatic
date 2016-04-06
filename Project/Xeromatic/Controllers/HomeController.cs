using System.Web.Mvc;
using Xeromatic.Services;

namespace Xeromatic.Controllers
{
    public class HomeController : Controller
    {
        private readonly TweetDbService _tweetDbService;
        private readonly TwitterApiService _twitterApiService;

        public HomeController()
        {
            _tweetDbService = new TweetDbService();
            _twitterApiService = new TwitterApiService();
        }

        // GET: /Home
        /// <summary>
        /// Returns the default page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Home/Data
        /// <summary>
        /// Returns the tweets from the database.
        /// </summary>
        /// <returns></returns>
        public ActionResult Data()
        {
            var tweets = _tweetDbService.GetTweets();
            return Json(tweets, JsonRequestBehavior.AllowGet);
        }
    }
}

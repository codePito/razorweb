using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Entity.Models;

namespace Razor_Entity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyBlogContext myBlogContext;

        public IndexModel(ILogger<IndexModel> logger, MyBlogContext _myContext)
        {
            _logger = logger;
            myBlogContext = _myContext;
        }

        public void OnGet()
        {
            var posts = (from p in myBlogContext.articles
                        orderby p.Created descending
                        select p).ToList();
            ViewData["posts"] = posts;
        }
    }
}
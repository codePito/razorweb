using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Entity.Models;

namespace Razor_Entity.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly Razor_Entity.Models.MyBlogContext _context;

        public IndexModel(Razor_Entity.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;
       
        public const int ITEM_PER_PAGE = 5;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }


        public async Task OnGetAsync(string SearchString)
        {
            int totalArticle = await _context.articles.CountAsync(); 

            countPages = (int)Math.Ceiling((double)totalArticle / ITEM_PER_PAGE);

            if(currentPage < 1)
                currentPage = 1;
            if(currentPage > countPages)
                currentPage = countPages;

            var qr = (from a in _context.articles
                     orderby a.Created descending
                     select a)
                     .Skip((currentPage - 1) * 5)
                     .Take(ITEM_PER_PAGE);
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = qr.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else{
                Article = await _context.articles.ToListAsync();
            }
        }
    }
}

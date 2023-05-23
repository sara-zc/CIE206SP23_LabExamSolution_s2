using LabExamPart2_sec2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace LabExamPart2_sec2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DB db { get; set; }
        [Required]
        [BindProperty]
        public string uname { get; set; }
        [BindProperty]
        public string? warning { get; set; }    //Note: you must make this nullable so not to mess up the ModelState.IsValid
        public IndexModel(ILogger<IndexModel> logger, DB mydb)
        {
            _logger = logger;
            db = mydb;
        }

        public void OnGet(string warning)
        {
            this.warning = warning;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (db.findStudent(uname))
                {
                    return RedirectToPage("/Welcome", new { uname = uname });
                }
                else
                {
                    warning = "Username not found!";
                    return RedirectToPage("/Index", new { warning = warning });
                }
            }
            else
            {
                // catch and display validation error messages
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                Console.WriteLine(message);
                return Page();
            }
        }
    }
}
using LabExamPart2_sec2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LabExamPart2_sec2.Pages
{
    public class WelcomeModel : PageModel
    {
        public DB db { get; set; }
        public string uname { get; set; }
        [BindProperty] 
        public string name { get; set; }
        [BindProperty]
        public List<Course> courses { get; set; }
        public WelcomeModel(DB mydb)
        {
            db = mydb;
        }
        public void OnGet(string uname)
        {
            name = db.getStudentName(uname);
            courses = db.getCourses(uname);

        }
    }
}

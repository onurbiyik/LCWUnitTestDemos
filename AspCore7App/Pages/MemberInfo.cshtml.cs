using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspCore7App.Pages
{
    [Authorize()]
    public class MemberInfoModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

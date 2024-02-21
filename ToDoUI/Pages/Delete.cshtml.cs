using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoShared;

namespace ToDoUI.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public IActionResult OnGet(int id)
        {
            Console.WriteLine(id);
            Id = id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await APIControl.DeleteToDoAsync(Id);
            return RedirectToPage("./index");
        }
    }
}

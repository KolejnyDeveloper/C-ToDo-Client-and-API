using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoShared;

namespace ToDoUI.Pages
{
    public class ToDoAddModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public ToDoItem todoitem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            todoitem.TodoTime = DateTime.Now;
            await APIControl.CreateToDoAsync(todoitem);
            return RedirectToPage("./index");
        }
    }
}

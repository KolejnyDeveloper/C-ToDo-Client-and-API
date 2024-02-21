using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoShared;


namespace ToDoUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public List<ToDoItem> toDoItems { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public async Task OnGetAsync()
        {
            toDoItems = await APIControl.GetToDosAsync();
            Console.WriteLine(toDoItems.Count);

        }
    }
}

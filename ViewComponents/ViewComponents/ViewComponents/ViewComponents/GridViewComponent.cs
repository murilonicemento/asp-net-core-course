using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents;

// [ViewComponent]
public class GridViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
    {
        // PersonGridModel personGridModel = new PersonGridModel()
        // {
        //     GridTitle = "Persons List",
        //     Persons = new List<Person>()
        //     {
        //         new Person()
        //         {
        //             PersonName = "Flavinho do Pneu",
        //             JobTitle = "Gândula"
        //         },
        //         new Person()
        //         {
        //             PersonName = "Zé Gatinha",
        //             JobTitle = "Pedreiro"
        //         },
        //         new Person()
        //         {
        //             PersonName = "Pitbull do Samba",
        //             JobTitle = "Comentarista"
        //         }
        //     }
        // };

        // ViewData["Grid"] = personGridModel;
        return View(grid); // invoca uma partial view -> Shared/Components/Grid/Default.cshtml
    }
}
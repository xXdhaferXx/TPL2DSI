using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class page2 : PageModel
    {

        
        // Liste statique pour stocker les noms
        public static List<string> SharedNames = new List<string>();
        public static List<string> SharedSpecialties = new List<string>();
        public static List<string> SharedSubjects = new List<string>();
        public List<string> NamesToShow => SharedNames;  // Propriété pour accéder aux noms
        public List<string> SpecialtiesToShow => SharedSpecialties;
        public List<string> SubjectsToShow => SharedSubjects;


        public void OnGet()
        {
            // Vous pouvez ajouter d'autres logiques ici si nécessaire
        }


    }
}

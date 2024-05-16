using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {

        //private readonly ILogger<IndexModel> _logger;

        
        public static List<string> Names { get; set; } = new List<string>();
        public string nom;
        public string prenom;
        public string action;
        public bool test;
        public Dictionary<string, List<string>> spécialitéMat = new Dictionary<string, List<string>>
        {
            {"option1",new List<string> { "java", "c#", "php" } },
            {"option2",new List<string>{ "electrique", "mecanique", "systeme " }  }
        };
        public Dictionary<string, string> spécialité = new Dictionary<string, string>
        {
            {"option1","info" },
            {"option2","mecanique" },
        };

        public List<string> slectSpecialite { get; set; } = new List<string>();
        public string SelectedName { get; set; }

        public void OnGet()
        {


        }


        public string Message { get; set; }
        


        
            public void OnPost(string Prenom, string Nom)
        {
            string speSlected = Request.Form["option"];
            string Matselc = Request.Form["selSpecialite"];
            if (Request.Form["action"] == "ajouter")
            {
                Names.Add(Nom + " " + Prenom);
                
            }
            
            else if (Request.Form["action"] == "afficher")
            {
                Message = $"Bonjour {Nom} {Prenom}";
            }

            nom = Request.Form["nom"];
            prenom = Request.Form["prenom"];


            
            slectSpecialite.Clear();
            SelectedName = speSlected;

            if (Request.Form["action2"] == "afficher")
            {
                if (!string.IsNullOrEmpty(SelectedName))
                {
                    test = true;

                }
                else
                {
                    test = false;

                }
            }
            
            if (Request.Form["action3"] == "affichervers")
            {
                OnPostAddSpecialty(Matselc);
                OnPostAddSubject(speSlected);

                // Redirection vers Page2
                Response.Redirect("/Page2");
            }

        }

        private IActionResult OnPostAddName(string nom,string prenom)
        {
            if (!string.IsNullOrEmpty(nom))
            {
                page2.SharedNames.Add(nom + " " + prenom);  // Ajout d'un nom à la liste partagée
                return RedirectToPage("/Page2");
            }
            else
            {
                // Gérer le cas où le nom est vide
                ModelState.AddModelError("", "Le nom ne peut pas être vide.");
                return Page();
            }
        }

        public IActionResult OnPostAddSpecialty(string Matselc)
        {
            if (!string.IsNullOrEmpty(Matselc))
            {
                page2.SharedSpecialties.Add(Matselc);
                return RedirectToPage("/Page2");
            }
            ModelState.AddModelError("", "La spécialité ne peut pas être vide.");
            return Page();
        }

        public IActionResult OnPostAddSubject(string speSlected)
        {
            if (!string.IsNullOrEmpty(speSlected))
            {
                page2.SharedSubjects.Add(speSlected);
                return RedirectToPage("/Page2");
            }
            ModelState.AddModelError("", "La matière ne peut pas être vide.");
            return Page();
        }




    }

}



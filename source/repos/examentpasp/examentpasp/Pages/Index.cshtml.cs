using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace examentpasp.Pages
{
    public class IndexModel : PageModel
    {

        private int nombreAleatoire;
        private int nbTentativesRestantes = 5;
        private string nomJoueur;
        private int score;
        public static List<string> Names { get; set; } = new List<string>();

        public void OnGet()
        {
            nombreAleatoire = new Random().Next(0, 101);
            ViewData["resultat"] = "";
            nbTentativesRestantes = 5;
            nomJoueur = "";
            score = 0;
            
        }

        public void OnPost(string Nom)
        {
            if (Request.Form["action"] == "ajouter")
            {
                Names.Add(Nom + " " + score);

            }
            if (Request.Form["action"] == "score")
            {
                

            }

            if (Request.Form["action"] == "Nouveau")
            {
                // Générer un nouveau nombre aléatoire et réinitialiser le jeu
                nombreAleatoire = new Random().Next(0, 101);
                ViewData["nombreAleatoire"] = nombreAleatoire.ToString();

                nbTentativesRestantes = 5;
                score = 0;
                ViewData["resultat"] = "";
            }

            if (Request.Form["action"] == "Jouer")
            {
                int nb = int.Parse(Request.Form["nb"]);
                if (nb == nombreAleatoire)
                {

                    nbTentativesRestantes--;
                    score = (5 - nbTentativesRestantes + 1) * 10;

                    ViewData["resultat"] = "Félicitations, vous avez trouvé le nombre en    tentatives !";

                    if (nbTentativesRestantes > 0)
                    {
                        ViewData["resultat"] += "\n\nSaisissez votre nom complet pour enregistrer votre score :";
                        ViewData["action"] = "EnregistrerScore";
                    }
                    else
                    {
                        // Réinitialiser les variables pour une nouvelle partie
                        nombreAleatoire = new Random().Next(0, 101);
                        nbTentativesRestantes = 5;
                        score = 0;
                    }
                }
                else
                {
                    ViewData["resultat"] = nb < nombreAleatoire ? "Trop petit !propose	un	autre	nombre" : "Trop grand !	propose	un	autre	nombre";

                    nbTentativesRestantes--;

                    if (nbTentativesRestantes == 0)
                    {
                        ViewData["resultat"] = "Vous avez perdu ! Le nombre était " + nombreAleatoire;
                    }
                }

            }
               
            
        }

        


    }
}

    

using tp2ASP.Models;

namespace tp2ASP.Data
{
    public class DbInitializer
    {
        public static void Initialize(tp2ASPContext context)
        {
            // Look for any students.
            if (context.tache.Any())
            {
                return;   // DB has been seeded
            }

            var Taches = new tache[]
            {
                new tache{TacheNom="tache5",TacheTermine="termine"},
                new tache{TacheNom="tache7",TacheTermine="nom termine"},
                new tache{TacheNom="tache17",TacheTermine="termine"},
                new tache{TacheNom="tache14",TacheTermine="nom termine"}
                };

            context.tache.AddRange(Taches);
            context.SaveChanges();
        }
    }
}

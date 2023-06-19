using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MatInfo.Model;

namespace MatInfo.Model
{
    public class ApplicationData
    {
        public ObservableCollection<Personnel> LesPersonnels { get; set; }
        public ObservableCollection<CategorieMateriel> LesCategories { get; set; }
        public ObservableCollection<Materiel> LesMateriaux { get; set; }
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }

        public ApplicationData()
        {
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();
            CategorieMateriel c = new CategorieMateriel();
            LesCategories = c.FindAll();
            Materiel m = new Materiel();
            LesMateriaux = m.FindAll();
            EstAttribue a = new EstAttribue();
            LesAttributions = a.FindAll();

            //liason materiel a categorie
            foreach (Materiel unMat in LesMateriaux.ToList())
            {
                unMat.UneCategorie = LesCategories.ToList().Find(c => c.IdCategorie == unMat.FK_IdCategorie);
            }

            foreach (CategorieMateriel unCat in LesCategories.ToList())
            {
                unCat.LesMateriaux = new ObservableCollection<Materiel>(LesMateriaux.ToList().FindAll(m => m.FK_IdCategorie == unCat.IdCategorie));
            }

            // liason attribue a materiel
            foreach (EstAttribue unAtri in LesAttributions.ToList())
            {
                unAtri.UnMateriel = LesMateriaux.ToList().Find(m => m.IdMateriel == unAtri.FK_IdMateriel);
            }

            foreach (Materiel unMat in LesMateriaux.ToList())
            {
                unMat.LesAttributions = new ObservableCollection<EstAttribue>(LesAttributions.ToList().FindAll(a => a.FK_IdMateriel == unMat.IdMateriel));
            }

            // liason attribue a personnel
            foreach (EstAttribue unAtri in LesAttributions.ToList())
            {
                unAtri.UnPersonnel = LesPersonnels.ToList().Find(p => p.IdPersonnel == unAtri.FK_IdPersonnel);
            }

            foreach (Personnel unPerso in LesPersonnels.ToList())
            {
                unPerso.LesAttributions = new ObservableCollection<EstAttribue>(LesAttributions.ToList().FindAll(a => a.FK_IdPersonnel == unPerso.IdPersonnel));
            }


        }
    }
}

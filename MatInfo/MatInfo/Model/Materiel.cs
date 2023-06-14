using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatInfo.Model
{
    public class Materiel : Crud<Materiel>
    {
        public Materiel(int idMateriel, int fK_IdCategorie, string nomMateriel, string referenceConstructeur, string codeBarreInventaire)
        {
            IdMateriel = idMateriel;
            FK_IdCategorie = fK_IdCategorie;
            NomMateriel = nomMateriel;
            ReferenceConstructeur = referenceConstructeur;
            CodeBarreInventaire = codeBarreInventaire;
        }

        public Materiel()
        {

        }
        public int IdMateriel { get; set; }
        public int FK_IdCategorie { get; set; }
        public String NomMateriel { get; set; }
        public String ReferenceConstructeur { get; set; }
        public String CodeBarreInventaire { get; set; }
        public CategorieMateriel UneCategorie { get; set; }
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriaux = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idmateriel, idcategorie, nommateriel, referenceconstructeurmateriel, codebarreinventaire from materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel e = new Materiel(int.Parse(row["idmateriel"].ToString()), int.Parse(row["idcategorie"].ToString()), (String)row["nommateriel"], (String)row["referenceconstructeurmateriel"], (String)row["codebarreinventaire"]);
                    lesMateriaux.Add(e);
                }
            }
            return lesMateriaux;
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

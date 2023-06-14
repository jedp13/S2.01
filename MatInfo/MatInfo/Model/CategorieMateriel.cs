using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatInfo;

namespace MatInfo.Model
{
    public class CategorieMateriel : Crud<CategorieMateriel>
    {
        public CategorieMateriel(int idCategorie, string nomCategorie)
        {
            IdCategorie = idCategorie;
            NomCategorie = nomCategorie;
        }

        public CategorieMateriel()
        {
        }

        public int IdCategorie { get; set; }
        public String NomCategorie { get; set; }
        public ObservableCollection<Materiel> LesMateriaux { get; set; }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "insert into categorie_materiel(nomcategorie) values ("+this.NomCategorie+");";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CategorieMateriel> FindAll()
        {
            ObservableCollection<CategorieMateriel> lesCategories = new ObservableCollection<CategorieMateriel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idcategorie, nomcategorie from categorie_materiel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    CategorieMateriel e = new CategorieMateriel(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                    lesCategories.Add(e);
                }
            }
            return lesCategories;
        }

        public ObservableCollection<CategorieMateriel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = "Update categorie_materiel,SET nomcategorie='"+this.NomCategorie+"',where idcategorie='"+this.IdCategorie+"'" ;
            accesBD.SetData(requete);
        }
    }
}

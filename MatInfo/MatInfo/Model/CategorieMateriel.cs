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
    /// <summary>
    /// stocke 2 informations :
    /// 1 entier : identifiant de la categorie
    /// 1 chaine : le nom de la categorie
    /// </summary>
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
        /// <summary>
        /// obtient ou définit l'identifiant de la categorie
        /// </summary>
        public int IdCategorie { get; set; }
        private String? nomCategorie;
        /// <summary>
        /// obtient ou définit les materiaux
        /// </summary>
        public ObservableCollection<Materiel> LesMateriaux { get; set; }
        /// <summary>
        /// obtient ou définit le nom de la categorie
        /// ce champ est obligatoire
        /// </summary>
        /// <exception cref="ArgumentException">Envoyé si le nom de la categorie est null</exception>
        public string? NomCategorie
        {
            get
            {
                return nomCategorie;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom du catégorie doit être renseigné");
                nomCategorie = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        /// <summary>
        /// crée une categorie materiel dans la base de donnée
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into categorie_materiel(nomcategorie) values ('{this.NomCategorie}');";
            accesBD.SetData(requete);
            requete = $"select idcategorie from categorie_materiel where nomcategorie = '{ this.NomCategorie}'";
            this.IdCategorie = int.Parse(accesBD.GetData(requete).Rows[0]["idcategorie"].ToString());
        }
        /// <summary>
        /// supprime une categorie materiel dans la base de donnée
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE FROM categorie_materiel WHERE idcategorie='{this.IdCategorie}'";
            DataTable datas = accesBD.GetData(requete);
            
        }

        /// <summary>
        /// génère une categorie materiel dans la base de donnée
        /// </summary>
        /// <returns>une observable collection</returns>
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

        /// <summary>
        /// met à jour une categorie materiel dans la base de donnée
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Update categorie_materiel SET nomcategorie='{this.NomCategorie}' where idcategorie='{this.IdCategorie}'" ;
            DataTable datas = accesBD.GetData(requete);
        }

        /// <summary>
        /// gère l'affichage de la categorie materiel
        /// </summary>
        public override string? ToString()
        {
            return this.IdCategorie+" - "+this.NomCategorie ;
        }
    }
}

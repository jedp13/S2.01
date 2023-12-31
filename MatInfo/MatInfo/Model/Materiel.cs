﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatInfo.Model
{
    /// <summary>
    /// stocke 5 informations : 
    /// 2 entiers : identifiants du materiel et de la categorie
    /// 3 chaines : nom du materiel, la reference du constructeur, et le code barre
    /// </summary>
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
        /// <summary>
        /// obtient ou définit l'identifiant du materiel
        /// </summary>
        public int IdMateriel { get; set; }
        /// <summary>
        /// obtient ou définit l'identifiant de la categorie
        /// </summary>
        public int FK_IdCategorie { get; set; }
        private String? nomMateriel;
        private String? referenceConstructeur;
        private String? codeBarreInventaire;
        private CategorieMateriel uneCategorie;
        /// <summary>
        /// obtient ou définit les attributions
        /// </summary>
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }


        /// <summary>
        /// obtient ou définit le nom du materiel
        /// ce champ est obligatoire
        /// </summary>
        /// <exception cref="ArgumentException">Envoyé si le nom est null</exception>
        public string? NomMateriel
        {
            get
            {
                return nomMateriel;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom du matériel doit être renseigné");
                nomMateriel = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }

        public string? ReferenceConstructeur
        {
            get
            {
                return referenceConstructeur;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le référence constructeur du matériel doit être renseigné");
                referenceConstructeur = value;
            }
        }

        public string? CodeBarreInventaire
        {
            get
            {
                return codeBarreInventaire;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le code barre du matériel doit être renseigné");
                codeBarreInventaire = value;
            }
        }

        public CategorieMateriel UneCategorie
        {
            get
            {
                return uneCategorie;
            }

            set
            {
                if (value is null)
                    throw new ArgumentException("Le Categorie du matériel doit être renseigné");
                uneCategorie = value;
            }
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into materiel( nommateriel, referenceconstructeurmateriel,codebarreinventaire,idcategorie)  values('{ this.NomMateriel}','{ this.ReferenceConstructeur}','{ this.CodeBarreInventaire}','{ this.UneCategorie.IdCategorie}') ;";
            accesBD.SetData(requete);
            requete = $"select idmateriel from materiel where codebarreinventaire = '{ this.CodeBarreInventaire}'";
            this.IdMateriel = int.Parse(accesBD.GetData(requete).Rows[0]["idmateriel"].ToString());
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE FROM materiel WHERE idmateriel={ this.IdMateriel}";
            accesBD.SetData(requete);
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
            DataAccess accesBD = new DataAccess();
            String requete = $"Update materiel SET nommateriel='{this.NomMateriel}', idcategorie ={ this.UneCategorie.IdCategorie}, codebarreinventaire ='{ this.CodeBarreInventaire}', referenceconstructeurmateriel ='{ this.ReferenceConstructeur}' where idmateriel= { this.IdMateriel } ";
            accesBD.SetData(requete);
        }

        public override string? ToString()
        {
            return this.IdMateriel+" - "+this.NomMateriel;
        }
    }
}

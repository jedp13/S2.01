using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatInfo.Model
{
    /// <summary>
    /// stocke 4 informations :
    /// 1 entier : identifiant du personnel
    /// 3 chaines : l'email du personnel, le nom du personnel, et le prenom du personnel
    /// </summary>
    public class Personnel : Crud<Personnel>
    {
        public Personnel(int idPersonnel, string emailPersonnel, string nomPersonnel, string prenomPersonnel)
        {
            IdPersonnel = idPersonnel;
            EmailPersonnel = emailPersonnel;
            NomPersonnel = nomPersonnel;
            PrenomPersonnel = prenomPersonnel;
        }
        public Personnel()
        { }


        private String? prenomPersonnel;
        private String? nomPersonnel;
        private String? emailPersonnel;

        /// <summary>
        /// obtient ou définit l'identifiant du personnel
        /// </summary>
        public int IdPersonnel { get; set; }
        /// <summary>
        /// obtient ou définit les attributions
        /// </summary>
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }
        /// <summary>
        /// obtient ou definit le prenom du personnel
        /// ce champ est obligatoire
        /// </summary>
        /// <exception cref="ArgumentException">Envoyé si le prenom est null</exception>
        public string? PrenomPersonnel
        {
            get
            {
                return prenomPersonnel;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le prenom du personnel doit être renseigné");
                prenomPersonnel = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        /// <summary>
        /// obtient ou définit le nom du personnel
        /// ce champ est obligatoire
        /// </summary>
        /// <exception cref="ArgumentException">Envoyé si le nom est null</exception>
        public string? NomPersonnel
        {
            get
            {
                return nomPersonnel;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom du personnel doit être renseigné");
                nomPersonnel = value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
            }
        }
        /// <summary>
        /// obtient ou définit l'email du personnel
        /// ce champ est obligatoire et doit respecter certaines normes (pas 2 @, doit finir par .com, .fr,...)
        /// </summary>
        /// <exception cref="ArgumentException">Envoyé si l'email est null ou si les normes ne sont pas respectées</exception>
        public string? EmailPersonnel
        {
            get
            {
                return emailPersonnel;
            }

            set
            {
                string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|fr)$";
                if (string.IsNullOrWhiteSpace(value)||!Regex.IsMatch(value, regex, RegexOptions.IgnoreCase))
                    throw new ArgumentException("Le mail du personnel doit être renseigné");
                //else if(ApplicationData.LesPersonnels.ToList().Find(p => p.EmailPersonnel == value) is not null)
                emailPersonnel = value;
            }
        }
        /// <summary>
        /// crée un personnel dans la base de donnée
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into personnel( emailpersonnel, nompersonnel,prenompersonnel)  values('{this.EmailPersonnel}','{this.NomPersonnel}','{this.PrenomPersonnel}') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = '{this.EmailPersonnel}'";
            this.IdPersonnel = int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString());

        }
        /// <summary>
        /// supprimer un personnel dans la base de donnée
        /// </summary>
        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE FROM personnel WHERE idpersonnel='{ this.IdPersonnel}'";
            accesBD.SetData(requete);

        }
        /// <summary>
        /// génère un personnel dans la base de donnée
        /// </summary>
        /// <returns>une observable collection</returns>
        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, emailpersonnel, nompersonnel,prenompersonnel from personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["emailpersonnel"], (String)row["nompersonnel"], (String)row["prenompersonnel"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }
       
        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
       
        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// met a jour un personnel dans la base de donnée
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Update personnel SET nompersonnel='{ this.NomPersonnel}', prenompersonnel ='{this.PrenomPersonnel}', emailpersonnel ='{this.EmailPersonnel}' where idpersonnel='{ this.IdPersonnel}'";
            accesBD.SetData(requete);
        }
        /// <summary>
        /// gère l'affichage d'un personnel
        /// </summary>
        public override string? ToString()
        {
            return this.IdPersonnel+" - "+ this.PrenomPersonnel + " " +this.NomPersonnel;
        }
    }
}

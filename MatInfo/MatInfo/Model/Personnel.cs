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

        public int IdPersonnel { get; set; }
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }

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

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into personnel( emailpersonnel, nompersonnel,prenompersonnel)  values('{this.EmailPersonnel}','{this.NomPersonnel}','{this.PrenomPersonnel}') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = '{this.EmailPersonnel}'";
            this.IdPersonnel = int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString());

        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE FROM personnel WHERE idpersonnel='{ this.IdPersonnel}'";
            accesBD.SetData(requete);

        }

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

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Update personnel SET nompersonnel='{ this.NomPersonnel}', prenompersonnel ='{this.PrenomPersonnel}', emailpersonnel ='{this.EmailPersonnel}' where idpersonnel='{ this.IdPersonnel}'";
            accesBD.SetData(requete);
        }

        public override string? ToString()
        {
            return this.IdPersonnel+" - "+ this.PrenomPersonnel + " " +this.NomPersonnel;
        }
    }
}

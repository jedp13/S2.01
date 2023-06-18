using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
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
            
        

        public int IdPersonnel { get; set; }
        public String EmailPersonnel { get; set; }
        public String NomPersonnel { get; set; }
        public String PrenomPersonnel { get; set; }
        public ObservableCollection<EstAttribue> LesAttributions { get; set; }
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
            return this.IdPersonnel+" - "+ this.PrenomPersonnel + " "+this.NomPersonnel;
        }
    }
}

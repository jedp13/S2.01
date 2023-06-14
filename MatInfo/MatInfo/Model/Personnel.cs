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
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

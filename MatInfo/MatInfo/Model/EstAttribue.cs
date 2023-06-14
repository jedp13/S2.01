using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatInfo.Model
{
    public class EstAttribue : Crud<EstAttribue>
    {
        public EstAttribue(int fK_IdPersonnel, int fK_IdMateriel, DateTime dateAttribution, string commentaireAttribution)
        {
            FK_IdPersonnel = fK_IdPersonnel;
            FK_IdMateriel = fK_IdMateriel;
            DateAttribution = dateAttribution;
            CommentaireAttribution = commentaireAttribution;
        }
        public EstAttribue() { }

        public int FK_IdPersonnel { get; set; }
        public int FK_IdMateriel { get; set; }
        public DateTime DateAttribution { get; set; }
        public String CommentaireAttribution { get; set; }
        public Materiel UnMateriel { get; set; }
        public Personnel UnPersonnel { get; set; }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<EstAttribue> FindAll()
        {
            ObservableCollection<EstAttribue> lesAttributions = new ObservableCollection<EstAttribue>();
            DataAccess accesBD = new DataAccess();
            String requete = "select idpersonnel, idmateriel, dateattribution, commentaireattribution from est_attribue ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    EstAttribue e = new EstAttribue(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)row["dateattribution"], (String)row["commentaireattribution"]);
                    lesAttributions.Add(e);
                }
            }
            return lesAttributions;
        }

        public ObservableCollection<EstAttribue> FindBySelection(string criteres)
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

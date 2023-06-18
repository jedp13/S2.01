 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into est_attribue( idpersonnel, idmateriel,dateattribution,commentaireattribution)  values({ this.UnPersonnel.IdPersonnel},{ this.UnMateriel.IdMateriel},'{ this.DateAttribution}','{ this.CommentaireAttribution}') ;";
            accesBD.SetData(requete);


        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE FROM est_attribue where idmateriel= {this.UnMateriel.IdMateriel} and dateattribution ='{this.DateAttribution}' and idpersonnel={this.UnPersonnel.IdPersonnel}";
            accesBD.SetData(requete);
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
            DataAccess accesBD = new DataAccess();
            String requete = $"Update materiel SET idpersonnel={this.UnPersonnel.IdPersonnel}, idmateriel ={this.UnMateriel.IdMateriel}, dateattribution ='{this.DateAttribution}', commentaireattribution ='{this.CommentaireAttribution}' where idmateriel= {this.UnMateriel.IdMateriel} and dateattribution ='{this.DateAttribution}' and idpersonnel={this.UnPersonnel.IdPersonnel} ";
            accesBD.SetData(requete);
        }
    }
}

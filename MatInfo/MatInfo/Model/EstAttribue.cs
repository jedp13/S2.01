 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MatInfo.Model
{
    /// <summary>
    /// stocke 4 informations :
    /// 2 entiers : identifiants du personnel et du materiel
    /// 1 date : date de l'attribution
    /// 1 chai,e : le commentaire de l'attribution
    /// </summary>
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

        public int FK_IdPersonnel { get; set;}
        public int FK_IdMateriel { get; set; }
        private DateTime? dateAttribution;
        public String CommentaireAttribution { get; set; }

        public Materiel? UnMateriel
        {
            get
            {
                return unMateriel;
            }

            set
            {
                if (value is null)
                    throw new ArgumentException("Le matétiel de l'attribution doit être renseigné");
                unMateriel = value;
            }
        }

        public Personnel? UnPersonnel
        {
            get
            {
                return unPersonnel;
            }

            set
            {
                if (value is null)
                    throw new ArgumentException("Le personnel de l'attribution doit être renseigné");
                unPersonnel = value;
            }
        }

        public DateTime? DateAttribution
        {
            get
            {
                return dateAttribution;
            }

            set
            {
                if (value is null)
                    throw new ArgumentException("La date de l'attribution doit être renseigné");
                dateAttribution = value;
            }
        }

        private Materiel? unMateriel;
        private Personnel? unPersonnel;
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
            ObservableCollection<EstAttribue> lesAttributions = new ObservableCollection<EstAttribue>();
            DataAccess accesBD = new DataAccess();
            String requete = $"select * from est_attribue {criteres};";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    EstAttribue e = new EstAttribue(int.Parse(row["idpersonnel"].ToString()), int.Parse(row["idmateriel"].ToString()), (DateTime)row["dateattribution"], (String)row["commentaireattribution"]);
                    lesAttributions.Add(e);
                    e.UnMateriel= new Materiel(int.Parse(row["idmateriel"].ToString()), int.Parse(row["idcategorie"].ToString()), (String)row["nommateriel"], (String)row["referenceconstructeurmateriel"], (String)row["codebarreinventaire"]);
                    e.unPersonnel = new Personnel(int.Parse(row["idpersonnel"].ToString()), (String)row["emailpersonnel"], (String)row["nompersonnel"], (String)row["prenompersonnel"]);
                    e.unMateriel.UneCategorie = new CategorieMateriel(int.Parse(row["idcategorie"].ToString()), (String)row["nomcategorie"]);
                }
            }
            return lesAttributions;
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

        public override string? ToString()
        {
            return this.UnPersonnel + " ( " + this.UnMateriel.NomMateriel + " ) : " + ( (DateTime) this.DateAttribution).ToString("dd/MM/yyyy");
        }
    }
}

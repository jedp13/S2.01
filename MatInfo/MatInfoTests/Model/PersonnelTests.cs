using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.ActiveDirectory;

namespace MatInfo.Model.Tests
{
    [TestClass()]
    public class PersonnelTests
    {
      


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Prenom()
        {
            //prenom null
            Personnel prenomNull = new Personnel(1, "manon.levet@gmail.com", "Levet", "");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Nom()
        {
            //nom null
            Personnel nomNull = new Personnel(1, "manon.levet@gmail.com", "", "Manon");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AdresseNull()
        {
            //adresse null
            Personnel adresseNull = new Personnel(1, "", "Levet", "Manon");
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Adresse()
        {
            //adresse fausse
            Personnel adresseFausse = new Personnel(1, "manon.levet@gmail", "Levet", "Manon");
        }



        [TestMethod()]
        public void CreateTest()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into personnel( idpersonnel, emailpersonnel, nompersonnel,prenompersonnel)  values('150', 'manon.levet@gmail.com','Levet','Manon') ;";
            accesBD.SetData(requete);
            requete = $"select idpersonnel from personnel where emailpersonnel = 'manon.levet@gmail.com'";
            accesBD.GetData(requete);
            Assert.AreEqual(150, int.Parse(accesBD.GetData(requete).Rows[0]["idpersonnel"].ToString()));
            String requete1 = $"DELETE FROM personnel WHERE emailpersonnel='manon.levet@gmail.com'";
            accesBD.SetData(requete1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into personnel( idpersonnel, emailpersonnel, nompersonnel,prenompersonnel)  values('150', 'manon.levet@gmail.com','Levet','Manon') ;";
            accesBD.SetData(requete);
            requete = "select count(*) from personnel;";
            String requete1 = $"DELETE FROM personnel WHERE emailpersonnel='manon.levet@gmail.com'";
            accesBD.SetData(requete1);
            requete = $"select idpersonnel from personnel where emailpersonnel = 'manon.levet@gmail.com'";
            accesBD.GetData(requete);
            String requete2 = "select count(*) from personnel;";
            accesBD.GetData(requete2);
            Assert.AreNotEqual(requete, requete2);
        }

       

        [TestMethod()]
        public void UpdateTest()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"insert into personnel( idpersonnel, emailpersonnel, nompersonnel,prenompersonnel)  values('150', 'manon.levet@gmail.com','Levet','Manon') ;";
            accesBD.SetData(requete);
            String requete1 = $"Update personnel SET nompersonnel='Levet', prenompersonnel ='Elodie', emailpersonnel ='manon.levet@gmail.com' where idpersonnel='150'";
            accesBD.SetData(requete1);
            requete = $"select prenompersonnel from personnel where emailpersonnel = 'manon.levet@gmail.com'";
            accesBD.GetData(requete);
            Assert.AreEqual("Elodie", accesBD.GetData(requete).Rows[0]["prenompersonnel"]);
            String requete2 = $"DELETE FROM personnel WHERE emailpersonnel='manon.levet@gmail.com'";
            accesBD.SetData(requete1);
        }

      
    }
}
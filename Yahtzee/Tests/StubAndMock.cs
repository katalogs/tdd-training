using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;

namespace Tests
{
    public class StubAndMock
    {
        [Fact]
        public void Dis_Bonjour_Avant_19h()
        {
            Mock < Horloge > stub  = new Mock<Horloge>();
            stub.Setup(s => s.Maintenant()).Returns(new DateTime(2020, 12, 1, 14, 0, 0));
            Polie polie= new Polie(stub.Object);
            string salutation = polie.Saluer();
            Assert.Equal("Bonjour",salutation);
        }


        [Fact]
        public void Dis_Bonsoir_Apres_19h()
        {
            Mock<Horloge> stub = new Mock<Horloge>();
            stub.Setup(s => s.Maintenant()).Returns(new DateTime(2020, 12, 1, 20, 0, 0));

            
            Polie polie = new Polie(stub.Object);
            string salutation = polie.Saluer();
            Assert.Equal("Bonsoir", salutation);
        }

        [Fact]
        public void Lance_un_Missile_si_le_bon_mot_de_passe_est_donne()
        {
            Mock<LanceurMissile> lanceur = new Mock<LanceurMissile>();

            var controlleur = new Controlleur(lanceur.Object);
            controlleur.LancerMissile("Trump");

            lanceur.Verify(l=>l.Lancer(),Times.Once);
        }

        [Fact]
        public void Ne_lance_pas_de_Missile_si_mauvais_mot_de_passe_est_donne()
        {
            Mock<LanceurMissile> lanceur = new Mock<LanceurMissile>();

            var controlleur = new Controlleur(lanceur.Object);
            controlleur.LancerMissile("Kim");

            lanceur.Verify(l => l.Lancer(), Times.Never);
        }

    }

    public class Controlleur
    {
        private readonly LanceurMissile lanceurObject;

        public Controlleur(LanceurMissile lanceurObject)
        {
            this.lanceurObject = lanceurObject;
        }

        public void LancerMissile(string motDePasse)
        {
            if (motDePasse == "Trump")
            {
                lanceurObject.Lancer();
            }
                
        }
    }

    public interface LanceurMissile
    {
        void Lancer();
    }


    public interface Horloge
    {
        DateTime Maintenant();
    }

    public class VraieHorloge : Horloge
    {
        public DateTime Maintenant()
        {
            return DateTime.Now;
        }
    }
    public class Polie
    {
        private Horloge horloge;

        public Polie(Horloge horloge)
        {
            this.horloge = horloge;
        }

        public string Saluer()
        {
            if (horloge.Maintenant().Hour < 19)
            {
                return "Bonjour";
            }

            return "Bonsoir";

        }
    }
}

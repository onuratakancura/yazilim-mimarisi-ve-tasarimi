public class ArabaConcrete1 : ArabaBuilder
    {
        public ArabaConcrete1()
        {
            _araba = new Araba { Marka = "Concrete1" };
        }
 
        public override void MotorTak()
        {
            _araba.Motor = "1.4 LPG";
        }
 
        public override void LastikTak()
        {
            _araba.Lastik = "15' Çelik jant";
        }
    }
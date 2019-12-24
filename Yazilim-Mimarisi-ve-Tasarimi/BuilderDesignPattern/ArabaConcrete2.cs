public class ArabaConcrete2 : ArabaBuilder
    {
        public ArabaConcrete2()
        {
            _araba = new Araba { Marka = "Concrete2" };
        }
 
        public override void MotorTak()
        {
            _araba.Motor = "1.8 Dizel";
        }
 
        public override void LastikTak()
        {
            _araba.Lastik = "17' Bor alaşımlı çelik jant";
        }
    }
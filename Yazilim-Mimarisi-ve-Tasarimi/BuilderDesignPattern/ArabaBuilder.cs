public abstract class ArabaBuilder
    {
        protected Araba _araba;
        public Araba araba
        {
            get { return _araba; }
        }
        public abstract void MotorTak();
        public abstract void LastikTak();
    }
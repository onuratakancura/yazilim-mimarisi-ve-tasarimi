public class Araba
    {
        public string Marka { get; set; }
        public string Motor { get; set; }
        public string Lastik { get; set; }
 
        public override string ToString()
        {
            return String.Format("Marka:{0},Motor:{1},Lastik:{2}", Marka, Motor, Lastik);
        }
    }
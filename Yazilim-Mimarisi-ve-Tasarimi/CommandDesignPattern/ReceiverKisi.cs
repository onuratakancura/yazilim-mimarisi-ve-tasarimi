 public class ReceiverKisi
{
    private Kisi _EntityKisi;
 
    public ReceiverKisi(Kisi entityKisi)
    {
        this._EntityKisi = entityKisi;
    }
 
    public void Ekle()
    {
        Console.WriteLine("{0} Eklendi.", _EntityKisi.Ad);
    }
 
    public void Sil()
    {
        Console.WriteLine("ID:{0} Silindi.", _EntityKisi.ID);
    }
}
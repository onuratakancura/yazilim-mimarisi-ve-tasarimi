 public class ConcreteCommandKisiEkle : CommandKisi
{
    public ConcreteCommandKisiEkle(ReceiverKisi receiverKisi)
        : base(receiverKisi)
    {
 
    }
 
    public override void Execute()
    {
        _receiverKisi.Ekle();
    }
}
 public class ConcreteCommandKisiSil : CommandKisi
{
    public ConcreteCommandKisiSil(ReceiverKisi receiverKisi)
        : base(receiverKisi)
    {
 
    }
 
    public override void Execute()
    {
        _receiverKisi.Sil();
    }
}
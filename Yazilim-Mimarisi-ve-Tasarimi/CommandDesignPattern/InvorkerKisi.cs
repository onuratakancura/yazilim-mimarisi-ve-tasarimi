 public class InvokerKisi
{
    public List<CommandKisi> CommandKisiList { get; set; }
 
    public InvokerKisi()
    {
        CommandKisiList = new List<CommandKisi>();
    }
 
    public void ExecuteAll()
    {
        if (CommandKisiList.Count == 0)
            return;
 
        foreach (CommandKisi item in CommandKisiList)
        {
            item.Execute();
        }
    }
}
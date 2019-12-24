# Yazilim Mimarisi ve Tasarimi

## Builder Tasarım Deseni

- Builder (İnşaatçı) tasarım deseni creational grubununa ait, biden fazla parçadan oluşan nesnelerin üretilmesinden sorumlu bir tasarım desenidir.
- Bazı nesneler birden fazla nesnenin birleşmesinden(bazı işlemleri yapması sonucu) oluşabilir. Zamanla bu ana nesneyi oluşturan nesnelerin yapısı değişebilir, bu nesnelerin oluşturulması karışık bir hal alabilir veya bu nesnelere başka nesneler de eklenebilir. Builder tasarım deseni bu gibi durumlarda genişletilebilirliği sağlamak ve kod karmaşıklığını engellemek için kullanılır. Builder tasarım deseninde bu nesnelerin oluşturulması Builder denilen sınıfların sorumluluğundadır. Client sadece oluşturulacak nesne türünü belirterek ana nesneyi oluşturan nesnelerin oluşturulmasıyla ilgilenmez. Abstract factory tasarım kalıbı ile benzer bir yapısı vardır. Aralarındaki fark builder tasarım deseni birden fazla nesnenin birleşmesinden oluşan nesnelerin üretilmesinden sorumludur.

![Image of Class](builderuml.png)

- Örneğin Marka, Model ve Lastik özellikleri olan bir araba nesnemiz olsun. Bu araba nesnemizin özelliklerinin farklı değerler alması ile farklı özelliklerde araba nesnesi üretebiliriz. Builder tasarım deseni ile bu senaryoyu gerçekleştirelim. Uygulamamızın class diyagramı aşağıdadır.

![Image of Class](diagramBuilderDeseni.png)

İlk önce Araba nesnemizi oluşturuyoruz.

```
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
```
ArabaBuilder arayüzü builder desenindeki Builder yapısıdır.
Bir sınıfın Product ı oluşturan nesneleri oluşturması veya product ın özelliklerini setlemesi ile product ı oluşturan sınıflar bu arayüzü kullanmalıdır.

```
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

```
ArabaBuilder arayüzünden türeyen bütün sınıflar Builder desenindeki ConcreteBuilder yapısıdır.
ConcreteBuilder yapısı değişik product nesnelerinin oluşturulmasını sağlamaktır.

```
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
```
ArabaBuilder arayüzündeki metodları çalıştırarak productın oluşturulmasını sağlar.
Builder desenindeki Director yapısıdır.

```
 public class ArabaDirector
    {
        public ArabaDirector(ArabaBuilder ArabaConcrete)
        {
            ArabaConcrete.MotorTak();
            ArabaConcrete.LastikTak();
        }
    }
 
```
Desenimizi aşağıdaki şekilde kullanabiliriz.

```

class Program
{
    static void Main(string[] args)
    {
        ArabaBuilder araba_builder = new ArabaConcrete1();
        ArabaDirector araba_olusutucu = new ArabaDirector(araba_builder);
        Console.WriteLine(araba_builder.araba.ToString());
 
        araba_builder = new ArabaConcrete2();
        araba_olusutucu = new ArabaDirector(araba_builder);
        Console.WriteLine(araba_builder.araba.ToString());
 
        Console.ReadKey();
    }
}

```

 Builder desenini oluşturan 4 yapı vardır.

   - Product--> Oluşturulan nesne.
   - Builder--> Product oluşturacak nesnelerin (Concrete Builder) uygulaması gereken arayüz.
   - Concrete Builder--> Product nesnesini oluşturan nesne veya özelliklerin oluşturulduğu sınıflar. Her concrete builder sınıfı aynı arayüzde farklı bir ürünün oluşturulmasını sağlar.
   - Director--> Verilen builder nesnesine göre product örneği oluşturur.
   
   # Komut Tasarım Deseni - Command Design Pattern

- Command design pattern (komut tasarım deseni) behavior grubununa ait, işlemlerin nesne haline getirilip başka bir nesne(invoker) üzerinden tetiklendiği bir tasarım desenidir.

- Command design pattern (komut tasarım deseni), yapılmak istenilen işlemlerin nesneye dönüştürülüp başka bir nesne tarafından bu işlemlerin tetiklenmesi şeklindedir. Command tasarım deseninde, işlem ve işlemin tetiklenmesi yapıları birbirinden ayrılmış olur. İşlemi yapacak nesnenin birden fazla olması durumunda işlemlerin sırayla çalıştırılabilinmesini sağlamış oluruz ve aynı işlem nesnelerini uygulamanın birden fazla yerinde kullanabilir oluruz. 


![Image of Class](commandUML.jpg)

Örneğin kişi nesnemiz olsun ve bu nesnemiz için ekle ve sil işlemlerimiz olsun. (Bu senaryoda kişi nesnemizin desen ile bir alakası yoktur sadece örnek olması açısından uygulamaya eklenecektir.)

Uygulamamızın class diyagramı aşağıdadır.

![Image of Class](CommandDiagram.jpg)


İlk önce kisi nesnemizi oluşturalım.

```C#
public class Kisi
{
    public int ID { get; set; }
    public string Ad { get; set; }
}
```

Kisi nesnemiz için ekle ve sil işlemlerinin yani metotlarının olduğu, tasarım desenimizde ki Invoker yapısına karşılık gelen ReceiverKisi nesnemizi oluşturalım.
Kisi üzerinde işlemler yapan nesne.
```
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
```

ReceiverKisi nesnemizde tanımlı olan Ekle() veya Sil() metotlarını çalıştıracak, desenimizdeki Command yapısına karşılık gelen, CommandKisi soyut sınıfımızı oluşturalım. 
ReceiverKisi deki ekle veya sil metotlarını çalıştıracak olan sınıfların uygulaması gereken abstract sınıf.
```
 public abstract class CommandKisi
{
    protected ReceiverKisi _receiverKisi;
    public CommandKisi(ReceiverKisi receiverKisi)
    {
        this._receiverKisi = receiverKisi;
    }
 
    public abstract void Execute();
}
```

CommandKisi abstract nesnesinden türeyen yani ReceiverKisi nesnesindeki metotları kullanan, tasarım desenimizdeki Concrete Command yapısına karşılık gelen nesnelerimizi oluşturalım.
ReceiverKisi de Ekle metodunu çalıştıracak olan ConcreteCommand nesnesi.
```
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
```

ReceiverKisi de ```Sil``` metodunu çalıştıracak olan ConcreteCommand nesnesi.
```
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
```

Şimdi de tasarım desenimizde ki Invoker yapısına karşılık gelen, yani ```CommandKisi``` soyut sınıfını kullanan nesnelerin ```Execute()``` metodunu çalıştıracak olan ```InvokerKisi``` nesnemizi oluşturalım.
İşlemlerin çalıştırılacağı nesne.

```
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
```
Son olarak da tasarım desenimizde ki client yapısını oluşturalım.

```
 class Program
{
    static void Main(string[] args)
    {
        Kisi Kisi = new Kisi { ID = 1, Ad = "Ahmet" };
 
        ReceiverKisi rk1 = new ReceiverKisi(Kisi);
            
        CommandKisi ckAdd = new ConcreteCommandKisiEkle(rk1);
        CommandKisi ckSil = new ConcreteCommandKisiSil(rk1);
 
        InvokerKisi ik = new InvokerKisi();
 
        ik.CommandKisiList.Add(ckAdd);
        ik.CommandKisiList.Add(ckSil);
 
        ik.ExecuteAll();
 
        Console.ReadKey();
    }
}
```

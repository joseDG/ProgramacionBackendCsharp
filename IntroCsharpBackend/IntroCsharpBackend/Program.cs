
using IntroCsharpBackend;


var sale = new Sale();
var beer = new Beer();

Some(sale);
Some(beer);

void Some(ISave save)
{
    save.Save();
}

var numbers = new List<int>(5);
var names = new List<string>(5);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);






//------------------------------------------------------------------------------------------------------------------------

//Sale sale = new Sale(15);
//var message = sale.GetInfo();

//Console.WriteLine(message);

//Herencia
//class SaleWithTax : Sale
//{

//    public decimal Tax { get; set; }

//    //constructor
//    public SaleWithTax(decimal total, decimal tax) : base(total)
//    {
//        Tax = tax;
//    }

//    //SobreEscritura
//    public override string GetInfo()
//    {
//        return "El total es " + Total + " y el impuesto es " + Tax;
//    }

//    //Sobre carga de metodos
//    public string GetInfo(string message)
//    {
//        return message + " ";
//    }
//}

//class Sale
//{
//    public decimal Total { get; set; }


//    //constructor
//    public Sale(decimal total)
//    {
//        Total = total;
//    }

//    //metodo
//    public virtual string GetInfo()
//    {
//        return "El total es " + Total;
//    }
//}


using IntroCsharpBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IntroCsharpBackend
{

    interface ISale
    {
        decimal Total { get; set; }
    }

    interface ISave 
    {
        public void Save();
    }

    public class Sale : ISale, ISave
    {
        public decimal Total { get; set; }

        public void Save()
        {
            Console.WriteLine("Guardando venta");
        }

    }

    public class Beer: ISave
    {
        public void Save()
        {
            Console.WriteLine("Guardando cerveza");
        }
    }
}



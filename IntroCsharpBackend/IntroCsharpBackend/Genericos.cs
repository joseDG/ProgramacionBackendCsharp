using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IntroCsharpBackend
{

    public class Genericos<T>
    {
        private List<T> _list;
        private int _limit;

        public Genericos(int limit)
        {
            _limit = limit;
        }

        public void Add(T item) {
            if (_list.Count < _limit) {
                _list.Add(item);
            }
        }

        public string GetContent() 
        {
            string content = "";
            foreach (var item in _list)
            {
                content += item.ToString() + " ";
            }
            return content;
        }
    }
}

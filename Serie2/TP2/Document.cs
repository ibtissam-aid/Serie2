using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie2.TP2
{
    internal  abstract class Document
    {
       private  int numero = 0;//on peut faire un static 
        private string Title;

        public Document(string titre) {
            numero ++;
            Title = titre;
        }
        public int num
        {
            get { return numero; }
            set { numero = value; }
        }

        public string titre
        {
            get { return Title; }
            set { Title  = value; }
        }
        public abstract string  Description();
        

    }
}

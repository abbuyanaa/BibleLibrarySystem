using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleLibrarySystem.Models
{
    class BookModel
    {
        private String name;
        private String tailbar;
        private string lang;

        public BookModel(String name, String tailbar, string lang)
        {
            this.name = name;
            this.tailbar = tailbar;
            this.lang = lang;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getTailbar()
        {
            return this.tailbar;
        }

        public void setTailbar(string tailbar)
        {
            this.tailbar = tailbar;
        }

        public string getLang()
        {
            return this.lang;
        }

        public void setLang(string lang)
        {
            this.lang = lang;
        }
    }
}

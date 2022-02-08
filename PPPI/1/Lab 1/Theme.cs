using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Theme
    {
        public string thesis { get; set; }
        public bool select { get; set; }
        public Theme() { thesis = "Game"; select = true; }
        public Theme(string thesis, bool select) { this.thesis = thesis; this.select = select; }
        public override string ToString()
        {
            return thesis + " "+ select;
        }
        public virtual object DeepCopy()
        {
            Theme th = new Theme(thesis, select);
            return th;
        }
    }
}

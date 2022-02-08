using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class LecturerListHandlerEventArgs: System.EventArgs
    {
        public string collectionName { get; set; }
        public string changeType { get; set; }
        public Lecturer objLecturer { get; set; }

        public LecturerListHandlerEventArgs()
        {
            collectionName = "";
            changeType = "";
            objLecturer = new Lecturer();
        }

        public override string ToString()
        {
            return collectionName + " " + changeType + " " + objLecturer;
        }
    }
}

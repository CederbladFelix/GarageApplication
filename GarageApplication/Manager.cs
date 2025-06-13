using GarageApplication.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApplication
{
    internal class Manager
    {
        public Handler Handler { get; set; }
        public UI UI { get; set; }
        public Manager(Handler handler, UI ui)
        {
            Handler = handler;
            this.UI = ui;
        }
        public void Run()
        {
            
        }

    }
}

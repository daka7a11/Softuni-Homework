using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Interfaces
{
    interface ICar
    {
        abstract public string Model { get; set; }
        abstract public string Color { get; set; }
        public string Start();
        public string Stop();
    }
}

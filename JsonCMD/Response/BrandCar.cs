using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCMD.Response
{
    public  class BrandCar
    {
        public Value Value { get; set; }
        public string ValueId { get; set; }

        public BrandCar()
        {
            Value = new Value();
        }
    }
    public  class Value
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}

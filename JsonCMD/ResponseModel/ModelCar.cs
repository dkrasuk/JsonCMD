using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCMD.ResponseModel
{
    public class ModelCar
    {
        public Value Value { get; set; }
        public string ValueId { get; set; }
        public ModelCar()
        {
            Value = new Value();
        }
    }
    public class Value
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    }
}

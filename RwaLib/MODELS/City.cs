using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.MODELS
{
    [Serializable]
    public class City
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"{Name}";
    }
}

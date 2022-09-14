using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.MODELS
{
    [Serializable]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public int TagTypeID { get; set; }
        public string TagTypeName { get; set; }
        public string TagTypeNameEng { get; set; }
        public int Used { get; set; }

        //public bool TagIsUsed(object o)
        //{
        //    if (this.Used == 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace destinycalc01
{
    public class clsCoreData
    {
        public int[] coreData { get; set; }
        public int sttValue { get; set; }
        public int endValue { get; set; }
        public string title { get; set; }
        public coreDataType dataType { get; set; }

        public enum coreDataType
        {
            None = 0,
            ZivaTypeA = 1,
            ZivaTypeB = 2,
        }

        public clsCoreData()
        {
            this.coreData = new int[100];
            this.title = string.Empty;
            this.dataType = coreDataType.None;
            this.sttValue = 0;
            this.endValue = 0;
        }
    }
}

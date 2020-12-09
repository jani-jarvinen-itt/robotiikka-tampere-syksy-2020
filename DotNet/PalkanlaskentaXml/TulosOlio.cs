using System;

namespace PalkanlaskentaXml
{
    public class TulosOlio {
        public string personName { get; set; }

        public TulosOlioPalkkatiedot salary { get; set; }

        public string hireDate { get; set; }
    }

    public class TulosOlioPalkkatiedot {
        public float monthly { get; set; }
    }
}
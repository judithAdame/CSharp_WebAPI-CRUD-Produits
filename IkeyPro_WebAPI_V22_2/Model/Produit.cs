using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro_WebAPI_V22_2.Model
{
    public class Produit
    {   [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Qte { get; set; }
        public double Prix { get; set; }

    }
}


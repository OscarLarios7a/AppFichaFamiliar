using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class capaEntidadDatosTerritoriales
    {
        public int idEstructuraTerritorial { get; set; }
        public int idRegion { get; set; }
        public string region { get; set; }
        public string cveLocOfi { get; set; }
        public string cveMunicipio { get; set; }
        public string municipio { get; set; }
        public string cveLocalidad { get; set; }
        public string localidad { get; set; }
        public string microZona { get; set; }
        public int idFamilia { get; set; }
    }
}

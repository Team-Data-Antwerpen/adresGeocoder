using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adressenGeocoder
{
   class nominatimResult
   {
      int place_id;
      string osm_type;
      int osm_id;
      double[] boundingbox;
      string lat;
      string lon;
      string  display_name;
      string class_;
      string type;
      double importance;
   }
}

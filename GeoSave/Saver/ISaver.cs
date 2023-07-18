using GeoSave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeoSave.Sacer
{
    interface ISaver
    {
        public void Initialize();
        public bool Save(GeolocalizationData data, out string message);
    }
}

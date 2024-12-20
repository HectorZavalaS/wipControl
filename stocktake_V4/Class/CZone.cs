using stocktake_V4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stocktake_V4.Class
{
    class CZone
    {
        private String m_name;
        getZonesQty_Result m_zone;
        TextProgressBar m_ProgressBar;

        public string Name { get => m_name; set => m_name = value; }
        public getZonesQty_Result Zone { get => m_zone; set => m_zone = value; }
        public TextProgressBar ProgressBar { get => m_ProgressBar; set => m_ProgressBar = value; }
    }
}

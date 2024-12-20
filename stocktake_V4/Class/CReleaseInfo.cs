using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stocktake_V4.Class
{
    public class CReleaseInfo
    {
        private String m_PRODUCT_ID;
        private String m_PANEL_ID;
        private String m_PRODUCT_PN;
        private String m_PRODUCT_PN_REV;
        private String m_ROUTE_NAME;
        private String m_BATCH_ID;
        private int m_QTY;

        public string PRODUCT_ID { get => m_PRODUCT_ID; set => m_PRODUCT_ID = value; }
        public string PANEL_ID { get => m_PANEL_ID; set => m_PANEL_ID = value; }
        public string PRODUCT_PN { get => m_PRODUCT_PN; set => m_PRODUCT_PN = value; }
        public string PRODUCT_PN_REV { get => m_PRODUCT_PN_REV; set => m_PRODUCT_PN_REV = value; }
        public string ROUTE_NAME { get => m_ROUTE_NAME; set => m_ROUTE_NAME = value; }
        public string BATCH_ID { get => m_BATCH_ID; set => m_BATCH_ID = value; }
        public int QTY { get => m_QTY; set => m_QTY = value; }
    }
}

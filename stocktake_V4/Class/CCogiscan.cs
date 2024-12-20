using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using stocktake_V4.Class;
using stocktake_V4.wsCogiscan;
using System.Windows.Forms;

namespace stocktake_V4.Class
{
    public class CCogiscan
    {
        private wsCogiscan.RPCServices rPCServices;
        private String xml = "";

        public RPCServices RPCServices { get => rPCServices; set => rPCServices = value; }

        public CCogiscan()
        {
            rPCServices = new wsCogiscan.RPCServicesClient();
        }

        public CModelInfo query_item(String item)
        {
            String parameters = "<Parameter name=\"itemId\">" + item + "</Parameter>";
            String xml = "";
            NotifyIcon not = new NotifyIcon();
            CModelInfo model = new CModelInfo();
            try
            {

                xml = rPCServices.executeCommand("queryItem", "<Parameters>" + parameters + "</Parameters>");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlElement root = doc.DocumentElement;
                XmlNode product = root.SelectSingleNode("Product");
                if (product != null)
                {
                    model.BatchId = product.Attributes["batchId"].Value;
                    model.Operation = product.Attributes["operation"].Value;
                    model.Status = product.Attributes["status"].Value;
                    model.Route = product.Attributes["releaseRouteName"].Value;
                    model.PartNumber = product.Attributes["partNumber"].Value;
                    model.REV = product.Attributes["revision"].Value;

                    //not.BalloonTipIcon = ToolTipIcon.Info;
                    not.Text = "QUERY COGISCAN";
                    not.Visible = true;
                    //not.ShowBalloonTip(1000);
                }
                else
                    model.BatchId = "NG";

            }
            catch (Exception ex)
            {
                model.BatchId = ex.Message;
                model.DjNumber = "false";
            }

            return model;
        }
        public List<String> get_panel(String item)
        {
            String parameters = "<Parameter name=\"barcode\">" + item + "</Parameter>";
            String panelID = "NOT_FOUND";
            String xml = "";
            List<String> serials = new List<String>();

            CModelInfo model = new CModelInfo();
            try
            {
                xml = rPCServices.executeCommand("queryProductGroup", "<Parameters>" + parameters + "</Parameters>");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlElement root = doc.DocumentElement;

                try
                {
                    panelID = root.Attributes["barcode"].Value;
                    serials.Add(panelID);
                }
                catch(Exception ex) { }
                XmlNodeList nodes = root.SelectNodes("Product");


                foreach (XmlNode node in nodes)
                {
                    serials.Add(node.InnerText);
                }

            }
            catch (Exception ex)
            {
                panelID = "NOT_FOUND";
            }

            return serials;
        }
        public String startOperation(String serial, String toolId, String operationName)
        {
            xml = rPCServices.executeCommand("startOperation", "<Parameters>"
                + "<Parameter name=\"productId\">" + serial + "</Parameter>"
                + "<Parameter name=\"operationName\">" + operationName + "</Parameter>"
                + "<Parameter name=\"toolId\">" + toolId + "</Parameter>"
                + "</Parameters>");

            return xml;
        }
        public String endOperation(String serial, String tool, String operationName)
        {

            //"endOperation","<Parameters><Parameter name=\"productId\">" + serial[x] + "</Parameter><Parameter name=\"operationName\">" + osmt + "</Parameter></Parameters>"
            xml = rPCServices.executeCommand("endOperation", "<Parameters>"
                + "<Parameter name=\"productId\">" + serial + "</Parameter>"
                + "<Parameter name=\"operationName\">" + operationName + "</Parameter>"
                + "</Parameters>");
            return xml;
        }
        public String setProcessStepStatus(String serial, String line, bool result)
        {
            if (result == true)
                xml = rPCServices.executeCommand("setProcessStepStatus", "<Parameters>"
                    + "<Extensions><ProcessStepStatus itemInstanceId=\"" + serial + "\" processStepId=\"" + line + "\" status=\"" + "PASSED" + "\" /></Extensions>"
                    + "</Parameters>");
            else
                xml = rPCServices.executeCommand("setProcessStepStatus", "<Parameters>"
                    + "<Extensions><ProcessStepStatus itemInstanceId=\"" + serial + "\" processStepId=\"" + line + "\" status=\"" + "FAILED" + "\" >"
                    + "<Indictment  indictmentId = \"" + serial + "\" description = \"Test " + serial + " failed.\"/>"
                    + "</ProcessStepStatus></Extensions>"
                    + "</Parameters>");

            return xml;

        }
        public String Release(CReleaseInfo serial)
        {
            String extensions = "";
            String result = "";
            string parameters = "<Parameter name=\"assembly\">" + serial.PRODUCT_PN + "</Parameter>";
            parameters += "<Parameter name=\"revision\">" + serial.PRODUCT_PN_REV + "</Parameter>";
            parameters += "<Parameter name=\"route\">" + serial.ROUTE_NAME + "</Parameter>";
            parameters += "<Parameter name=\"batchId\">" + serial.BATCH_ID + "</Parameter>";
            parameters += "<Parameter name=\"maxReleaseQty\">" + (serial.QTY + 2).ToString() + "</Parameter>";

            if (!String.IsNullOrEmpty(serial.PANEL_ID)) extensions += "<Extensions><ProductGroup barcode=\"" + serial.PANEL_ID + "\">";
            else extensions += "<Extensions><ProductGroup>";

            extensions += 
                    "<Product location=\"A1\">"+serial.PRODUCT_ID+"</Product>" +
                "</ProductGroup>" +
              "</Extensions>";
            string allPar = parameters + extensions;
            result = rPCServices.executeCommand("releaseProduct", "<Parameters>" + allPar + "</Parameters>");
            return result;
        }
    }
}
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _03_XMLTree
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_OnClick(object sender, EventArgs e)
        {
            var fu = this.FileUpload;
            if (fu.HasFile && fu.PostedFile.ContentType == "text/xml")
            {
                try
                {
                    var xml = string.Empty;
                    using (var reader = new StreamReader(fu.FileContent))
                    {
                        do
                        {
                            xml = xml + reader.ReadLine() + Environment.NewLine;
                        } while (reader.Peek() != -1);
                    }

                    var doc = new XmlDocument();
                    doc.LoadXml(xml);
                    this.ShowMessage(doc.OuterXml);

                    this.ResultTreeView.Nodes.Clear();
                    this.ResultTreeView.Nodes.Add(new TreeNode(doc.DocumentElement?.Name));
                    var tNode = this.ResultTreeView.Nodes[0];
                    tNode.Value = doc.OuterXml;
                    this.AddNode(doc.DocumentElement, tNode);
                }
                catch (XmlException xmlEx)
                {
                    this.ShowMessage(xmlEx.Message);
                }
                catch (Exception ex)
                {
                    this.ShowMessage(ex.Message);
                }
            }
            else
            {
                this.ShowMessage("Invalid file!");
            }
        }

        protected void ResultTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            var treeView = sender as TreeView;

            this.ShowMessage(treeView?.SelectedValue);
        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            if (inXmlNode.HasChildNodes)
            {
                var nodeList = inXmlNode.ChildNodes;
                int i;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    var xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.ChildNodes.Add(new TreeNode(xNode.Name));
                    var tNode = inTreeNode.ChildNodes[i];
                    tNode.Value = xNode.OuterXml;
                    this.AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        private void ShowMessage(string s)
        {
            this.ExpandedResultLiteral.Text = s ?? string.Empty;
        }
    }
}

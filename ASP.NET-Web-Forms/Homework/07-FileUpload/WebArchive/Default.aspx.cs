using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ionic.Zip;

using WebArchive.Data;
using WebArchive.Data.Models;

using File = WebArchive.Data.Models.File;

namespace WebArchive
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadButton_OnClick(object sender, EventArgs e)
        {
            if (this.FileControl.HasFile)
            {
                var filename = Path.GetFileName(this.FileControl.FileName);
                if (filename != null && filename.EndsWith(".zip"))
                {
                    byte[] fileData = null;
                    if (this.FileControl.HasFile)
                    {
                        var length = this.FileControl.PostedFile.ContentLength;
                        fileData = new byte[length + 1];
                        var fileStream = this.FileControl.PostedFile.InputStream;
                        fileStream.Read(fileData, 0, length);
                    }

                    if (fileData != null)
                    {
                        var ds = new ArchiveDbContext();
                        using (var inputStream = new MemoryStream(fileData))
                        {
                            using (var zip = ZipFile.Read(inputStream))
                            {
                                foreach (var zipEntry in zip.Entries.Where(entry => entry.FileName.EndsWith(".txt")))
                                {
                                    using (var outputStream = new MemoryStream())
                                    {
                                        zipEntry.Extract(outputStream);
                                        outputStream.Position = 0;
                                        var sr = new StreamReader(outputStream);
                                        var fileContents = sr.ReadToEnd();
                                        var file = new File()
                                                   {
                                                       FileName = zipEntry.FileName,
                                                       ArchiveName = filename,
                                                       Content = fileContents
                                                   };
                                        ds.Files.Add(file);
                                    }
                                }
                            }
                        }

                        ds.SaveChanges();
                    }
                }
                else
                {
                    this.Notification.Text = "Please select a valid .zip file!";
                    this.Notification.Visible = true;
                }
            }
            else
            {
                this.Notification.Text = "Please select a file!";
                this.Notification.Visible = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace PDFOptimiser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOptimise_Click(object sender, EventArgs e)
        {

        }

        private void btnOptimiseParallel_Click(object sender,EventArgs e)
        {
            if (Directory.Exists(tboxPath.Text))
            {
                Int64 PDFsFound = 0;
                Int64 PDFsOptimised = 0;

                // Construct a ConcurrentQueue.
                ConcurrentQueue<string> cq = new ConcurrentQueue<string>();

                // Populate the queue.
                foreach (string PDFFile in Directory.EnumerateFiles(tboxPath.Text, "*.pdf", SearchOption.AllDirectories))
                {
                    cq.Enqueue(PDFFile);
                }

                // Start parallel processing
                Parallel.ForEach<string>(cq, action =>
                {
                    string localValue;
                    Interlocked.Increment(ref PDFsFound);
                    try
                    {
                        while (cq.TryDequeue(out localValue)) gsOptimise(localValue);
                        Interlocked.Increment(ref PDFsOptimised);
                    }
                    catch
                    {

                    }

                });
                tboxFound.Text = PDFsFound.ToString();
                tboxOptimised.Text = PDFsOptimised.ToString();
                MessageBox.Show("Done");
            }
            
        }
        private void gsOptimise(string PDFFile, ref Int64 PDFsFound, ref Int64 PDFsOptimised, ref StringBuilder log)
        {
            try
            {
                PDFsFound++;

                string outputPDF = PDFFile + ".new";

                // Use ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = true;
                startInfo.FileName = "gswin32c.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-q -dBATCH -dNOPAUSE -dCompatibilityLevel=1.4 -dPDFSETTINGS=/ebook -dFastWebView=true -sDEVICE=pdfwrite -sOutputFile=\"" + outputPDF + "\" \"" + PDFFile + "\"";

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    log.AppendLine(PDFFile + "\tGS error: " + ex.Message);
                }

                if (File.Exists(outputPDF) && File.Exists(PDFFile))
                {
                    File.Move(PDFFile, PDFFile + ".old");
                    File.Move(outputPDF, PDFFile);
                }

                PDFsOptimised++;
            }
            catch (Exception ex)
            {
                log.AppendLine(PDFFile + "\t" + ex.Message);
            }
        }
        private void gsOptimise(string PDFFile)
        {
            try
            {
       
                string outputPDF = PDFFile + ".new";

                // Use ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = true;
                startInfo.FileName = "gswin32c.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = "-q -dBATCH -dNOPAUSE -dCompatibilityLevel=1.4 -dPDFSETTINGS=/ebook -dFastWebView=true -sDEVICE=pdfwrite -sOutputFile=\"" + outputPDF + "\" \"" + PDFFile + "\"";

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    //log.AppendLine(PDFFile + "\tGS error: " + ex.Message);
                }

                if (File.Exists(outputPDF) && File.Exists(PDFFile))
                {
                    File.Move(PDFFile, PDFFile + ".old");
                    File.Move(outputPDF, PDFFile);
                }

            }
            catch (Exception ex)
            {
                //log.AppendLine(PDFFile + "\t" + ex.Message);
            }
        }
        private void iTextOptimise(string PDFFile,ref Int64 PDFsFound,ref Int64 PDFsOptimised,ref StringBuilder log)
        {
            //try
            //        {
            //    PDFsFound++;

            //    //string outputDirectory = Path.GetDirectoryName(PDFFile) + "_NEW";
            //    //if (!Directory.Exists(outputDirectory))
            //    //    Directory.CreateDirectory(outputDirectory);
            //    //string outputPDF = outputDirectory + "\\" + Path.GetFileName(PDFFile);
            //    string outputPDF = PDFFile + ".new";
            //    PdfReader reader = new PdfReader(PDFFile);
            //    MemoryStream ms = new MemoryStream();
            //    PdfStamper stamper = new PdfStamper(reader, new FileStream(outputPDF, FileMode.CreateNew), '7');
            //    stamper.SetFullCompression();
            //    stamper.Close();
            //    ms.Flush();
            //    reader.Close();

            //    if (File.Exists(outputPDF) && File.Exists(PDFFile))
            //    {
            //        File.Move(PDFFile, PDFFile + ".old");
            //        File.Move(outputPDF, PDFFile);
            //    }

            //    PDFsOptimised++;
            //}
            //        catch (Exception ex)
            //        {
            //    log.AppendLine(PDFFile + "\t" + ex.Message);
            //}
        }
    }
}

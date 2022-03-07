#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using StarMicronics.CloudPrnt;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace TodoApi.Controllers
{
    [Route("api/TodoItems")]
    //[ApiController]
    public class TodoItemsController : ControllerBase
    {



        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostTodoItem()
        {
            return Ok(new { jobReady = true, mediaTypes = new string[] { "application/vnd.star.starprnt" } });
        }



        // GET: api/TodoItems
        [HttpGet]
        public IActionResult GetTodoItems()
        {

            //print star markup doc
            //StringBuilder job = new StringBuilder();
            //job.Append("Hello World!\n");
            //job.Append("[barcode: type code39; data 12345; height 10mm]\n");
            //job.Append("[align: center]");
            //job.Append("[logo: key 01; s 1]\\");
            //byte[] jobData = Encoding.UTF8.GetBytes(job.ToString());


            //string center = "[align: center]\n";
            //string left = "[align: left]\n";
            //string divider = "________________________________________________\n";
            //string itemsHeading = "[bold: on]\nSales\n[bold: off]\n";
            //double subtotal = 0.00;
            //double taxtotal = 0.00;
            //double discountTotal = 0.00;
            //double totalDue = (subtotal + taxtotal) - discountTotal;



            //string test = "";
            //test += center;
            //test += "Hello World!\n";

            //test += divider;
            //test += left;
            //test += "[barcode: type code39; data 12345; height 10mm]\n";

            //test += divider;
            //test += itemsHeading;
            //test += totalDue;

            //var jobData1 = Encoding.UTF8.GetBytes(test);

            //string path = @"/Users/oreo/Projects/TodoApi/TodoApi";




            //string outputFormat = "application/vnd.star.starprnt";

            //var outputData = new MemoryStream(0);

            //Document.Convert(jobData, "text/vnd.star.markup", outputData, outputFormat, null);
            //StreamReader reader = new StreamReader(outputData);
            //outputData.Seek(0, SeekOrigin.Begin);
            //var response = reader.ReadToEnd();
            //System.Diagnostics.Debug.WriteLine(response);



            //print plain text directly
            //string message = "Hello World\nHello World\n";
            //return Ok(message)


            FileStream s2 = new FileStream("markup.stm", FileMode.Open, FileAccess.Read, FileShare.Read);
            

            var outputFormat1 = "application/vnd.star.starprnt";

            var outputData1 = new MemoryStream(0);

            Document.Convert(bytes, "text/vnd.star.markup", outputData1, outputFormat1, null);

            StreamReader reader = new StreamReader(outputData1);
            outputData1.Seek(0, SeekOrigin.Begin);
            var response = reader.ReadToEnd();

            return Ok(response);

        }

        

        
        //DELETE:
        [HttpDelete]
        public IActionResult DeleteTodoItem()
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            return Ok(response);
        }
    }
}

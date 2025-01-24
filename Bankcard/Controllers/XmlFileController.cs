using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Bankcard.Models;

namespace Bankcard.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class XmlFileController : ControllerBase
    {
        [HttpGet("{Id}")]
        public ActionResult<string> WriteXml(string Id)
        {
            XDocument doc = new XDocument(
                new XElement("Root",
                    new XElement("long", "3"),
                    new XElement("lati", "4")
                ));
            doc.Save(Id + ".xml");

            return "Successfully";
            //return Ok(("status= true", "message= Successfully"));
        }

        [HttpGet("{Id}")]
        public ActionResult<LocationItems> ReadXml(string Id)
        {
            LocationItems items = new LocationItems();
            XDocument doc = XDocument.Load(Id+".xml");
            foreach (var e in doc.Elements("Root"))
            {
                items = new LocationItems {myLongitude=e.Element("long").Value,myLatitude=e.Element("lati").Value };
            }
            return items;
        }
    }
}
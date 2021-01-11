using CovidRecordLib;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CovidService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidRecordsController : ControllerBase
    {
        private static readonly List<CovidRecord> covidRecords = new List<CovidRecord>()
        {
            new CovidRecord(1, "Rungsted Kyst", 4, 2, 1),
            new CovidRecord(2, "Kirke Eskilstrup", 4, 3, 0),
            new CovidRecord(3, "Roskilde", 4, 4, 1),
            new CovidRecord(4, "Taastrup", 5, 5, 0),
            new CovidRecord(5, "Roskilde", 23, 14, 3)
        };


        // GET: api/<CovidRecordsController>
        [HttpGet]
        public IEnumerable<CovidRecord> GetAll()
        {
            return covidRecords;
        }

        // GET api/<CovidRecordsController>/5
        [HttpGet]
        [Route("{id}")]
        public CovidRecord GetById(int id)
        {
            return covidRecords.Find(c => c.Id == id);
        }

        [HttpGet]
        [Route("City/{city}")]
        public IEnumerable<CovidRecord> GetRecordsByCity(string city)
        {
            List<CovidRecord> lCovidRecords = covidRecords.FindAll(c => c.City.Contains(city));
            return lCovidRecords;
        }

        [HttpGet]
        [Route("Household/{household}")]
        public IEnumerable<CovidRecord> GetRecordsByHoushold(int household)
        {
            List<CovidRecord> lCovidRecords = covidRecords.FindAll(c => c.Household.Equals(household));
            return lCovidRecords;
        }

        // POST api/<CovidRecordsController>
        [HttpPost]
        public int AddRecord([FromBody] CovidRecord covidRecord)
        {
            covidRecords.Add(covidRecord);
            int newId = covidRecords.Max(c => c.Id) + 1;
            covidRecord.Id = newId;
            return newId;
        }

        //// PUT api/<CovidRecordsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CovidRecordsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

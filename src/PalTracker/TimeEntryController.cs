using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private ITimeEntryRepository _iTimeEntryRepository;
        public TimeEntryController(ITimeEntryRepository iTimeEntryRepository)
        {
            _iTimeEntryRepository = iTimeEntryRepository;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long Id)
        {
            return _iTimeEntryRepository.Contains(Id)?(IActionResult)Ok(_iTimeEntryRepository.Find(Id)):NotFound();
        }       


        [HttpPost]
        public IActionResult Create([FromBody]TimeEntry timeEntry)
        {
            TimeEntry createdTimeEntry = _iTimeEntryRepository.Create(timeEntry);           
            return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
        }

        [HttpGet]
        public IActionResult List()
        {
            var timeEntriesList = _iTimeEntryRepository.List();
            return Ok(timeEntriesList);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long Id, [FromBody]TimeEntry timeEntry)
        {
           if(_iTimeEntryRepository.Contains(Id))
           {
                return Ok(_iTimeEntryRepository.Update(Id, timeEntry));
           }   
           return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long Id)
        {
           if(_iTimeEntryRepository.Contains(Id))
           {
               _iTimeEntryRepository.Delete(Id);
                return NoContent();
           }   
           return NotFound();
        }

    }
}
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _iTimeEntryRepository;
        private readonly IOperationCounter<TimeEntry> _operationCounter;

        public TimeEntryController(ITimeEntryRepository iTimeEntryRepository, IOperationCounter<TimeEntry> operationCounter)
        {
            _iTimeEntryRepository = iTimeEntryRepository;
            _operationCounter = operationCounter;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long Id)
        {
             _operationCounter.Increment(TrackedOperation.Read);
            return _iTimeEntryRepository.Contains(Id)?(IActionResult)Ok(_iTimeEntryRepository.Find(Id)):NotFound();
        }       


        [HttpPost]
        public IActionResult Create([FromBody]TimeEntry timeEntry)
        {
             _operationCounter.Increment(TrackedOperation.Create);
            TimeEntry createdTimeEntry = _iTimeEntryRepository.Create(timeEntry);           
            return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
        }

        [HttpGet]
        public IActionResult List()
        {
            _operationCounter.Increment(TrackedOperation.List);
            var timeEntriesList = _iTimeEntryRepository.List();
            return Ok(timeEntriesList);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long Id, [FromBody]TimeEntry timeEntry)
        {
            _operationCounter.Increment(TrackedOperation.Update);
           if(_iTimeEntryRepository.Contains(Id))
           {
                return Ok(_iTimeEntryRepository.Update(Id, timeEntry));
           }   
           return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long Id)
        {
            _operationCounter.Increment(TrackedOperation.Delete);
           if(_iTimeEntryRepository.Contains(Id))
           {
               _iTimeEntryRepository.Delete(Id);
                return NoContent();
           }   
           return NotFound();
        }

    }
}
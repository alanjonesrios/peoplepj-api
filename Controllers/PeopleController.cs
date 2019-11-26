using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using peoplepj.Models;
using peoplepj.Repository;

namespace peoplepj.Controllers
{
  [Route("api/[Controller]")]
  public class PeopleController : Controller
  {
    private readonly IPersonRepository _personRepository;

    public PeopleController(IPersonRepository personRepo)
    {
      _personRepository = personRepo;
    }

    [HttpGet]
    public IEnumerable<Person> GetAll()
    {
      return _personRepository.GetAll();
    }

    [HttpGet("{id}", Name = "GetPerson")]
    public IActionResult GetById(long id)
    {
      var person = _personRepository.Find(id);
      if (person == null)
        return NotFound();

      return new ObjectResult(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
      if (person == null)
        return BadRequest();

      _personRepository.Add(person);

      return CreatedAtRoute("GetPerson", new { id = person.PersonId }, person);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Person person)
    {
      if (person == null)
        return BadRequest();

      var _person = _personRepository.Find(id);

      if (_person == null)
        return NotFound();

      _person.Name = person.Name;

      _personRepository.Update(_person);

      return AcceptedAtRoute("GetPerson", new { id = _person.PersonId }, _person);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var person = _personRepository.Find(id);

      if (person == null)
        return NotFound();

      _personRepository.Remove(id);

      return new NoContentResult();
    }
  }
}
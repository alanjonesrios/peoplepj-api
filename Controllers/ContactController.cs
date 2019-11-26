using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using peoplepj.Models;
using peoplepj.Repository;

namespace peoplepj.Controllers
{
  [Route("api/[Controller]")]
  public class ContactController : Controller
  {
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepo)
    {
      _contactRepository = contactRepo;
    }

    [HttpGet]
    public IEnumerable<Contact> GetAll()
    {
      return _contactRepository.GetAll();
    }

    [HttpGet("{id}", Name = "GetContact")]
    public IActionResult GetById(long id)
    {
      var contact = _contactRepository.Find(id);
      if (contact == null)
        return NotFound();

      return new ObjectResult(contact);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Contact[] contacts)
    {
      if (contacts == null)
        return BadRequest();

      foreach (Contact contact in contacts)
      {
        _contactRepository.Add(contact);
      }
      return CreatedAtRoute("Getcontact", new { id = contacts.Count() }, contacts);
    }

    [HttpPut("{id}")]
    public IActionResult Update(long id, [FromBody] Contact[] contacts)
    {
      if (contacts == null)
        return BadRequest();

      foreach (Contact contact in contacts)
      {
        var _contact = _contactRepository.Find(contact.ContactId);

        if (_contact != null)
        {
          _contact.Type = contact.Type;
          _contact.Value = contact.Value;

          _contactRepository.Update(_contact);
        }
        else
        {
          _contactRepository.Add(contact);
        }
      }

      return AcceptedAtRoute("Getcontact", new { id = contacts.Count() }, contacts);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      var contact = _contactRepository.Find(id);

      if (contact == null)
        return NotFound();

      _contactRepository.Remove(id);

      return new NoContentResult();
    }

  }
}
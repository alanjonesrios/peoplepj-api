using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using peoplepj.Models;

namespace peoplepj.Repository
{
  public class PersonRepository : IPersonRepository
  {
    private readonly ApplicationDbContext _context;
    public PersonRepository(ApplicationDbContext ctx)
    {
      this._context = ctx;
    }
    public void Add(Person person)
    {
      _context.People.Add(person);
      _context.SaveChanges();
    }

    public Person Find(long id)
    {
      return _context.People.Include(person => person.Contacts).FirstOrDefault(p => p.PersonId == id);
    }

    public IEnumerable<Person> GetAll()
    {
      return _context.People.Include(person => person.Contacts).ToList();
    }

    public void Remove(long id)
    {
      var entity = _context.People.First(p => p.PersonId == id);
      _context.People.Remove(entity);
      _context.SaveChanges();
    }

    public void Update(Person person)
    {
      _context.People.Update(person);
      _context.SaveChanges();
    }
  }
}
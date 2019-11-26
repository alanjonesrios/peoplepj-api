using System.Collections.Generic;
using System.Linq;
using peoplepj.Models;

namespace peoplepj.Repository
{
  public class ContactRepository : IContactRepository
  {
    private readonly ApplicationDbContext _context;
    public ContactRepository(ApplicationDbContext ctx)
    {
      this._context = ctx;
    }
    public void Add(Contact contact)
    {
      _context.Contacts.Add(contact);
      _context.SaveChanges();

    }

    public Contact Find(long id)
    {
      return _context.Contacts.FirstOrDefault(p => p.ContactId == id);
    }

    public IEnumerable<Contact> GetAll()
    {
      return _context.Contacts.ToList();
    }

    public void Remove(long id)
    {
      var entity = _context.Contacts.First(p => p.ContactId == id);
      _context.Contacts.Remove(entity);
      _context.SaveChanges();
    }

    public void Update(Contact contact)
    {
      _context.Contacts.Update(contact);
      _context.SaveChanges();
    }
  }
}
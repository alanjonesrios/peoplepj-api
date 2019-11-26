using System.Collections.Generic;
using peoplepj.Models;

namespace peoplepj.Repository
{
  public interface IContactRepository
  {
    void Add(Contact contacts);

    IEnumerable<Contact> GetAll();

    Contact Find(long id);

    void Remove(long id);

    void Update(Contact contact);
  }
}
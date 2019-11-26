using System.Collections.Generic;

namespace peoplepj.Models
{
  public class Person
  {
    public int PersonId { get; set; }

    public string Name { get; set; }

    public List<Contact> Contacts { get; set; }
  }
}
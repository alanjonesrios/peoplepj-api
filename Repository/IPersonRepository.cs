using System.Collections.Generic;
using peoplepj.Models;

namespace peoplepj.Repository {
    public interface IPersonRepository {
        void Add (Person person);

        IEnumerable<Person> GetAll ();

        Person Find (long id);

        void Remove (long id);

        void Update (Person person);
    }
}
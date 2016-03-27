using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrightStarSample
{
    public class PersonDataBase
    {
        private readonly string _connectionString;
        private MyEntityContext _context;

        public PersonDataBase()
        {
            _connectionString = DependencyService.Get<IBrightStarConnectionStringProvider>().GetConnectionString();
            _context = new MyEntityContext(_connectionString);
        }

        public IEnumerable<IPerson> GetItems()
        {
            return _context.Persons.ToList();
        }

        public IPerson GetItem(string name)
        {
            if (name == null) return null;
            return _context.Persons.FirstOrDefault(x => x.Name.Equals(name));
        }

        public string SaveItem (Person item)
        {
            var exists = this.GetItem(item.Name);
            if (exists == null) {
                _context.Persons.Add(item);
            } else {
                exists.Age = item.Age;
            }
            _context.SaveChanges();
            return item.Name;
        }

        public int DeleteItem(string name)
        {
            var toDelete = _context.Persons.FirstOrDefault(x => x.Name.Equals(name));
            if (toDelete == null) return 0;
            _context.DeleteObject(toDelete);
            _context.SaveChanges();
            return 1;
        }
    }
}

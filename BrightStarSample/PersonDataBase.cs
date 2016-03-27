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

        public IPerson GetItem(string id)
        {
            return _context.Persons.FirstOrDefault(x => x.ID.Equals(id));
        }

        public string SaveItem (Person item)
        {
            if (item.ID == null)
            {
                _context.Persons.Add(item);
            }
            _context.SaveChanges();
            return item.ID;
        }

        public int DeleteItem(string id)
        {
            var toDelete = _context.Persons.FirstOrDefault(x => x.ID.Equals(id));
            if (toDelete == null) return 0;
            _context.DeleteObject(toDelete);
            _context.SaveChanges();
            return 1;
        }
    }
}

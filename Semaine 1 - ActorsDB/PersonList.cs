using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.ipl.domaine;

    internal class PersonList
    {

	// ? -> nullable field
	private static PersonList? _instance = null;
	// map -> IDictionnary
	// hashmap -> Dictionnary
		private IDictionary<string, Person> personMap;

		private PersonList()
		{
			personMap = new Dictionary<string, Person>();
		}

		public static PersonList getInstance()
		{

			if (_instance == null)
				_instance = new PersonList();

			return _instance;
		}

		public void AddPerson(Person person)
		{
			if (person == null)
				throw new ArgumentException();
			personMap.Add(person.Name, person);
		}

		public IEnumerator<Person> personList()
		{
			return personMap.Values.GetEnumerator();
		}

	}

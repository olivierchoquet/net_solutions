using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.ipl.domaine;

[Serializable]
    internal class Person
    {

	private readonly string _name;
	private readonly string _firstname;
	private readonly DateTime _birthDate;


	// virtual allow child classes to redefine -> default behavior in Java (always virtual in Java)
    public virtual string Name { get { return _name; } }

	public string Firstname { get { return _firstname; } }


	public string BirthDate { get { return _birthDate.ToString(); } }
	


	public Person(string name, string firstname, DateTime birthDate)
	{
		this._name = name;
		this._firstname = firstname;
		this._birthDate = birthDate;
	}


	public override string ToString()
	{
		return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate =  " + BirthDate + "]";
	}


}

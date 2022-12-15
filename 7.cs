using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Console;

namespace DesignPattern1
{
	public enum Relationship
	{
		Parent,
		Child,
		Sibling
	}
	public class Person
	{
		public string name;
	}

	public interface IRelationshipBrowser
	{
		IEnumerable<Person> FindAllChildrenOf(string name);
	}

	// low-level
	public class Relationships : IRelationshipBrowser
	{
		private List<(Person, Relationship, Person)> relations =
			new List<(Person, Relationship, Person)>();
		public void AddParentAndChild(Person parent, Person child)
		{
			relations.Add((parent, Relationship.Parent, child));
			relations.Add((child, Relationship.Child, parent));
		}

		public IEnumerable<Person> FindAllChildrenOf(string name)
		{
			return relations.Where(
				x => x.Item1.name == name && x.Item2 == Relationship.Parent
				).Select(r => r.Item3);
		}

		public List<(Person, Relationship, Person)> Relations => relations;
	}

	
	public class Research
	{
		public Research(IRelationshipBrowser browser)
		{
			foreach (var p in browser.FindAllChildrenOf("John"))
			{
				WriteLine($"John has a child called {p.name}");
			}
		}
		static void Main(string[] args)
		{
			var parent = new Person { name = "John" };

			var child1 = new Person { name = "chris" };
			var child2 = new Person { name = "mary" };
			var relationships = new Relationships();
			relationships.AddParentAndChild(parent, child1);
			relationships.AddParentAndChild(parent, child2);
			new Research(relationships);
		}
	}
}

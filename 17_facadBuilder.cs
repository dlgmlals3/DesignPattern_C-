using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPattern1
{

	public class Person
	{
		public string StreetAddress, Postcode, City;
		public string Companyname, Position;
		public int AnnualIncome;
		public override string ToString()
		{
			return $"{nameof(StreetAddress)} : {StreetAddress}, {nameof(Companyname)} : {Companyname} ";
		}
	}

	public class PersonBuilder
	{
		protected Person person = new Person();

		public PersonJobBuilder works => new PersonJobBuilder(person);
		public PersonAddressBuilder lives => new PersonAddressBuilder(person);

		public static implicit operator Person(PersonBuilder pb)
		{
			return pb.person;
		}		
	}

	public class PersonJobBuilder : PersonBuilder
	{
		public PersonJobBuilder(Person person)
		{
			this.person = person;
		}
		public PersonJobBuilder At(string compnayName)
		{
			person.Companyname = compnayName;
			return this;
		}
		public PersonJobBuilder AsA(string position)
		{
			person.Position = position;
			return this;
		}
	}
	public class PersonAddressBuilder : PersonBuilder
	{
		public PersonAddressBuilder(Person person)
		{
			this.person = person;
		}
		public PersonAddressBuilder At(string StreetAddress)
		{
			person.StreetAddress = StreetAddress;
			return this;
		}
	}


	public class Program
	{
		static void Main(string[] args)
		{
			var pb = new PersonBuilder();
			Person person = pb.works.At("LG")
			  .AsA("Engineer")
			  .lives.At("Seoul");

			WriteLine(person);
		}
	}
}

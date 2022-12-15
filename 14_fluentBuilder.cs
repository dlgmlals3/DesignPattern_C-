﻿using System;
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
		public string Name;
		public string Position;

		public class Builder : PersonJobBuilder<Builder>
		{			
		}
		public static Builder New => new Builder();

		public override string ToString()
		{
			return $"{nameof(Name)} : {Name}, {nameof(Position)}: {Position}";
		}
	}

	public abstract class PersonBuilder
	{
		protected Person person = new Person();
		public Person Build()
		{
			return person;
		}
	}

	public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
	{
		public SELF called(string name)
		{
			person.Name = name;
			return (SELF) this;
		}
	}

	public class PersonJobBuilder<SELF> 
		: PersonInfoBuilder<PersonJobBuilder<SELF>>
		where SELF : PersonJobBuilder<SELF>
	{
		public SELF WorksAsA(string position)
		{
			person.Position = position;
			return (SELF) this;
		}
	}


	public class Program
	{		
		static void Main(string[] args)
		{
			var me = Person.New
				.called("dmitri")
				.WorksAsA("quant")
				.Build();
			WriteLine(me);
		}
	}
}
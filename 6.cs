using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace DesignPattern1
{
	public class Document
	{

	}
	public interface IMachine
	{
		void Print(Document d);
		void Scan(Document d);
		void Fax(Document d);
	}

	public class MultiFunctionPrinter : IMachine
	{
		public void Fax(Document d)
		{
			//
		}

		public void Print(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}
	}

	public class OldFashionPrinter : IMachine
	{
		public void Fax(Document d)
		{
			//
		}

		public void Print(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}
	}
	public interface IPrinter
	{
		void Print(Document d);
	}
	public interface IScanner
	{
		void Scan(Document d);
	}

	public class Photocopier : IPrinter, IScanner
	{
		public void Print(Document d) { WriteLine("Print"); }

		public void Scan(Document d) { WriteLine("Scan"); }
	}
	public interface IMultiFunctionDevice : IScanner, IPrinter // ....
	{

	}
	public class MultiFunctionMachine : IMultiFunctionDevice
	{
		private IPrinter printer;
		private IScanner scanner;

		public MultiFunctionMachine(IPrinter printer, IScanner scanner)
		{
			this.printer = printer;
			this.scanner = scanner;
		}

		public void Print(Document d)
		{
			printer.Print(d);
		}

		public void Scan(Document d)
		{
			scanner.Scan(d);
		} // decorator pattern
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			Photocopier copier = new Photocopier();
			MultiFunctionMachine machine = new MultiFunctionMachine(copier, copier);
			machine.Print(null);
			machine.Scan(null);
		}
	}
}

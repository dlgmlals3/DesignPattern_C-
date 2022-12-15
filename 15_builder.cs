using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPattern1
{
	public enum CarType
	{
		Sedan,
		Crossover
	}

	public class Car
	{
		public CarType Type;
		public int WheelSize;
	}

	public interface ISpecifyCarType
	{
		ISpecifyWheelSize OfType(CarType type);
	}

	public interface ISpecifyWheelSize
	{
		IBuilderCar WithWheels(int size);
	}

	public interface IBuilderCar
	{
		Car Build();
	}

	public class CarBuilder
	{
		private class Impl :
			ISpecifyCarType,
			ISpecifyWheelSize,
			IBuilderCar
		{
			private Car car = new Car();

			public ISpecifyWheelSize OfType(CarType type)
			{
				car.Type = type;
				return this;
			}

			public IBuilderCar WithWheels(int size)
			{
				switch (car.Type)
				{
					case CarType.Crossover when size < 17 || size > 20:
					case CarType.Sedan when size < 15 || size > 17:
						throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
				}
				car.WheelSize = size;
				return this;
			}
			public Car Build()
			{
				return car;
			}

		}
		public static ISpecifyCarType Create()
		{
			return new Impl();
		}
	}

	public class Program
	{		
		static void Main(string[] args)
		{
			var car = CarBuilder.Create()
				.OfType(CarType.Crossover)
				.WithWheels(18)
				.Build();
		}
	}
}

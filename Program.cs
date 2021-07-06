using System;

namespace Fibonacci
{
	class Program
	{
		private static ulong[] _sequency;

		static void Main(string[] args)
		{
			bool end = false;

			do
			{
				Console.Clear();
				Console.Write("How many interactions?\n-> ");

				if (!ulong.TryParse(Console.ReadLine(), out ulong interactions))
					Console.WriteLine("Invalid input");

				else
				{
					PopulateSequence(interactions);

					Console.Write("\nGo again (y/n)?\n-> ");
					end = Console.ReadLine().ToLower() != "y";
				}

				Console.WriteLine("\nPress any key...");
				Console.ReadKey();

			} while (!end);
		}

		public static ulong CalculateFibonacciValue(ulong value)
		{
			if (_sequency[value] != 0)
				value = _sequency[value];

			else if (value != 0 && value != 1)
				value = CalculateFibonacciValue(value - 1) + CalculateFibonacciValue(value - 2);

			return value;
		}

		public static void PopulateSequence(ulong size)
		{
			_sequency = new ulong[size + 1];

			for (ulong index = 0; index <= size; index++)
			{
				_sequency[index] = CalculateFibonacciValue(index);
				Console.WriteLine($"{index} - {_sequency[index]}");
			}
		}
	}
}

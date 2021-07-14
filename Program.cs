using System;

namespace Fibonacci
{
	class Program
	{
		private static ulong[] _sequence;

		static void Main(string[] args)
		{
			bool end = false;

			do
			{
				Console.Clear();
				Console.Write("How many interactions?\n-> ");

				if (!ulong.TryParse(Console.ReadLine(), out ulong interactions))
					Console.WriteLine("\nInvalid input");

				else
				{
					_calculateSequence(interactions);

					Console.Write("\nGo again (y/n)?\n-> ");
					end = Console.ReadLine().ToLower() != "y";
				}

				Console.WriteLine("\nPress any key...");
				Console.ReadKey();

			} while (!end);
		}

		private static bool _calculateFibonacciValue(ulong value)
		{
			bool canCalculate = true;

			if (value != 0 && value != 1)
				if (ulong.MaxValue - _sequence[value - 1] > _sequence[value - 2])
					_sequence[value] = _sequence[value - 1] + _sequence[value - 2];

				else
					canCalculate = false;

			return canCalculate;
		}

		private static void _calculateSequence(ulong size)
		{
			_sequence = _initializeSequence(size);

			bool canCalculate = true;

			for (ulong index = 0; index <= size && canCalculate; index++)
			{
				canCalculate = _calculateFibonacciValue(index);

				if (canCalculate)
					Console.WriteLine($"{index} - {_sequence[index]}");

				else
					Console.WriteLine("Next number is too large to be calculated right now... Might add a solution in the future...");
			}
		}

		private static ulong[] _initializeSequence(ulong size)
		{
			ulong[] sequence = new ulong[size + 1];

			sequence[0] = 0;
			sequence[1] = 1;

			return sequence;
		}
	}
}

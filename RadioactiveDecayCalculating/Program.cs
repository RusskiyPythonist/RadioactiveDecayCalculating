using System;
using Bluegrams.Periodica.Data;

namespace RadioactiveDecayCalculating // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static private bool ElementIsExist(PeriodicTable periodicTable, string elementName)
        {
            bool isAtTable;

            try { isAtTable = periodicTable[elementName].Symbol != null; }

            catch { isAtTable = false; }

            return isAtTable;
        }

        static private Element GetElementByName(PeriodicTable periodicTable, string elementName)
        {
            return periodicTable[elementName];
        }

        static private Element GetElementByAtomicNumber(PeriodicTable periodicTable, int atomicNumber)
        {
            return periodicTable[atomicNumber];
        }
		
		static private bool IsIsotope(int atomicMass1, int atomicMass2) { return atomicMass1 == atomicMass2 ? false : true; }

        static void Main(string[] args)
        {
            var periodicTable = PeriodicTable.Load();
            
			Console.WriteLine("Введите химический элемент");
			Console.Write(">> ");
            string elementName = Convert.ToString(Console.ReadLine());

            if (elementName != null && elementName.Length <= 2 && ElementIsExist(periodicTable, elementName) == true)
            {
                Element elementToDecay = GetElementByName(periodicTable, elementName);
                int elementAtomicMass = Convert.ToInt32(Math.Ceiling(elementToDecay.AtomicMass));
                int elementAtomicNumber = elementToDecay.AtomicNumber;

                Console.WriteLine("Введите реакцию распада");
                Console.WriteLine("1 - Альфа-распад");
                Console.WriteLine("2 - Бета-распад");
                Console.WriteLine("0 - Выход");

                Console.Write(">> ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    Element helium = GetElementByName(periodicTable, "He");
                    int heliumAtomicMass = Convert.ToInt32(helium.AtomicMass);
                    int heliumAtomicNumber = helium.AtomicNumber;

                    int finalElementAtomicMass = elementAtomicMass - heliumAtomicMass;
                    int finalElementAtomicNumber = elementAtomicNumber - heliumAtomicNumber;
                    Element finalElement = GetElementByAtomicNumber(periodicTable, finalElementAtomicNumber);

                    int tableAtomicMass = Convert.ToInt32(finalElement.AtomicMass);
                    bool elementIsIsotope = IsIsotope(tableAtomicMass, finalElementAtomicMass);

                    Console.WriteLine($"{elementAtomicMass}     {finalElementAtomicMass}    {heliumAtomicMass}");
                    Console.WriteLine($" {elementToDecay.Symbol} -->  {finalElement.Symbol}  +  {helium.Symbol}");
                    Console.WriteLine($"{elementAtomicNumber}      {finalElementAtomicNumber}     {heliumAtomicNumber}");

                    Console.WriteLine($"Является изотопом: {elementIsIsotope}");
                } else if (input == 2)
                {
                    const int electronAtomicMass = 0;
                    const int electronAtomicNumber = -1;

                    int finalElementAtomicMass = elementAtomicMass - electronAtomicMass;
                    int finalElementAtomicNumber = elementAtomicNumber - electronAtomicNumber;
                    Element finalElement = GetElementByAtomicNumber(periodicTable, finalElementAtomicNumber);

                    int tableAtomicMass = Convert.ToInt32(finalElement.AtomicMass);
                    bool elementIsIsotope = IsIsotope(tableAtomicMass, elementAtomicMass);

                    Console.WriteLine($"{elementAtomicMass}      {finalElementAtomicMass}     {electronAtomicMass}");
                    Console.WriteLine($" {elementToDecay.Symbol} -->  {finalElement.Symbol}  +   e");
                    Console.WriteLine($"{elementAtomicNumber}      {finalElementAtomicNumber}    {electronAtomicNumber}");
					
					Console.WriteLine($"Является изотопом: {elementIsIsotope}");
                }

            } else
            {
                Console.WriteLine("Элемент не введён или его не существует");
            }
        }
    }
}
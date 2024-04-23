using System;
using Bluegrams.Periodica.Data;
using ElementsUtility = RadioactiveDecayCalculating.Modules.ElementsUtility;

namespace RadioactiveDecayCalculating
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var periodicTable = PeriodicTable.Load(); // Загрузка таблицы элементов
            
			Console.WriteLine("Введите химический элемент");
			Console.Write(">> ");
            string elementSymbol = Convert.ToString(Console.ReadLine()); // Ввод символа элемента с клавиатуры

            if (elementSymbol != null && ElementsUtility.ElementIsExist(periodicTable, elementSymbol) == true)
            {
                Element elementToDecay = ElementsUtility.GetElementBySymbol(periodicTable, elementSymbol); // Получаем элемент по символу
                int elementAtomicMass = Convert.ToInt32(Math.Ceiling(elementToDecay.AtomicMass)); // Атомная масса вводимого элемента
                int elementAtomicNumber = elementToDecay.AtomicNumber; // Атомный номер вводимого элемента

                Console.WriteLine("Введите реакцию распада");
                Console.WriteLine("1 - Альфа-распад");
                Console.WriteLine("2 - Бета-распад");
                Console.WriteLine("0 - Выход");

                Console.Write(">> ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    Element helium = ElementsUtility.GetElementByName(periodicTable, "He"); // Получение информации об элементе "Гелий"
                    int heliumAtomicMass = Convert.ToInt32(helium.AtomicMass); // Атомная масса гелия
                    int heliumAtomicNumber = helium.AtomicNumber; // Атомный номер гелия

                    int finalElementAtomicMass = elementAtomicMass - heliumAtomicMass; // Вычисление атомной массы получившегося элемента
                    int finalElementAtomicNumber = elementAtomicNumber - heliumAtomicNumber; // Вычисление атомного номера получившегося элемента
                    Element finalElement = ElementsUtility.GetElementByAtomicNumber(periodicTable, finalElementAtomicNumber); // Находим получившийся элемент по атомному номеру

                    int tableAtomicMass = Convert.ToInt32(finalElement.AtomicMass); // Получаем табличное значение атомной массы элемента
                    bool elementIsIsotope = ElementsUtility.IsIsotope(tableAtomicMass, finalElementAtomicMass); // Проверка на изотоп

                    // Вывод информации в консоль

                    Console.WriteLine($"{elementAtomicMass}     {finalElementAtomicMass}    {heliumAtomicMass}");
                    Console.WriteLine($" {elementToDecay.Symbol} -->  {finalElement.Symbol}  +  {helium.Symbol}");
                    Console.WriteLine($"{elementAtomicNumber}      {finalElementAtomicNumber}     {heliumAtomicNumber}");

                    Console.WriteLine($"Является изотопом: {elementIsIsotope}");
                } else if (input == 2)
                {
                    const int electronAtomicMass = 0; // Атомная масса электрона
                    const int electronAtomicNumber = -1; // Атомный номер электрона (так как отрицательный заряд)

                    int finalElementAtomicMass = elementAtomicMass - electronAtomicMass; // Вычисление атомной массы получившегося элемента
                    int finalElementAtomicNumber = elementAtomicNumber - electronAtomicNumber; // Вычисление атомного номера получившегося элемента
                    Element finalElement = ElementsUtility.GetElementByAtomicNumber(periodicTable, finalElementAtomicNumber); // Находим получившийся элемент по атомному номеру

                    int tableAtomicMass = Convert.ToInt32(finalElement.AtomicMass); // Получаем табличное значение атомной массы элемента
                    bool elementIsIsotope = ElementsUtility.IsIsotope(tableAtomicMass, elementAtomicMass); // Проверка на изотоп

                    // Вывод информации в консоль

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
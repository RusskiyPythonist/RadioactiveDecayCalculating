using System;
using Bluegrams.Periodica.Data;

namespace RadioactiveDecayCalculating.Modules
{
    internal class ElementsUtility
    {
        static public bool ElementIsExist(PeriodicTable periodicTable, string elementSymbol) // Существует ли элемент в таблице элементов
        {
            bool isAtTable;

            try { isAtTable = periodicTable[elementSymbol].Symbol != null; }

            catch { isAtTable = false; }

            return isAtTable;
        }

        static public Element GetElementBySymbol(PeriodicTable periodicTable, string elementSymbol) // Получение элемента по его символу
        {
            return periodicTable[elementSymbol];
        }

        static public Element GetElementByAtomicNumber(PeriodicTable periodicTable, int atomicNumber) // Получение элемента по его атомному номеру
        {
            return periodicTable[atomicNumber];
        }

        static public Element GetElementByName(PeriodicTable periodicTable, string elementSymbol)
        {
            return periodicTable[elementSymbol];
        }

        static public bool IsIsotope(int atomicMass1, int atomicMass2) // Является ли элемент изотопом
        {
            return atomicMass1 == atomicMass2 ? false : true;
        }
    }
}

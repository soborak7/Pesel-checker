using System;
using System.Linq;
namespace Pesel { 

    class PeselChecker
    {
        public void IsNumeric(string pesel)
        {
            bool allDigits = pesel.All(char.IsDigit);
            if (allDigits == true)
            {
                Console.WriteLine("Pesel ma prawidlowy format");
            }
            else if ((allDigits == false))
            {
                Console.WriteLine("Pesel ma niedozwolone znaki");
            }
        }
        public void CharChecker(string pesel)
        {

            int dlugosc = pesel.Length;
            if (dlugosc < 11) //sprawdzanie długości w tym miejscu potrzebne do obsługiwania wyjątków z formułą "pesel[dlugosc - 9]" i tym podobnych
            {
                Console.WriteLine("Numer PESEL jest za krotki");
            }
            else if ((pesel[dlugosc - 9] != '0') && (pesel[dlugosc - 9] != '1')) // liczba dziesiątek w miesiącu nie może być większa niż 1
            {
                Console.WriteLine("PESEL niepoprawny - blad w miesiacu");
            }
            else if (pesel[dlugosc - 9] == '1')
            {
                if ((pesel[dlugosc - 8] != '0') && (pesel[dlugosc - 8] != '1') && (pesel[dlugosc - 8] != '2')) //miesiące nie mogą być inne niż 10, 11, 12
                {
                    Console.WriteLine("PESEL niepoprawny - bledny miesiac");
                }
            }
            else if ((pesel[dlugosc - 9] == 0) && (pesel[dlugosc - 8] == 2)) //luty

            {
                if ((pesel[dlugosc - 7] != 0) && (pesel[dlugosc - 7] != 1) && (pesel[dlugosc - 7] != 2)) //luty nie może mieć więcej niż 29 dni, bez uwzględniania dni przestępnych

                {
                    Console.WriteLine("PESEL niepoprawny - bledny dzien");
                }
            }
            else if ((pesel[dlugosc - 7] != '0') && (pesel[dlugosc - 7] != '1') && (pesel[dlugosc - 7] != '2') && (pesel[dlugosc - 7] != '3')) //liczba dziesiątek dni nie może być większa niż 3
            {
                Console.WriteLine("PESEL niepoprawny - bledny dzien");
            }
            else if (pesel[dlugosc - 7] == '3')
            {
                if ((pesel[dlugosc - 6] != '1') && (pesel[dlugosc - 6] != '0')) //nie może być więcej niż 31 dni w miesiącu
                {
                    Console.WriteLine("PESEL niepoprawny - bledny dzien");
                }
            }
            else if (pesel[dlugosc - 7] == '0')
            {
                if (pesel[dlugosc - 6] == '0') //nie może być zerowego dnia miesiąca
                {
                    Console.WriteLine("PESEL niepoprawny - bledny dzien");
                }
            }
            else
            {
                Console.WriteLine("Zapis jest prawidlowy");
            }
        }
        public void PeselLength(string pesel)
        {
            int dlugosc = pesel.Length;
            if (dlugosc == 11)
            {
                Console.WriteLine("Dlugosc numeru PESEL jest poprawna");
            }
            else if (dlugosc > 11)
            {
                Console.WriteLine("Dlugosc numeru PESEL jest za dluga");
            }


        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj numer PESEL: ");
            string pesel = Console.ReadLine();
            PeselChecker peselChecker = new PeselChecker();
            peselChecker.CharChecker(pesel);
            peselChecker.PeselLength(pesel);
            peselChecker.IsNumeric(pesel);

            Console.ReadLine();
        }
    }
}
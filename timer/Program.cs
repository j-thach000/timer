/* TODO:
 * prompt user to choose stopwatch or timer function
 * [x] print a menu
 * [x] allow user to input a menu choice
 * [] implement menu choices
 * 
 * choosing the stopwatch function begins updating a printed line with time
 * choosing the timer functions shows a line of printed time decreasing
 * pressing enter key stops current function
 */

void MenuPrint()
{
    Console.WriteLine("1 - Stopwatch");
    Console.WriteLine("2 - Timer");
    Console.WriteLine("3 - Conversion: Minutes to Hours");
    Console.WriteLine("0 - Exit");
}

int MenuReadNumber()
{
    Console.Write("Please input a choice: ");
    int menuNumber = Convert.ToInt32(Console.ReadLine());
    return menuNumber;
}

decimal GenericReadNumber()
{
    decimal genericNumberInput = Convert.ToDecimal(Console.ReadLine());
    return genericNumberInput;
}

int menuChoice;
do
{
    MenuPrint();
    menuChoice = MenuReadNumber();
    switch (menuChoice)
    {
        case 1:
            break;
        case 2:
            break;
        case 3:
            Console.Write("Time studied: ");
            decimal minutesStudied = GenericReadNumber();
            decimal minutesConvertedToHours = minutesStudied / 60;
            Console.WriteLine($"% of hour studied: {minutesConvertedToHours}");
            break;
        case 0:
            break;
        default:
            break;
    }
} while (menuChoice != 0);
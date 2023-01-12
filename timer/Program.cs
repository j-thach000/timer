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
    Console.WriteLine("0 - Exit");
}

int MenuReadNumber()
{
    Console.Write("Please input a choice: ");
    int menuNumber = Convert.ToInt32(Console.ReadLine());
    return menuNumber;
}

int menuChoice;
do
{
    MenuPrint();
    menuChoice = MenuReadNumber();
} while (menuChoice != 0);
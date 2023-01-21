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

// refactor with switch expression?
void MenuPrint()
{
    Console.WriteLine("1 - Stopwatch");
    Console.WriteLine("2 - Timer");
    Console.WriteLine("3 - Conversion: Minutes to Hours");
    Console.WriteLine("4 - Modified Pomodoro");
    Console.WriteLine("0 - Exit");
}

void PomodorMenuPrint()
{
    Console.WriteLine("1 - Duration completed");
    Console.WriteLine("2 - Exit");
}

int MenuReadNumber()
{
    Console.Write("Please input a choice: ");
    int menuNumber = Convert.ToInt32(Console.ReadLine());
    return menuNumber;
}

double GenericReadNumber()
{
    double genericNumberInput = Convert.ToDouble(Console.ReadLine());
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
            double minutesStudied = GenericReadNumber();
            double minutesConvertedToHours = minutesStudied / 60;
            Console.WriteLine("======================================");
            Console.WriteLine($"% of hour studied: {minutesConvertedToHours}");
            Console.WriteLine("======================================");

            break;
        // write documentation on this feature
        case 4:
            int pomodoroMenuChoice;
            double currentStudyDuration = 5;
            double incrementStreak = 0;
            double totalStudyDuration = 0;
            do
            {
                DateTime localDate = DateTime.Now;
                Console.WriteLine("======================================");
                Console.WriteLine(localDate.ToString());
                Console.WriteLine($"Current increment: {currentStudyDuration}");
                Console.WriteLine($"Increment streak : {incrementStreak}");
                Console.WriteLine($"Total time       : {totalStudyDuration}");
                Console.WriteLine("======================================");

                PomodorMenuPrint();
                pomodoroMenuChoice = MenuReadNumber();
                switch (pomodoroMenuChoice)
                {
                    case 1:
                        Console.Write($"Distracted? (y/n): ");
                        string stateDistracted = Console.ReadLine();
                        if (stateDistracted == "y")
                        {
                            totalStudyDuration += currentStudyDuration;
                            if (currentStudyDuration > 5)
                            {
                                currentStudyDuration -= 5;
                            }
                        }
                        else if (stateDistracted == "n")
                        {
                            totalStudyDuration += currentStudyDuration;
                            incrementStreak += 1;
                            if (incrementStreak == 3)
                            {
                                currentStudyDuration += 5;
                                incrementStreak = 0;
                            }
                        } 
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            while (pomodoroMenuChoice != 2);
            break;
        case 0:
            break;
        default:
            break;
    }
} while (menuChoice != 0);
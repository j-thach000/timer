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
// doesn't make sense since the switch expression evaluates some logic and performs an action afterwards
// this code is just printing a menu and we want methods to do just one thing
void MenuPrint()
{
    Console.WriteLine("1 - Stopwatch");
    Console.WriteLine("2 - Timer");
    Console.WriteLine("3 - Conversion: Minutes to Hours");
    Console.WriteLine("4 - Modified Pomodoro");
    Console.WriteLine("0 - Exit");
}

void PomodoroMenuPrint()
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

Console.Title = "Study Tool";
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
            Console.WriteLine("==========================");
            Console.WriteLine($"% of hour studied: {minutesConvertedToHours}");
            Console.WriteLine("==========================");
            break;

        /* TODO
         * [] write documentation
         * [] input validation for distraction y/n prompt
         * [x] implement prompting user to display study subject and print it each loop
         * [] output records to a text file
         * [] set background to default to black (daytime terminal background makes cyan hard to read)
         * [] set text color to default to white
         * [x] change color of study statistics
         * [x] formatting ==== border to separate study statistics
         * [x] printing date and time each increment
         * [x] adding sound fx to provide feedback for each study increment
         */

        case 4:
            int pomodoroMenuChoice;
            double currentStudyDuration = 5;
            double incrementStreak = 0;
            double totalStudyDuration = 0;

            Console.Write("Subject: ");
            string studySubject = Console.ReadLine();

            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
                DateTime localDate = DateTime.Now;
                Console.WriteLine("==========================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(localDate.ToString());
                Console.WriteLine($"Subject          : {studySubject}");
                Console.WriteLine($"Current increment: {currentStudyDuration}");
                Console.WriteLine($"Increment streak : {incrementStreak}");
                Console.WriteLine($"Total time       : {totalStudyDuration}");
                Console.ResetColor();
                Console.WriteLine("==========================");

                PomodoroMenuPrint();
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
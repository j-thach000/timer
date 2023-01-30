﻿/* TODO:
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
// this code is just printing a menu and we want to logically separate methods for one purpose
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
    Console.WriteLine("2 - Display session log");
    Console.WriteLine("0 - Exit");
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
         * [] high score for streaks of not being distracted
         * [x] input validation for distraction y/n prompt
         * [] implement some system for when to take breaks
         * [x] implement prompting user to display study subject and print it each loop
         * [] output records to a text file
         * [x] change color of study statistics
         * [x] formatting ==== border to separate study statistics
         * [x] printing date and time each increment
         * [x] adding sound fx to provide feedback for each study increment
         * [] an array that slowly fills up with the times of each session
         */

        case 4:
            int pomodoroMenuChoice;
            double currentStudyDuration = 5;
            double incrementStreak = 0;
            double totalStudyDuration = 0;
            string[] studySessionLog = new string[100];

            Console.Write("Subject: ");
            string studySubject = Console.ReadLine();

            do
            {
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
                        while (stateDistracted != "y" && stateDistracted != "n")
                        {
                            Console.Write("Invalid input, try again: ");
                            stateDistracted = Console.ReadLine();
                        } 
                        // think of discrete math logic
                        // can't use || as the connective for the condition since
                        // the variable can only be one value at a time and it makes
                        // either statement connected true                  
                        // so it just turns into an endless loop
                        // remember do while loops go off at least once

                        if (stateDistracted == "y")
                        {
                            totalStudyDuration += currentStudyDuration;
                            if (currentStudyDuration > 5)
                            {
                                currentStudyDuration -= 5;
                                incrementStreak = 0;
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
                    case 0: 
                        break;
                    default:
                        break;
                }
            }
            while (pomodoroMenuChoice != 0);
            break;
        case 0:
            break;
        default:
            break;
    }
} while (menuChoice != 0);
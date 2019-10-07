using System;
using System.Collections.Generic;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description:
    // Application Type: Console
    // Author: Nathan Zak
    // Dated Created: 10/2/2019
    // Last Modified:
    //
    // **************************************************

    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        static void DisplayMainMenu()
        {
            //
            // instantiate a Finch object
            //
            //Finch finchRobot;
            //finchRobot = new Finch();
            Finch finchRobot = new Finch();

            bool finchRobotConnected = false;
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get the user's menu choice
                //
                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                //
                // process user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        if (finchRobotConnected)
                        {
                            DisplayTalentShow(finchRobot);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please return to the Main Menu and connect to the Finch robot.");
                            DisplayContinuePrompt();
                        }
                        break;

                    case "c":
                        DisplayDataRecorder(finchRobot);
                        break;

                    case "d":
                        DisplayAlarmSystem(finchRobot);
                        break;

                    case "e":
                        DisplayUserProgramming(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("\t******************************");
                        Console.WriteLine("\tPlease indicate your choice with a letter.");
                        Console.WriteLine("\t******************************");

                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        /// <summary>
        /// User Programming
        /// </summary>
        static void DisplayUserProgramming(Finch finchRobot)
        {
            DisplayScreenHeader("User Programming");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Alarm System
        /// </summary>
        static void DisplayAlarmSystem(Finch finchRobot)
        {
            DisplayScreenHeader("Alarm System");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Data Recordings (FINCH)
        /// </summary>
        static void DisplayDataRecorder(Finch finchRobot)
        {
            DisplayScreenHeader("Data Recordings");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Talent Show
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayTalentShow(Finch finchRobot)
        {
            DisplayScreenHeader("Talent Show");

            Console.WriteLine("The Finch robot is ready to show you its talent.");
            DisplayContinuePrompt();

            
            //ENTER MY CODE HERE TO MOVE IT AND STUFF
            finchRobot.setMotors(75, 75);


            finchRobot.isObstacleLeftSide();
            finchRobot.isObstacleRightSide();

            Console.ReadKey();finchRobot.setMotors(75, 75);


            finchRobot.isObstacleLeftSide();
            finchRobot.isObstacleRightSide();

            Console.ReadKey();

            finchRobot.setMotors(100, 75);


            finchRobot.isObstacleLeftSide();
            finchRobot.isObstacleRightSide();

            Console.ReadKey(); finchRobot.setMotors(100, 75);

            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(10000);

            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(10000);

            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(10000);

            //for (int lightLevel = 0; lightLevel < 255; lightLevel++)
            //{
            //    finchRobot.setLED(234, 132, 0);
            //}

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Disconnect finch
        /// </summary>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("Ready to diconnect the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine();
            Console.WriteLine("Finch robot is now disconnected.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Connect finch
        /// </summary>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            bool finchRobotConnected = false;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("Ready to connect to the Finch robot. Please be sure to connect the USB able to the robot and the computer.");
            DisplayContinuePrompt();

            finchRobotConnected = finchRobot.connect();

            if (finchRobotConnected)
            {
                finchRobot.setLED(0, 255, 0);
                finchRobot.noteOn(15000);
                finchRobot.wait(1000);
                finchRobot.noteOff();

                Console.WriteLine();
                Console.WriteLine("Finch robot is now connected.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Unable to connect to the Finch robot.");
            }

            DisplayContinuePrompt();

            return finchRobotConnected;
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        #region HELPER METHODS

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
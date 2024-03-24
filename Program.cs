using System;
using System.Collections.Generic;

namespace ConsoleBattle
{
    class Programm
    {
        enum Commands
        {
            LIST_FIGHTERS,
            ADD_FIGHTER,
            REMOVE_FIGHTER,
            START_FIGHT,
        }

        static Dictionary<string, int> StringCommands()
        {
            return new Dictionary<string, int>()
            {
                { "list-fighters", (int)Commands.LIST_FIGHTERS},
                { "add-fighter", (int)Commands.ADD_FIGHTER},
                { "remove-fighter", (int)Commands.REMOVE_FIGHTER},
                { "start-fight", (int)Commands.START_FIGHT},
            };
        }

        static void Main()
        {
            Console.WriteLine("Приветствую вас в консольной королевской битве!");

            Console.WriteLine("Доступные команды: ");
            foreach (var stringCommand in StringCommands()) {
                Console.WriteLine(stringCommand.Key);
            }

            WaitCommand();
        }

        static void WaitCommand()
        {
            var command = RequestCommand();
            //Console.WriteLine((Commands)command);
            switch (command)
            {
                case (int)Commands.LIST_FIGHTERS:
                    Console.WriteLine("Список персов");
                    break;
                case (int)Commands.ADD_FIGHTER:
                    Console.WriteLine("Добавить бойца");
                    break;
                case (int)Commands.REMOVE_FIGHTER:
                    Console.WriteLine("Удалить бойца");
                    break;
                case (int)Commands.START_FIGHT:
                    Console.WriteLine("Начать бой");
                    break;
            }

            WaitCommand();
        }

        static int RequestCommand()
        {
            Console.WriteLine("Введите команду");
            Console.Write("/");

            var enteredCommand = Console.ReadLine();
            var stringCommands = StringCommands();

            if (enteredCommand is null || !stringCommands.ContainsKey(enteredCommand))
            {
                Console.WriteLine("Такой команды нет");
                return RequestCommand();
            }

            return stringCommands[enteredCommand];
        }

        static ConsoleKey GetButton()
        {
            var but = Console.ReadKey().Key;

            return but;
        }
    }
}


using AsukaBot_2._0.Module.RPGModule;
using AsukaBot_2._0.Module.RPGModule.Logic.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsukaBot_2._0.Classes
{
    class SingleTon
    {
        private static Discord.IDiscordClient discordRefence;
        private static MonsterDatabase MyMonsterDatabaseInstace;
        private static ConsoleChecker ConsoleCheckerInstance;
        private static Thread CheckConsole;
        private static Thread RPGThreadCheck;
        private static RPGMain RPGInstance;
        //private static RPGThreadChecker RPGThreadCheckerInstance;


        public static void SetClient(Discord.IDiscordClient client)
        {
            discordRefence = client;
        }

        public static Discord.IDiscordClient GetDiscordClient()
        {
            return discordRefence;
        }

        //public static void AssignRPGCThreadCheck(Thread myThread)
        //{
        //    if (RPGThreadCheck == null)
        //    {
        //        RPGThreadCheck = myThread;
        //        RPGThreadCheck.Start();
        //    }
        //}

        public static void AssignCheckConsole(Thread myThread)
        {
            if (CheckConsole == null)
            {
                CheckConsole = myThread;
                CheckConsole.Start();
            }
        }

        public static MonsterDatabase GetMonsterDatabaseInstace()
        {
            if (MyMonsterDatabaseInstace == null)
            {
                MyMonsterDatabaseInstace = new MonsterDatabase();
            }
            return MyMonsterDatabaseInstace;
        }

        public static ConsoleChecker GetConsoleCheckerInstance()
        {
            if (ConsoleCheckerInstance == null)
            {
                ConsoleCheckerInstance = new ConsoleChecker();
            }
            return ConsoleCheckerInstance;
        }

        //public static RPGThreadChecker GetRPGThread()
        //{
        //    if (RPGThreadCheckerInstance == null)
        //    {
        //        RPGThreadCheckerInstance = new RPGThreadChecker();
        //    }
        //    return RPGThreadCheckerInstance;
        //}

        public static RPGMain GetRPG()
        {
            return RPGInstance;
        }

        public static void SetRPG(RPGMain instance)
        {
            if (RPGInstance == null)
            {
                RPGInstance = instance;
            }
        }
    }
}

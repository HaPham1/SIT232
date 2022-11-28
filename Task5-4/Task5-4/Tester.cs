using System;

namespace Task5_4
{
    class Tester
    {
        private static IController controller;
        private static IGui gui;
        private static string displayText;
        private static int randomNumber;
        private static int passed = 0;

        static void Main(string[] args)
        {
            // run test
            Test();
            Console.WriteLine("\n=====================================\nSummary: {0} tests passed out of 51", passed);
            Console.ReadKey();
        }

        private static void Test()
        {
            //Construct a ReactionController
            controller = new EnhancedReactionController();
            gui = new DummyGui();

            //Connect them to each other
            gui.Connect(controller);
            controller.Connect(gui, new RndGenerator());

            //Reset the components()
            gui.Init();

            //Test the EnhancedReactionController
            //IDLE state test
            DoReset("0", controller, "Insert coin");
            DoGoStop("1", controller, "Insert coin");
            DoTicks("2", controller, 1, "Insert coin");

            //coinInserted - Start state
            //Test insert coin on start state then test for waiting too long, return to insert coin screen
            DoInsertCoin("3", controller, "Press GO!");
            DoInsertCoin("4", controller, "Press GO!");
            DoTicks("5", controller, 999, "Press GO!");
            DoTicks("6", controller, 1, "Insert coin");


            //Test on Wait state
            //Insert coin -> GoStopPress -> Wait state
            //Cheating, press too early
            DoInsertCoin("7", controller, "Press GO!");
            DoGoStop("8", controller, "Wait...");
            DoInsertCoin("9", controller, "Wait...");
            DoTicks("10", controller, 99 ,"Wait...");
            DoGoStop("11", controller, "Insert coin");

            //Advance to TimeRecord state and test ticks
            gui.Init();
            DoInsertCoin("12", controller, "Press GO!");
            randomNumber = 167;
            DoGoStop("13", controller, "Wait...");
            DoTicks("14", controller, randomNumber - 1, "Wait...");
            //Run ticks
            DoTicks("15", controller, 1, "0.00");
            DoTicks("16", controller, 1, "0.01");
            DoTicks("17", controller, 11, "0.12");
            DoTicks("18", controller, 111, "1.23");
            //Stop
            DoGoStop("19", controller, "1.23");


            //Advance to display state test and display average test
            //This test will test for whole 3 times successfully with correct AVG display and gostoppressed to skip wait time.
            //2nd time
            randomNumber = 100;
            DoGoStop("20", controller, "Wait...");
            DoTicks("21", controller, 100, "0.00");
            DoTicks("22", controller, 124, "1.24");
            DoGoStop("23", controller, "1.24");
            //3rd time
            randomNumber = 100;
            DoGoStop("24", controller, "Wait...");
            DoTicks("25", controller, 225, "1.25");
            DoGoStop("26", controller, "1.25");
            DoGoStop("27", controller, "AVG: 1.24");
            DoGoStop("28", controller, "Insert Coin");

            //Display state test
            //This test will test that TimeRecord -> Display -> Wait by waiting 2 seconds then 3 seconds respectively
            //Then on second turn we will cheat and cancel the game 
            //1st turn
            DoInsertCoin("29", controller, "Press GO!");
            randomNumber = 100;
            DoGoStop("30", controller, "Wait...");
            DoTicks("31", controller, randomNumber, "0.00");
            DoTicks("32", controller, 200, "2.00");
            DoInsertCoin("33", controller, "2.00");
            DoTicks("34", controller, 300, "Wait...");
            //2nd turn
            DoTicks("35", controller, 1, "Wait...");
            DoGoStop("36", controller, "Insert coin");

            //Display Average test
            //This test will do 3 games then wait 3 seconds to reach DisplayAverage then wait 5 seconds to idle state.
            //As this is the multiple time the game run, we also made sure that game counter is reset to 0 and effective every game.
            DoInsertCoin("37", controller, "Press GO!");
            randomNumber = 250;
            DoGoStop("38", controller, "Wait...");
            DoTicks("39", controller, randomNumber, "0.00");
            DoGoStop("40", controller, "0.00");
            DoGoStop("41", controller, "Wait...");
            DoTicks("42", controller, randomNumber, "0.00");
            DoGoStop("43", controller, "0.00");
            DoGoStop("44", controller, "Wait...");
            DoTicks("45", controller, randomNumber, "0.00");
            DoTicks("46", controller, 3, "0.03");
            DoGoStop("47", controller, "0.03");
            DoTicks("48", controller, 300, "AVG: 0.01");
            DoInsertCoin("49", controller, "AVG: 0.01");
            DoTicks("50", controller, 500, "Insert coin");

        }

        private static void DoReset(string ch, IController controller, string msg)
        {
            try
            {
                controller.Init();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoGoStop(string ch, IController controller, string msg)
        {
            try
            {
                controller.GoStopPressed();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoInsertCoin(string ch, IController controller, string msg)
        {
            try
            {
                controller.CoinInserted();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void DoTicks(string ch, IController controller, int n, string msg)
        {
            try
            {
                for (int t = 0; t < n; t++) controller.Tick();
                GetMessage(ch, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", ch, msg, exception.Message);
            }
        }

        private static void GetMessage(string ch, string msg)
        {
            if (msg.ToLower() == displayText.ToLower())
            {
                Console.WriteLine("test {0}: passed successfully", ch);
                passed++;
            }
            else
                Console.WriteLine("test {0}: failed with message ( expected {1} | received {2})", ch, msg, displayText);
        }

        private class DummyGui : IGui
        {

            private IController controller;

            public void Connect(IController controller)
            {
                this.controller = controller;
            }

            public void Init()
            {
                displayText = "?reset?";
            }

            public void SetDisplay(string msg)
            {
                displayText = msg;
            }
        }

        private class RndGenerator : IRandom
        {
            public int GetRandom(int from, int to)
            {
                return randomNumber;
            }
        }

    }

}

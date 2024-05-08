namespace ConsoleBattleships
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            string output = "";
            string[] options = new string[]
            {
                "Singleplayer",
                "Multiplayer",
                "Options",
                "Exit Game"
            };
            int selected = 0;
            bool selectChange = false;

            while (true)
            {
                // Escape codes for clearing screen, setting cursor position, making cursor invisible
                output = "\x1b[2J\x1b[H\x1b[?25l" +
                    "\x1b[36m\x1b[1mBattleships!\x1b[0m\n";

                // Adding the options to output as well as adding aditional space for selected option
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selected) { output += "> "; }
                    else { output += "  "; }
                    output += options[i] + "\n";
                }

                // Print output
                Console.WriteLine(output);

                // Funky sound effect on selection change
                // (does lock thread for milliseconds played so mayb fix that)
                if (selectChange)
                {
                    // Console.Beep(200, 200); // Potentially remove as only windows compatible
                    selectChange = false;
                }

                // Checks for arrow key inputs to change selected + if item is selected with enter key
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.UpArrow && selected > 0) { selected--; selectChange = true; }
                else if (input.Key == ConsoleKey.DownArrow && selected < options.Length - 1) { selected++; selectChange = true; }
                else if (input.Key == ConsoleKey.Enter)
                {
                    // Console.Beep(300, 200); // Potentially remove as only windows compatible
                    if (Select(selected)) { break; }
                }
            }
        }

        static bool Select(int selected)
        {
            bool exit = false;

            switch (selected)
            {
                case 0:
                    Game game = new Game();
                    Console.WriteLine("\x1b[2J\x1b[H\x1b[?25l" +
                        (game.GameLoop() ? "Win!!!" : "Lose :("));
                    Thread.Sleep(2000);
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Multiplayer isn't implemented yet sorry!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Options aren't implemented yet sorry!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case 3:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid Selection Error");
                    exit = true;
                    break;
            }

            return exit;
        }

        // Interface to browse open games after selecting a name
        static void GameBrowser()
        {
            // TODO: This 👍
        }
    }
}
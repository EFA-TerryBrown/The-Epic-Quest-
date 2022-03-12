using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheEpicQuest.Data;

public class Program_UI
{
    Wizzard player = new Wizzard();
    bool battleInProgress = false;
    //gave these two bools Global Scope:
    //these can now be used anywhere.
    bool isRunning = true;
    bool isGameStarted = false;

    private readonly LevelRepository _lRepo;
    private readonly WizzardRepository _wRepo;
    private readonly WorldRepository _worldRepo;

    public Program_UI()
    {
        _wRepo = new WizzardRepository();
        _lRepo = new LevelRepository();
        _worldRepo = new WorldRepository(_lRepo);
    }

    public void Run()
    {
        //Seed Data
        SeedData();
        //Run the app
        RunApplication();
    }

    private void RunApplication()
    {

        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to The Epic Quest!");
            System.Console.WriteLine("Press any key to Start.");
            Console.ReadKey();
            isGameStarted = true;
            if (isGameStarted && player.Lives > 0)
            {
                Console.Clear();
                PlayerSetupMenu();
                EnterLevel_1(1);
                EnterLevel_2(2);
                GameOver();
            }
            
        }
    }

    private void GameOver()
    {
        isGameStarted = false;
        System.Console.WriteLine("Thanks for playing! Press any key to continue.");
        Console.ReadKey();
        isRunning=false;
    }

    private void EnterLevel_1(int lvlID)
    {
        var lvl = _lRepo.GetLevelById(lvlID);
        LevelStory(new List<string>
         {
             $"The wizzard by the name of {player.Name} has entered the battlefield!",
             $"{player.Name} sees a group of Evil Wizzards\n" +
              "Who will you attack?\n"
         },
        player,
        lvl.ID);
        // _lRepo.GetLevelById(1).EvilWizzards);
    }
     private void EnterLevel_2(int lvlID)
     {
         var lvl = _lRepo.GetLevelById(lvlID);
          LevelStory(new List<string>
         {
             $"The wizzard by the name of {player.Name} has entered the battlefield!",
             "The snow is falling, the clouds are dark and the Thunder Is Roaring!",
             $"{player.Name} sees a group of Evil Wizzards\n" +
              "Who will you attack?\n"
         },
        player,
        lvl.ID);
     }
    private void LevelStory(List<string> story, Wizzard player, int lvlID)
    {
        var evilWizzards = _lRepo.GetLevelById(lvlID).EvilWizzards;
        Console.Clear();
        foreach (var sentence in story)
        {
            System.Console.WriteLine(sentence);
        }
        if (evilWizzards.Count > 0 && battleInProgress == false)
        {
            //this is the select screen to fight a wizzard
            foreach (var wizzard in evilWizzards)
            {
                System.Console.WriteLine($"{wizzard.ID}. {wizzard.Name}");
            }
            //transform the selection to an ID so the _wRepo can get the specific wizzard
            var userInputEvilWizzard = int.Parse(Console.ReadLine());
            var evilWizzard = _wRepo.GetWizzardByID(userInputEvilWizzard);
            if (evilWizzard != null)
            {
                //This method controls the battle setup
                PrepareForBattle(evilWizzard,lvlID);
            }
            else
            {
                System.Console.WriteLine($"Sorry the id: {userInputEvilWizzard} is invalid.");
                System.Console.WriteLine($"Press Any Key to continue.");
                Console.ReadKey();
            }
        }
        else
        {
            //When the battle is over .....
            System.Console.WriteLine("Continue Story...Press Any Key To Continue...");
            Console.ReadKey();
        }
    }

//battle Method (controls the battles, pass in the evilWizzard that you are fighting and the level ID that you are currently on.)
     private void PrepareForBattle(Wizzard evilWizzard,int lvlID)
    {
        //use the _lRepo repository and assign the lvl to the variable evilWizzards
        var currentLvl= _lRepo.GetLevelById(lvlID);
        Console.Clear();
        
        //Writting to the console to further the story...
        System.Console.WriteLine($"{player.Name} Sreams, Prepare yourself {evilWizzard.Name}!");
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
       
       //Keep fighting as long as the battle is in progress (thats why we are using the while loop)
        battleInProgress = true;
        while (battleInProgress)
        {
            //if the wizzard that you are fighting still has health....
            if (evilWizzard.HealthPoints > 0)
            {
                Console.Clear();
                System.Console.WriteLine($"Fighting: {evilWizzard.Name} - Health Points: {evilWizzard.HealthPoints} ");
                System.Console.WriteLine("What will you do?\n" +
                "1. Use Charm\n" +
                "2. Use Potions\n" +
                "3. Use Defence_Against_DarkArts\n" +
                "4. Use Herbology\n" +
                "5. Use Transfiguration\n" +
                "6. Use Magical_Creatures\n" +
                "7. Use Astronomy\n" +
                "8. Use Quidditch\n");

                Console.Write("Please make a selection:  ");

                //the useer will choose a valid integer value 
                int userInputBattleOption = int.Parse(Console.ReadLine());

                //That value is converted (using casting) into a MagicType
                MagicType magicAbility = (MagicType)userInputBattleOption;
               
                //Now the player can use the Attack Method
                //The Method "takes in" the converted magic ability from above 
                //and the evilWizzard that he/she has chosen to fight
                player.Attack(magicAbility, evilWizzard);
                 
            }

            //if the evilWizzard that we are currently fighting dies (runs out of health)
            if (evilWizzard.HealthPoints <= 0)
            {

                Console.Clear();
                //Tell user that they have won
                System.Console.WriteLine($"{player.Name} has successfully Won the Battle!");
                System.Console.WriteLine("Press Any Key to Continue.");
                Console.ReadKey();
                
                //Remove the defeated wizzard from the repository
                _wRepo.DeleteWizzardByName(evilWizzard.Name);
                //Remove the defeated wizzard from the _lRepo repository
                currentLvl.EvilWizzards.Remove(evilWizzard);
                //Turn of the while loop
                battleInProgress = false;

                //If there are any remaining wizzards to fight
                //the Evil Wizzards that are left in the current lvl
                //(the overall count is being compared to the value of one)
                //I want a special message if the count == 1
                if (currentLvl.EvilWizzards.Count > 1)
                {
                    //Call the LevelStory() method to add to the story before the battle
                    LevelStory(new List<string>{$"{player.Name} the remaining Evil Wizzards\n" +
                    "Who will you attack?\n"}, player, currentLvl.ID);
                } //setting things up for the special message
                else if (currentLvl.EvilWizzards.Count  == 1)
                {
                    //Letting the user know that "this is the final wizzard for the level"
                    LevelStory(new List<string>{$"{player.Name} the final remaining Evil Wizzard\n" +
                    "Will you attack?\n"}, player, currentLvl.ID);
                }
                else //if all else fails stop the battle (end the while loop)
                {
                    battleInProgress=false;
                }
            }

            //If all evil wizzards are defeated for this particular lvl
            if (currentLvl.EvilWizzards.Count  <= 0)
            {
                Console.Clear();
                System.Console.WriteLine($"{player.Name} has successfully Won the War!");
                System.Console.WriteLine("Press Any Key to Continue.");
                //had trouble "steping through the code" 
                // the app would blow up during debugging, even though it works when using
                //dotnet run --project [file location]
                System.Console.WriteLine("You have to press any key 3 times, I don't know why...");
                
                Console.ReadKey();
                //stop the battle (end the while loop)
                battleInProgress = false;
            }

        }//All else fails stop the battle.
         battleInProgress = false;
    }

//This is just a simple character creation method
    private void PlayerSetupMenu()
    {
        System.Console.WriteLine("=== Player Menu ===");
        System.Console.WriteLine("What is your name: ");
        player.Name = Console.ReadLine();
        Console.Clear();
        System.Console.WriteLine($"Hi {player.Name}!");
        System.Console.WriteLine("Press any key.");
        Console.ReadKey();
        Console.Clear();
        System.Console.WriteLine("What Symbol do you have:\n" +
        "1. Snake\n" +
        "2. Badger\n" +
        "3. Lion\n" +
        "4. Raven\n" +
        "5. Ostrich\n");

        int userInput = int.Parse(Console.ReadLine());
        var conversion = (Symbol)userInput;
        player.House.Mascott = conversion;
        Console.Clear();
        System.Console.WriteLine($"{player.Name} - {player.House.Mascott}");
        System.Console.WriteLine($"Press any key to continue.");
        Console.ReadKey();
    }

    //This is the "Driving Force of this app"
    //The plan is to seed all of the needed lvls
    //and just run them from one to what ever lvl count that you want to create.
    //This is just ONE WAY OF DOING THIS...
    //You may have a better implementation....
    //EXPERIMENTATION IS KEY....
    private void SeedData()
    {

        //* Creating our wizzards
        Wizzard headOfHouse = new Wizzard();

        Wizzard evilWizzardA =
        new Wizzard(true,
        true,
        Year.Jr,
        MagicType.Transfiguration,
        80,
        "Mr. Magruff",
        new House(headOfHouse,
        "Evil Birds",
        "Blue",
        new Ghost(),
        Symbol.Snake));

        Wizzard evilWizzardB =
        new Wizzard(true,
        false,
        Year.Jr,
        MagicType.Transfiguration,
        80,
        "Sloth",
        new House(headOfHouse,
        "Evil Birds",
        "Blue",
        new Ghost(),
        Symbol.Snake));

        Wizzard evilWizzardC =
        new Wizzard(true,
        false,
        Year.Jr,
        MagicType.Transfiguration,
        80,
        "Evil Guy 3",
        new House(headOfHouse,
        "Evil Birds",
        "Blue",
        new Ghost(),
        Symbol.Snake));

        Wizzard evilW_Macro =
        new Wizzard(true,
        false,
        Year.Jr,
        MagicType.Transfiguration,
        80,
        "Mr Macro",
        new House(headOfHouse,
        "Evil Birds",
        "Blue",
        new Ghost(),
        Symbol.Snake));

         Wizzard evilW_Micro =
        new Wizzard(true,
        false,
        Year.Jr,
        MagicType.Transfiguration,
        80,
        "Mr. Micro ",
        new House(headOfHouse,
        "Evil Birds",
        "Blue",
        new Ghost(),
        Symbol.Snake));

        _wRepo.AddWizzardToGameDb(evilWizzardA);
        _wRepo.AddWizzardToGameDb(evilWizzardB);
        _wRepo.AddWizzardToGameDb(evilWizzardC);
        _wRepo.AddWizzardToGameDb(evilW_Macro);
        _wRepo.AddWizzardToGameDb(evilW_Micro);

        //*Creating our Levels
        Level lvl_1 = new Level(new List<Wizzard>
        {
            evilWizzardA,
            evilWizzardB,
            evilWizzardC

        });

         Level lvl_2 = new Level(new List<Wizzard>
        {
            evilW_Macro,
            evilW_Micro,

        });

        _lRepo.AddNewLevel(lvl_1);
        _lRepo.AddNewLevel(lvl_2);

        //*Create our world
        World world = new World(new List<Level>
        {
            lvl_1,
            lvl_2
        });

        _worldRepo.AddNewWorld(world);
    }
}


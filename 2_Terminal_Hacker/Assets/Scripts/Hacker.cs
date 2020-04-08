using UnityEngine;

public class Hacker : MonoBehaviour {

    //game data
    const string menuHint = "You may type menu to reset.";
    string[] level1Passwords = { "Book", "Shelf", "Librarian", "Decimal System", "Students" };
    string[] level2Passwords = { "Dollar", "Currency", "Fiduciary", "Interest Rate", "Appreciation" };
    string[] level3Passwords = { "Neural Network", "Database", "Mainframe", "Algorith", "Cryptocurrency" };

    //game state
    int level;
    string greeting = "Hello!\n";
    //string passwordHint;
    string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;



	// Use this for initialization
	void Start ()
    {
        ShowMainMenu(greeting);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //int index = Random.Range(0, level1Passwords.Length);
       // print(index);
	}

    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?" + "\n");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for Bank");
        Terminal.WriteLine("Press 3 for AI Corp" + "\n");
        Terminal.WriteLine("Enter selection below:");

    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu(greeting);
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword(greeting);
        }
        else
        {
            Terminal.WriteLine("please try again" + "\n");
        }
    }

    void AskForPassword(string input)
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();

        Terminal.WriteLine("You chose level " + level + "\n");
        //Terminal.WriteLine("Your Hint Is: " + passwordHint);
        Terminal.WriteLine("Enter a password: " + password.Anagram());
        Terminal.WriteLine("\n" + menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int indexLevel1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[indexLevel1];
                break;
            case 2:
                int indexLevel2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[indexLevel2];
                break;
            case 3:
                int indexLevel3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[indexLevel3];
                break;
            default:
                Debug.LogError("invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            AskForPassword(greeting);
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("YERP! HERES A BOOK FOR UUUUUU");
                Terminal.WriteLine(@"   
                |///// |
                |~~~|  |
                |===|  |
                |j  |  |
                | g |  |
                |  s| /
                |===|/
                '---'
            "
            );
                break;
            case 2:
                Terminal.WriteLine("Your password was Right on the Money! \n ;) ");
                Terminal.WriteLine(@"
                 $
                $$$
               $$$$$$
                $$$
                 $
                "
                );
                break;
            case 3:
                Terminal.WriteLine("You have reached the singularity! ;) ");
                Terminal.WriteLine(@"
         _______
        |.-----.|
        ||x . x||
        ||_.-._||
        `--)-(--`
       __[=== o]___
      |:::::::::::|\
      `-=========-`()
                "
                );
                break;
        }
    }
}

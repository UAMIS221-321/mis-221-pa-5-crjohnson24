using PA5;
using System.Diagnostics;
using System.Net;

//create and call in arrays for each type of class needed
Trainer[]trainers = new Trainer[100];
Listing[]listings = new Listing[100];
Booking[]bookings = new Booking[100];

//create a new instance of each utility class, call it in, and pass in the needed arrays and utilities
TrainerUtility utility = new TrainerUtility(trainers);
ListingUtility utilityTwo = new ListingUtility(listings);
BookingUtility utilityThree = new BookingUtility(bookings, utilityTwo, listings, trainers, utility);
Report report = new Report();


//displaying a welcom to the program with a graphic
string text = @" _       __     __                             __           __  __                                  __
| |     / /__  / /________  ____ ___  ___     / /_____     / /_/ /_  ___     ____ ___  ______ ___  / /
| | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \   / __/ __ \   / __/ __ \/ _ \   / __ `/ / / / __ `__ \/ / 
| |/ |/ /  __/ / /__/ /_/ / / / / / /  __/  / /_/ /_/ /  / /_/ / / /  __/  / /_/ / /_/ / / / / / /_/  
|__/|__/\___/_/\___/\____/_/ /_/ /_/\___/   \__/\____/   \__/_/ /_/\___/   \__, /\__, /_/ /_/ /_(_)   
                                                                          /____//____/                ";
                                                                          

System.Console.WriteLine(text);

//calling the main menu so that it will display options to the user 
MainMenu(utility, utilityTwo, utilityThree, report);

//a method for running the main menu and then in turn running the other menus 
static void MainMenu(TrainerUtility utility, ListingUtility utilityTwo, BookingUtility utilityThree, Report report){
     //welcoming the user to the menu and displaying the menu options to the user so that they can make there selection
    string prompt = @"Welcome to the gym's main menu! Use the arrow keys to navigate the options and then enter to select!";
    //an array of menu options 
    string[]menuOptions = {"Manage trainer data", "Manage listing data", "Manage customer data and book sessions", "Run reports", "Exit"};
    //running the menu as a scrollable menu in which users can go through with arrow keys and choose by using the MenuSelector class
    MenuSelector mainMenu = new MenuSelector (prompt, menuOptions);
    int selectedOption = mainMenu.Run();
    if(selectedOption != 4){
        switch(selectedOption){
            //if user picks first option they will be sent to the trainer menu
            case 0:
            TrainerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if the user picks the second option they will be sent to the listing menu
            case 1:
            ListingMenu(utility, utilityTwo, utilityThree, report);
            break; 

            //if the user picks the third option they will be sent to the customer menu 
            case 2: 
            CustomerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if the user picks the fourth option they will be sent to the report menu
            case 3:
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            // if the user picks an ivalid choice they will be notified and sent back to the main menu to choose again
            default: 
            System.Console.WriteLine("Not a valid menu choice please try again");
            MainMenu(utility, utilityTwo, utilityThree, report);
            break;
        }
    }
    //if the user wishes to exit Bye will be displayed via a graphic and the program will end 
    else{
        string bye = @"________             ______
___  __ )____  _________  /
__  __  |_  / / /  _ \_  / 
_  /_/ /_  /_/ //  __//_/  
/_____/ _\__, / \___/(_)   
        /____/             ";
        System.Console.WriteLine(bye);
    }
}

//a menu for every function relating to trainer information 
static void TrainerMenu(TrainerUtility utility, ListingUtility utilityTwo, BookingUtility utilityThree, Report report){
    //creating and displaying a graphic to the user for user experience 

    string trainGraphic = @" ____  ____   __   __  __ _  ____  ____ 
(_  _)(  _ \ / _\ (  )(  ( \(  __)(  _ \
  )(   )   //    \ )( /    / ) _)  )   /
 (__) (__\_)\_/\_/(__)\_)__)(____)(__\_)";
    System.Console.WriteLine(trainGraphic);
    
    // a welcome to the menu
    string prompt = @"Welcome to the trainer menu!";
    //menu options in an array so that they can be used to input into the scrolling menu
    string [] menuOptions = {"Add a trainer", "Edit a trainer", "Delete a trainer", "Return to the main menu"};
    //using the MenuSelector class to populate the menu and then set the users choice to a variable
    MenuSelector mainMenu = new MenuSelector( prompt, menuOptions);
    int selectedOption = mainMenu.Run();
    
    if(selectedOption !=3){
        switch(selectedOption){
            //if the user picks the first option they will be sent to the add a trainer function and then back to the trainer menu
            //so that they can complete more tasks, go back to the main menu, or exit the program via main menu
            case 0:
            utility.AddTrainer();
            TrainerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if the user picks the second option they will be sent to the fucntion to update a trainers information then back to the trainer menu
            case 1:
            utility.UpdateTrainer();
            TrainerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if the user picks the third option they will be sent to the function that deletes a trainer and then back to trainer menu
            case 2:
            utility.DeleteTrainer();
            TrainerMenu(utility, utilityTwo, utilityThree, report);
            break;
            
            //if the user inputs an invalid choice they will notified and then prompted to re-choose
            default:
            System.Console.WriteLine("not a valid choice. please try again");
            TrainerMenu(utility, utilityTwo, utilityThree, report);
            break;
        }
    }
    //if the user picks the fourth option they will be sent back to the main menu
    else{
        MainMenu(utility, utilityTwo, utilityThree, report);
    }
    
}

//a menu for all listing functionalities
static void ListingMenu(TrainerUtility utility, ListingUtility utilityTwo, BookingUtility utilityThree, Report report){
    
    //creating and displaying a graphic for user experience 
    string listingGraphic = @" __    __  ____  ____    __  ____ 
(  )  (  )/ ___)(_  _)  (  )(_  _)
/ (_/\ )( \___ \  )(     )(   )(  
\____/(__)(____/ (__)   (__) (__) ";

    System.Console.WriteLine(listingGraphic);

    //welcoming the user to the menu
    string prompt = @"Welcome to the listing menu!";
    //an array of menu options
    string [] menuOptions = {"Add a listing", "Update a listing", "Delete a listing", "Return to the main menu"};
    //using the MenuSelector class to call the scroll through menu
    MenuSelector mainMenu = new MenuSelector( prompt, menuOptions);
    int selectedOption = mainMenu.Run();
   
    if( selectedOption != 3){
        switch(selectedOption){
            //if user picks first option they will be sent to add a new listing then back to listing menu to complete more lsiting tasks
            // or go to main menu where they can pick another option or exit
            case 0:
            utilityTwo.AddListing();
            ListingMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user picks second option they will sent to update listing information then back to listing menu
            case 1: 
            utilityTwo.UpdateListing();
            ListingMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user picks the third option they will be sent to delete a listing then back to listing menu
            case 2: 
            utilityTwo.DeleteListing();
            ListingMenu(utility, utilityTwo, utilityThree, report);
            break;

            //informing the user they have made an invalid choice and prompting them to choose again
            default:
            System.Console.WriteLine("not a valid choice. please try again");
            ListingMenu(utility, utilityTwo, utilityThree, report);
            break; 
        }
        
    }
    //sendig the user back to the main menu
    else{
        MainMenu(utility,utilityTwo, utilityThree, report);
    }
}


//a method to display the customer/booking menu to the user and let them pick what they wish to do within the program
static void CustomerMenu(TrainerUtility utility, ListingUtility utilityTwo, BookingUtility utilityThree, Report report){
   
   //creating and displaying a graphic for user experience 
   string sessionGraphic = @" ____   __    __  __ _    __  ____  _   
(  _ \ /  \  /  \(  / )  (  )(_  _)/ \  
 ) _ ((  O )(  O ))  (    )(   )(  \_/  
(____/ \__/  \__/(__\_)  (__) (__) (_)  ";

    System.Console.WriteLine(sessionGraphic);

    //welcoming user to the menu 
    string prompt = @"Welcome to the customer menu!";
    //creating an array of menu options for the scroll through menu
    string [] menuOptions = {"View sessions", "Book a session", "Cancel or complete a session", "Return to the main menu"};
    //using the menu selector class to populate the menu for the user 
    MenuSelector mainMenu = new MenuSelector( prompt, menuOptions);
    int selectedOption = mainMenu.Run();

    if(selectedOption != 3){
        switch(selectedOption){

            //if user picks the first option they will be sent to view available listings then back to customer menu to either complete 
            //more tasks or return to main menu possibly to exit the program 
            case 0:
            utilityThree.ViewSessions();
            CustomerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user pciks the second option they will be sent to book a session then back to customer menu
            case 1:
            utilityThree.BookSession();
            CustomerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user picks the third option they will be sent to either cancel or "complete" their session then back to customer menu
            case 2:
            utilityThree.UpdateSessionStatus();
            CustomerMenu(utility, utilityTwo, utilityThree, report);
            break;

            //informing user of invalid menu choice and prompting them to re-choose
            default:
            System.Console.WriteLine("not a valid choice. please try again");
            CustomerMenu(utility, utilityTwo, utilityThree, report);
            break;

        }
    }
    //sending user back to the main menu if they choose the fourth option 
    else{
        MainMenu(utility, utilityTwo, utilityThree, report);
    }
}

//a report menu to allow the user to generator the reports they wish to obtain
static void ReportMenu(TrainerUtility utility, ListingUtility utilityTwo, BookingUtility utilityThree, Report report){

    //creating and displaying a graphic for user experience 
    string reportGraphic =@" ____  ____  ____   __  ____  ____  ____ 
(  _ \(  __)(  _ \ /  \(  _ \(_  _)/ ___)
 )   / ) _)  ) __/(  O ))   /  )(  \___ \
(__\_)(____)(__)   \__/(__\_) (__) (____/";

    System.Console.WriteLine(reportGraphic);

    //welcoming user to the menu, creating an array of options, and then using MenuSelector class to populate the scroll through menu
    string prompt = @"Welcome to the report menu!";
    string [] menuOptions = {"Individual customer report", "Historical customer report", "Historical revenue report", "Historical trainer report", "Individual trainer report", "Historical date report", "Return to main menu"};
    MenuSelector mainMenu = new MenuSelector( prompt, menuOptions);
    int selectedOption = mainMenu.Run();

    if(selectedOption !=6){
        switch(selectedOption){
            case 0:
            //if user picks first option they will be sent to individual customer report then bacl to report menu
            report.IndividCustomerReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user pciks the second option they will be sent to historical customer report then back to report menu
            case 1: 
            report.HistoricalCustomerReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break; 

            //if user picks the thrid option they will be sent to the historical revenue report then bacl to report menu
            case 2: 
            report.HistoricalRevenueReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            // if user picks the fourth option they will be sent to historical trainer report then bacl to report menu
            case 3:
            report.HistoricalTrainerReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            // if user picks the fifth option they will sent to the individual trainer report then back to report menu
            case 4:
            report.IndividualTrainerUsedReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            //if user pciks the sixth option they will be sent to the date report and then back to report menu
            case 5:
            report.DateMostBookedReport();
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;

            //informing user of an invalid choice and prompting them to re-choose
            default:
            System.Console.WriteLine("not a valid choice. please try again");
            ReportMenu(utility, utilityTwo, utilityThree, report);
            break;
        }
    }
    //sending user back to the main menu if they so choose
    else{
        MainMenu(utility, utilityTwo, utilityThree, report);
    }

}


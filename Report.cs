namespace PA5
{
    public class Report
    {

        private BookingUtility bookingUtility;

        private Booking[] bookings;

        private Listing []listings;


        public Report(){

        }

        //a constructor for the report class creating an instance of it 

        public Report(BookingUtility bookingUtility, Booking[]bookings, Listing[]listings){
            this.bookingUtility = bookingUtility;
            this.bookings = bookings;
            this.listings = listings;
        }


        // an individual customer report that receives the users email, searches through every lsiting for it, then prints out the 
        //customers name and amount of sessions. the user has the option to save the report and based on their answer the report can be
        //saved to the file of their choice through a stream writer writing the name and count to the file 
        public void IndividCustomerReport(){
            System.Console.WriteLine("Please enter customer email adress"); 
            string customerEmail = Console.ReadLine();
            StreamWriter outFile;
            System.Console.WriteLine("Would you like to save this report");
            string userInput = Console.ReadLine().ToUpper();
            string fileName = "";
            if(userInput == "YES"){
                System.Console.WriteLine("What would you like to name the file");
                fileName = Console.ReadLine(); 
                outFile = new StreamWriter(fileName);
            }

            int count =0;
            
            for (int i=0; i<Booking.GetCount(); i++){
               
                if (bookings[i].GetCustomerEmail() == customerEmail){
                    System.Console.WriteLine(bookings[i]);
                    count ++;
                    if(userInput == "YES"){
                        outFile = new StreamWriter(fileName, true);
                        outFile.WriteLine($"{bookings[i]}      {count}");
                        outFile.Close();
                    }
                    
                }
            }
            System.Console.WriteLine($"the customer had {count} sessions");

        }

        //a sort method which goes through the bookings array comparing each customer name and swapping them until they are grouped 
        //accoriding to name 
        public void SortByName(){
            for (int i=0; i<Booking.GetCount()-1; i++){
                int min = i;
                for( int j=1; j<Booking.GetCount(); j++){
                    if(bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName())<0){
                        min = j;
                    }
                    if(min != i){
                        Swap(min, i);
                    }
                }
            }
        }


        //a swap method to switch the positions of data in an array by temporarily setting one to a variable then setting the other to the origanl
        //lastly, it then sets the temporary to the second variable 
        public void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x]=bookings[y];
            bookings[y]=temp;
        }

        //a method to create a report of every customer and the amount of sessions they had. sorts the bookings by name and then by date 
        //uses a for loop to go through all the bookings in the bookings array counting how much each customer had using their name. 
        //each time through the loop the count increases. when the name changes, a process break is called display the name and count and 
        //then reset the name and restart the count, repeating the process until the array has been completely gone through
        public void HistoricalCustomerReport(){
            
            SortByName(); 
            SortByDate();
            System.Console.WriteLine(bookings);
            System.Console.WriteLine("Would you like to save the report?");
            string userInput = Console.ReadLine().ToUpper();

            string currName = bookings[0].GetCustomerName();
            int count =1; 
            for(int i=1; i<Booking.GetCount(); i++){
                if(bookings[i].GetCustomerName()==currName){
                    count++;
                    if(userInput == "YES"){
                        System.Console.WriteLine("What is the name of the file you would like to save the report to");
                        string fileName = Console.ReadLine();
                        StreamWriter outFile = new StreamWriter(fileName);
                        outFile.WriteLine($"{bookings[i]}      {count}");
                        outFile.Close();
                    }
                else {
                    ProcessBreak(ref count, ref currName, i);
            }
            
            }
            ProcessBreak(ref count, ref currName, 0);
         }
        }

        //a process break to display the current name and count and then reset them both so a for loop can run again
        public void ProcessBreak(ref int count, ref string currName, int i){
            System.Console.WriteLine($"{currName} had {count} sessions");
            currName = bookings[i].GetCustomerName();
            count = 1;
        }
        
    
        // a method to sort the bookings array by date by going through each booking and comparing their dates then swapping them based on the
        //value
        public void SortByDate(){
            for (int i=0; i<Booking.GetCount()-1; i++){
                int min = i;
                for( int j=1; j<Booking.GetCount(); j++){
                    if(bookings[j].GetTrainingDate().CompareTo(bookings[min].GetTrainingDate())<0){
                        min=j;
                    }
                    if(min!=i){
                        Swap(min,i);
                    }
                }

            }
        }

        //a historical revenue report that uses the bookings array in a for loop counting the revenue for the month then the year, once a 
        //month or year changes a process break is called to reset the values so that the loop can run until everything in the array has been used
        public void HistoricalRevenueReport(){
            
            SortByDate();

            int currMonth = bookings[0].GetTrainingDate().Month;  
            int currYear = bookings[0].GetTrainingDate().Year;
            int countMonth = 1;
            int countYear=1;

            double monthRevenue = listings[0].GetSessionCost();
            double yearRevenue = listings[0].GetSessionCost();

            System.Console.WriteLine("Would you like to save the report?");
            string userInput = Console.ReadLine().ToUpper();

            for(int i=1; i<Booking.GetCount(); i++){
                if(userInput=="YES"){
                    System.Console.WriteLine("What is the name of the file you wish to save the report to?");
                    string fileName = Console.ReadLine().ToUpper();
                    StreamWriter outFile;
                    if(bookings[i].GetSessionStatus() != "Canceled"){
                        if(bookings[i].GetTrainingDate().Year==currYear){
                            yearRevenue+= listings[i].GetSessionCost(); 
                            countYear++;
                            if(bookings[i].GetTrainingDate().Month == currMonth){
                                monthRevenue+= listings[i].GetSessionCost();
                                countMonth++;
                            }
                            if(userInput=="YES"){
                                new StreamWriter(fileName);
                                outFile = new StreamWriter(fileName, true);
                                outFile.WriteLine($"{currMonth}'s Revenue was {monthRevenue}");
                                outFile.WriteLine($"{currYear}'s Revenue was {yearRevenue}");
                                outFile.Close();
                            }
                                
                            ProcessBreakMonth(ref currMonth, ref monthRevenue, i, countMonth);
                        }
                        ProcessBreakYear(ref currYear, ref yearRevenue, i, countYear);
                       
                    }
                
                
            }
            }
            ProcessBreakMonth( ref currMonth, ref monthRevenue, 0, countMonth);
            ProcessBreakYear(ref currYear, ref yearRevenue, 0, countYear);

            
        }

        //a process break that displays the current month and its revenue then resets both values so that the for loop can run again
        public void ProcessBreakMonth(ref int currMonth, ref double monthRevenue, int i, int countMonth){
            System.Console.WriteLine($"{currMonth}'s Revenue was {monthRevenue}");
            currMonth = bookings[countMonth].GetTrainingDate().Month;
            monthRevenue = listings[countMonth].GetSessionCost();
            
        }

        //a process break that displays the current year and its revenue then resets both values so that the for loop can run again
        public void ProcessBreakYear( ref int currYear, ref double yearRevenue, int i, int countYear){
            System.Console.WriteLine($"{currYear}'s Revenue was {yearRevenue}");
            currYear=bookings[countYear].GetTrainingDate().Year;
            yearRevenue = listings[countYear].GetSessionCost();
        }

        //a historical trainer report in which each trainer is counted for the amount of sessions they have booked and then it displays them all
        //uses a for loop to go through the bookings array comparing each name and increasing the count each time. when the name changes
        //a process break is called 
        public void HistoricalTrainerReport(){
            SortByName();
            string currTrainer = bookings[0].GetTrainerName();
            int count =1;
            System.Console.WriteLine("Would you like to save the report?");
            string userInput = Console.ReadLine().ToUpper();

            for(int i=1; i<Booking.GetCount(); i++){
                if(bookings[i].GetTrainerName()==currTrainer){
                    count++;
                }
                 if(userInput =="YES"){
                    System.Console.WriteLine("What is the name of the file that you would like to save the report to?");
                    string fileName = Console.ReadLine();
                    StreamWriter outFile = new StreamWriter(fileName);
                    outFile.WriteLine($"{currTrainer} had {count} sessions");
                    outFile.Close();
                }
                ProcessBreakMT(ref currTrainer, ref count, i);
            }
            ProcessBreakMT(ref currTrainer, ref count, 0);  

        }

        //a process break to display the current trainer and their amount of sessions. it then resets each variable so that the for loop can
        //run again until everything in the array has been counted
        public void ProcessBreakMT(ref string currTrainer, ref int count, int i){
            System.Console.WriteLine($"{currTrainer} had {count} sessions.");
            currTrainer = bookings[i].GetTrainerName();
            count = 1;

        }

        //an individual trianer report so that a trainer can enter their ID and a for loop finds each time their ID appears and increases the
        //count, once the array has been fully gone through it displays the trianers name and amount of sessions they had
        public void IndividualTrainerUsedReport(){
            int count= 1;
            System.Console.WriteLine("Please enter the trainer's ID");
            int trainerID = bookings[0].GetTrainerID();
            System.Console.WriteLine("Would you like to save the report?");
            string userChoice = Console.ReadLine().ToUpper();
            StreamWriter outFile;
            string fileName = "";
            if(userChoice == "YES"){
                System.Console.WriteLine("What would you like to name the file");
                fileName = Console.ReadLine(); 
                
            
            }

            for(int i=1; i<Booking.GetCount()-1; i++){
                if(bookings[i].GetTrainerID()== trainerID){
                    count++;
                }
                if(userChoice == "YES"){
                    outFile = new StreamWriter(fileName);
                    outFile.WriteLine($" trainer {trainerID} had {count} sessions");
                }
            }
            System.Console.WriteLine($" trainer{trainerID} had {count} sessions.");
           
        }


        //a report to count how many sessions were on each day. goes through the bookings array checking the date to the current date set as the
        //first date in the array and increases the count until the date changes. a process break is then called 
        public void DateMostBookedReport(){
            SortByDate();
            DateOnly currDate = bookings[0].GetTrainingDate();
            int count = 1;
            System.Console.WriteLine("Would you like to save the report?");
            string userChoice = Console.ReadLine().ToUpper();
            StreamWriter outFile;
            string fileName = "";

            for(int i=1; i<Booking.GetCount(); i++){
                if(bookings[i].GetTrainingDate()==currDate){
                    count++;
                }
                if(userChoice == "YES"){
                    System.Console.WriteLine("What is the name of the file you would like to save the report to?");
                    fileName = Console.ReadLine();
                    outFile = new StreamWriter(fileName);
                    outFile.WriteLine($"{currDate} had {count} sessions");
                }
                ProcessBreakDate(ref currDate, ref count, i);
            }
            ProcessBreakDate(ref currDate, ref count, 0);
        }

        //a process break to display the current date and the sessions that occured on it. it then resets each variable so that the for loop can run again
        public void ProcessBreakDate(ref DateOnly currDate, ref int count, int i){
            System.Console.WriteLine($"{currDate} had {count} sessions");
            currDate = bookings[i].GetTrainingDate();
            count = 1;
        }

    }
}

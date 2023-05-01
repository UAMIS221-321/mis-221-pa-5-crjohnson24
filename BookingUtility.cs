namespace PA5
{
    public class BookingUtility
    {

        //calling in other classes so that their information can be used in methods within this class
        private Booking[]bookings;
        private ListingUtility listingUtility;
        private Listing []listings;
        private Trainer [] trainers;
        private TrainerUtility trainerUtility;

       

        //a constructor for the class creating an instance of it 
        public BookingUtility(Booking[] bookings, ListingUtility listingUtility, Listing[]listings, Trainer[] trainers, TrainerUtility trainerUtility){
            this.bookings = bookings;
            this.listingUtility = listingUtility;
            this.listings = listings;
            this.trainers = trainers;
            this.trainerUtility = trainerUtility;
            GetBookingsFromFile();
        }
        
        //a method to print out all listings to the user 
        public void ViewSessions(){
            listingUtility.PrintListings();
            
        }

        // a method to retrieve all the bookings from a file by opening the file, reading it in as long as it is not null, putting the 
        //information back into their original data types, putting them into an array , increasing the count, and then closing the file
        public void GetBookingsFromFile(){
            StreamReader inFile = new StreamReader("transactions.txt");
            int bookingCount = 0;

            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[]temp = line.Split("#");
                bookingCount += temp.Length;
                int sessionID = int.Parse(temp[0]);
                DateOnly trainingDate = DateOnly.Parse(temp[3]);
                int trainerID = int.Parse(temp[4]);
                bookings[Booking.GetCount()]= new Booking(sessionID, temp[1], temp[2], trainingDate, trainerID, temp[5], temp[6]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        
        //a method to book a session. Prints out all lisitings so that the user can input the ID of the listing they would like to 
        //book then has the user input their own information and sets all fields of the class so that they can be saved. Increases count
        //of bookings.
        public void BookSession(){
            Booking newBooking = new Booking();

            listingUtility.PrintListings();
            //choose the listing by ID

            System.Console.WriteLine("what is the ID of the session you would like to book?");
            int sessionPick = int.Parse(Console.ReadLine());

            newBooking.SetSessionID();
            System.Console.WriteLine("please enter your name");
            newBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("please enter your email adress");
            newBooking.SetCustomerEmail(Console.ReadLine());

            int listingToBook = listingUtility.FindListing(sessionPick);
            
            newBooking.SetTrainingDate(listings[listingToBook].GetSessionDate());
            newBooking.SetTrainerName(listings[listingToBook].GetTrainerName());
            string trainerName = listings[listingToBook].GetTrainerName();

            int trainerInBooking = trainerUtility.FindTrainer(trainerName);
            newBooking.SetTrainerID(trainers[trainerInBooking].GetTrainerID());
            newBooking.SetSessionStatus("booked");
            
            bookings[Booking.GetCount()] = newBooking;
            Save(bookings);
            Booking.IncCount();
            
        }

        //a method to save a booking by writing to the transactions file through a stream write with a for loop so that it cycles through
        //the bookings writing them all to the file and then closing the file 
        public void Save(Booking [] bookings){
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for (int i=0; i<Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            } 

            outFile.Close();
        }


        //a method to find a session by using a for loop to go through all of the bookings in the bookings array and comparing their
        //IDs to the desired ID and then returning the entire booking
        public Booking FindSession(int session){
            Booking booking = new Booking();
            for( int i = 0; i<Booking.GetCount(); i++){
                if(bookings[i].GetSessionID()==session){
                    booking = bookings[i];
                }
            }
            return booking;
        }


        //a method to either cancel a booking or tell the system it has been completed by prompting the user for the ID changing the
        //session status based upon the users input and then saving the information
        public void UpdateSessionStatus(){
            
            System.Console.WriteLine("enter the ID of your session");
            int sessionToUpdate = int.Parse(Console.ReadLine());
            Booking val = FindSession(sessionToUpdate);

            System.Console.WriteLine("Would you like to cancel your session?");
            string userInput = Console.ReadLine().ToUpper();
            if(userInput== "YES"){
                val.SetSessionStatus("Canceled");
            }
            System.Console.WriteLine("Did you complete your session");
            string userInputTwo = Console.ReadLine().ToUpper();
            if(userInputTwo == "YES"){
                val.SetSessionStatus("Completed");
            }

            Save(bookings);
            
        }


    }
}
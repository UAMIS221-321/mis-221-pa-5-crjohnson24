namespace PA5
{
    public class ListingUtility
    {
        private Listing []listings;


        //constructor for the listing utility class 
        public ListingUtility(Listing[]listings){
            this.listings = listings;
            GetListingsFromFile(listings);
        }

        // a method to add a listing by settign variables via prompting the user and autmoatic setting(ID) then it saves the information
        //to the file replacing the wrong information
        public void AddListing(){
            Listing newListing = new Listing();

            newListing.SetListingID();
            System.Console.WriteLine("Enter trainer name");
            newListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Enter session date");
            newListing.SetSessionDate(DateOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter session time ");
            newListing.SetSessionTime(TimeOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter session cost");
            newListing.SetSessionCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("Is the sesion available");
            if(Console.ReadLine() == "yes"){
                newListing.SetSessionIsAvailable();
            }
            
            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();
        
            Save();
            GetListingsFromFile(listings);
        }


        //a method to save infromation to the file by using a for loop to go through the lisitngs array arranging the information
        //in the format suitable for the fil through a writeline then closing the file
        public void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");

            for (int i=0; i<Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            } 

            outFile.Close();
        }

        //a method to retreive all lsitings from the file by opening the file, and while it is not null reading in the information, splitting
        //it, putting it in the correct data type, placing it in an array, increasing the count, then closing the file 
        public void GetListingsFromFile(Listing[]listings){
            StreamReader inFile = new StreamReader("listings.txt");

            int listingCount = 0;
            Listing.SetCount(0);

            string line = inFile.ReadLine();
            while(line != null && line!= ""){
                string[]temp = line.Split("#");
                listingCount += temp.Length;
                int listingID = int.Parse(temp[0]);
                DateOnly sessionDate = DateOnly.Parse(temp[2]);
                TimeOnly sessionTime = TimeOnly.Parse(temp[3]);
                double sessionCost = double.Parse(temp[4]);
                bool sessionIsAvailable = bool.Parse(temp[5]);
                listings[Listing.GetCount()]= new Listing(listingID, temp[1], sessionDate, sessionTime, sessionCost, sessionIsAvailable);
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        //a method to find a lsiitng ID via a for loop by going through the lsitings array, comparing the desired ID to each lisitng ID
        //then either returning the postion of the array in which the lsitings sits or notfying the user the ID could not be found
        public int Find(int searchVal){
            for(int i=0; i<Listing.GetCount(); i++){
                if(listings[i].GetListingID()==searchVal){
                    return i;
                }
            }
            return -1;
        }

        //a method to find an entire listing by using a for loop to go through the array of listings comparing each ID to the desired
        //one and then returning the position if it is found or notifying the user if it could not be found 
        public int FindListing(int sessionPick){
            Listing listing = new Listing();
            for( int i = 0; i<Listing.GetCount(); i++){
                if(listings[i].GetListingID()==sessionPick){
                    return i;
                }
            }
            return -1;
        }

        //a method to update a listing by obtaining the listing ID so it can be found then prompting the user for the correct
        //information of the lsiting then saving it. If the lsiting could not be found the user will be informed
        public void UpdateListing(){
            System.Console.WriteLine("Please enter the ID of the listing you would to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if( foundIndex != -1){
                System.Console.WriteLine("Please enter session date");
                listings[foundIndex].SetSessionDate(DateOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter session time");
                listings[foundIndex].SetSessionTime(TimeOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please session cost");
                listings[foundIndex].SetSessionCost(double.Parse(Console.ReadLine()));
                System.Console.WriteLine("Is the session taken?");
                if(Console.ReadLine() == "yes"){
                    listings[foundIndex].SetSessionIsAvailable();
                }
                Save();
            }
            else{
                System.Console.WriteLine("Listing not found");
            }

        }

        //a method to delete a listong by obtaining the ID, finding the lsiitng, then swapping the boolean value 
        //if the lsiting could not be found the user will be informed 
        public void DeleteListing(){
            System.Console.WriteLine("Please enter the ID of the session you would to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if( foundIndex != -1){
               listings[foundIndex].SetIsDeleted();
                Save();
            }

            else{
                System.Console.WriteLine("Listing not found");
            }
        
        }

        // a method to print out all the listings to the user by going through each line of the lsiitngs array with a for loop
        // then writing each line out to the user in addition to the to string method
        public void PrintListings(){
                for (int i=0; i<Listing.GetCount(); i++){
                    if( listings[i].GetSessionIsAvailabile() == true ){
                        System.Console.WriteLine(listings[i].ToString());
                    }
                }
        }
    }
}
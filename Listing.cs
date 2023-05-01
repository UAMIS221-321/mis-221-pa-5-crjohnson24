namespace PA5
{
    public class Listing
    {
        //creating fields for the class 
        private int listingID;

        private string trainerName;

        private DateOnly sessionDate;

        private TimeOnly sessionTime;

        private double sessionCost;

        private bool sessionIsAvailable;

        private bool isDeleted;

        static private int count;


        //a no arg constructor that sets the value of the boolean for session availabilty 
        public Listing(){
            this.sessionIsAvailable = true;
        }

        //an arg constructor that takes the fields as arguments and then creates an instance of the class 
        public Listing( int listingID, string trainerName, DateOnly sessionDate, TimeOnly sessionTime, double sessionCost, bool sessionIsAvailable){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.sessionCost = sessionCost; 
            this.sessionIsAvailable = sessionIsAvailable;
            this.isDeleted = isDeleted;
        }


        //sets the name of the trainer for an instance of the class 
        public void SetTrainerName(string trainerName){
            this.trainerName= trainerName;
        }

        //returns the trainers name
        public string GetTrainerName(){
            return trainerName;
        }

        //sets the listing ID for an instance of the class
        public void SetListingID(){
            this.listingID = count +1;
        }

        //returns the listing ID
        public int GetListingID(){
            return listingID;
        }

        //sets the session date for an instance of the class
        public void SetSessionDate( DateOnly sessionDate){
            this.sessionDate = sessionDate;
        }

        //returns the session date 
        public DateOnly GetSessionDate(){
            return sessionDate;
        }

        //sets the session time for an instance of the class 
        public void SetSessionTime( TimeOnly sessionTime){
            this.sessionTime = sessionTime;
        }

        //returns the session time 
        public TimeOnly GetSessionTime(){
            return sessionTime;
        }

        //sets the session cost for an instance of the class
        public void SetSessionCost( double sessionCost){
            this.sessionCost = sessionCost;
        }

        //returns the session cost 
        public double GetSessionCost(){
            return sessionCost;
        }

        //sets the session availability using a boolean to swap it for an instance of the class
        public void SetSessionIsAvailable(){
            sessionIsAvailable = !sessionIsAvailable;
        }

        //returns the session availability
        public bool GetSessionIsAvailabile(){
            return sessionIsAvailable;
        }

        //sets the class variable count
       static public void SetCount(int trainerCount){
            Listing.count = count;
        }

        //increases the class variable count 
        static public void IncCount(){
            count ++;
        }

        //decreases the class variable count 
        static public void DecCount(){
            count --;
        }

        //returns the class variable count 
        static public int GetCount(){
            return Listing.count; 
        }

        //arranges the variables of an instance into the format in which it should be saved to the listings file 
        public string ToFile()
        {
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{sessionCost}#{sessionIsAvailable}";
        }

        //arranges the variables of an instance into a string 
        public string ToString(){
            return $"{listingID} {trainerName} {sessionDate} {sessionCost} {sessionIsAvailable}";
        }

        //a boolean to swap the deleted status of a listing if it is taken down 
        public void SetIsDeleted(){
            isDeleted = !isDeleted;
        }

        //returns if the listing is deleted or not 
        public bool GetIsDeleted(){
            return isDeleted;
        }


    }
}
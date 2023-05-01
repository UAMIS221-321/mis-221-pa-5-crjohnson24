namespace PA5
{
    public class Booking
    {
        //setting the fields of the class 
        private int sessionID;

        private string customerName;

        private string customerEmail;

        private DateOnly trainingDate;

        private int trainerID;

        private string trainerName;

        private string sessionStatus;

        static private int count;


        //a no arg constructor for the class 
        public Booking(){
            
        }

        // an arg constructor taking the fields as arguments creating an instance of the class 
        public Booking(int sessionID, string customerName, string customerEmail, DateOnly trainingDate,int trainerID, string trainerName, string sessionStatus){
            this.customerName = customerName; 
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.sessionID = sessionID ;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.sessionStatus = "open";
            //check about session status
        }

        //sets the customer name in an instance of the class 
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
            
        }

        //returns the customer name 
        public string GetCustomerName(){
            return customerName;
        }

        //sets the customer email in an instance of the class
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        //returns the customer email
        public string GetCustomerEmail(){
            return customerEmail;
        }

        //sets the training date in an instance of the class
        public void SetTrainingDate( DateOnly trainingDate){
            this.trainingDate = trainingDate;
        }

        //returns the training date 
        public DateOnly GetTrainingDate(){
            return trainingDate;
        }

        //sets the trainer ID in the instance of the class
        public void SetTrainerID(int trainerID){
             this.trainerID = this.trainerID;
        }

        //returns the trainer ID 
        public int GetTrainerID(){
            return trainerID;
        }

        //sets the session ID in the instance of the class
        public void SetSessionID(){
            this.sessionID = count +1; 
        }

        //returns the session ID
        public int GetSessionID(){
            return sessionID;
        }

        //sets the trainer name in the instance of the class
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        //returns the trainer name
        public string GetTrainerName(){
            return trainerName;
        }

        //sets the session status in an instance of the class
        public void SetSessionStatus(string sessionStatus){
            this.sessionStatus = sessionStatus;
        }

        //returns the session status 
        public string GetSessionStatus(){
            return sessionStatus;
        }

        //sets the class variable 
        static public void SetCount(int trainerCount){
            Booking.count = count;
        }

        //increases the count 
        static public void IncCount(){
            count ++;
        }

        //decreases the count 
        static public void DecCount(){
            count --;
        }

        //returns the count 
        static public int GetCount(){
            return Booking.count; 
        }

        //arranging the variables of an instance of the class into a format to be saved into the transactions file
        public string ToFile()
        {
            return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{sessionStatus}";
        }

        //arranges the variables of an instance of the claass into a string 
        public string ToString(){
            return $" {sessionID} {customerName} {customerEmail} {trainingDate} {trainerID} {trainerName} {sessionStatus}";
        }
    }
}

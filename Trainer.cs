namespace PA5
{
    public class Trainer
    {
        //setting private fields for the class all for instance except one class variable: count
        private int trainerID;

        private string trainerName;

        private string trainerMailingAddress;

        private string trainerEmail;

        private bool isDeleted;

        static private int count;

        //no arg constructor for the Trainer class
        public Trainer(){
    
        }

        //arg constructor for the trainer class with each of its fields as an argument, creating an instance of the class
        public Trainer(int trainerID, string trainerName, string trainerMailingAddress, string trainerEmail, bool isDeleted){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.trainerMailingAddress = trainerMailingAddress;
            this.trainerEmail = trainerEmail;
            this.isDeleted = isDeleted;
        }


        //setting trainer ID to the class variable count+1 in an instance of the class
        public void SetTrainerID(){
            this.trainerID = count + 1;
        }

        //returns trainer ID
        public int GetTrainerID(){
            return trainerID;
        }
       
       //sets the trainer name in the instance of a class
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        //returns the trainer name
        public string GetTrainerName(){
            return trainerName;
        }

        //sets the trainer mailing address in the instance of the class
        public void SetTrainerMail(string trainerMailAddress){
            this.trainerMailingAddress = trainerMailingAddress;
        }

        //returns the trainer mailing address
        public string GetTrainerMail(){ 
            return trainerMailingAddress;
        }
        
        //sets the trainer email in an instance of the class
        public void SetTrainerEmail(string trainerEmail){
            this.trainerEmail = trainerEmail;
        }

        //returns the trainer email
        public string GetTrainerEmail(){
            return trainerEmail;
        }

        //setting the class variable 
        static public void SetCount(int trainerCount){
            Trainer.count = count;
        }

        //increases the count when a new instance is made 
        static public void IncCount(){
            count ++;
        }

        //decreases the count on the occasion a trainer is deleted 
        static public void DecCount(){
            count --;
        }

        //returns the class count
        static public int GetCount(){
            return Trainer.count; 
        }

        //making the variables of the class into a continuous string to stored in a file
        public string ToFile()
        {
            return $"{trainerID}#{trainerName}#{trainerMailingAddress}#{trainerEmail}#{isDeleted}";
        }

        //setting a boolean for the deleted feature so that it can be swapped for soft deletes
        public void SetIsDeleted(){
            isDeleted = !isDeleted;
        }

        //returns true or false for the boolean 
        public bool GetIsDeleted(){
            return isDeleted;
        }

  }

}
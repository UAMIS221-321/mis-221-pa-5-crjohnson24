namespace PA5
{
    public class TrainerUtility
    {
        private Trainer []trainers; 

        //constructor for the trainer utility class 
        public TrainerUtility(Trainer[]trainers){
            this.trainers = trainers;
            GetTrainersFromFile(trainers);
        }


        // a method that adds a trainer by collecting information from the user and setting variables itself then saves them to the trainers file
        //also increases the count so that the next trainer created receives a unique ID
        public void AddTrainer(){
            Trainer newTrainer = new Trainer();

            newTrainer.SetTrainerID();
            System.Console.WriteLine("enter trainer name");
            newTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("enter mailing address? ");
            newTrainer.SetTrainerMail(Console.ReadLine());
            System.Console.WriteLine("enter email address?");
            newTrainer.SetTrainerEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = newTrainer;
             Trainer.IncCount();
            Save(trainers);


        }

        // a method that uses a for loop to go through the trainers array and put all variables together in a format suitable for the 
        //file. It then uses a writline to the file to place text in it and closes the file 
        public void Save(Trainer [] trainers){
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for (int i=0; i<Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            } 
            outFile.Close();
        }

        // a method to retrieve all trainers from the trainers file by placing them in array in their original data types
        public void GetTrainersFromFile(Trainer[]trainers){
            StreamReader inFile = new StreamReader("trainers.txt");

            int trainerCount = 0;
            Trainer.SetCount(0);

            string line = inFile.ReadLine();
            while(line != null){
                string[]temp = line.Split("#");
                trainerCount += temp.Length;
                int trainerID = int.Parse(temp[0]);
                bool isDeleted = bool.Parse(temp[4]);
                trainers[Trainer.GetCount()]= new Trainer(trainerID, temp[1], temp[2], temp[3], isDeleted);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }


        // a method that uses a for loop to go through the trainers array, retrieve its ID number, and compare it to the desired ID
        //it returns the array position if found and if not it returns -1
        public int Find(int searchVal){
            for(int i=0; i<Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerID()==searchVal){
                    return i;
                }
            }
            return -1;
        }

        // a mthod that uses a for loop to go thrugh the trainers array retireve the trainer name and compare it to desired name
        //returns position in array if found or -1 if not found 
        public int FindTrainer(string trainerName){
            Trainer trainer = new Trainer();
            for( int i = 0; i<Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerName()==trainerName){
                    return i;
                }
            }
            return -1;
        }

        //a method that updates trainer information by searching for the ID of the desired trainer, prompting the user to enter the trainers
        //information then saving it. If the trainer ID was not found the user will be informed 
        public void UpdateTrainer(){
            System.Console.WriteLine("Please enter the ID of the trainer you would to update");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if( foundIndex != -1){
                System.Console.WriteLine("Please enter trainer name");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter tainer mailing address");
                trainers[foundIndex].SetTrainerMail(Console.ReadLine());
                System.Console.WriteLine("Please enter trainer email");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save(trainers);
            }
            else{
                System.Console.WriteLine("Trainer not found");
            }

        }


        // a method to delete a trainer by prompting the user for ID of the trainer then searching for it and swapping the boolean value
        //if the trainer was not found the user will be informed 
        public void DeleteTrainer(){
            System.Console.WriteLine("Please enter the ID of the trainer you would to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);
            if( foundIndex != -1){
               trainers[foundIndex].SetIsDeleted();
                Save(trainers);
                Trainer.DecCount();
            }

            else{
                System.Console.WriteLine("Trainer not found");
            }
        
        }

    }


}

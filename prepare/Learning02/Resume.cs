public class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();

        public void PrintResume()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Jobs:");
            foreach (Job position in _jobs)
            {
                position.PrintPosition();
            }
        }
    }
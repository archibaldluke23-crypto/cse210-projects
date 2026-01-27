using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2018;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Construction Worker";
        job2._company = "Bob's builders";
        job2._startYear = 2016;
        job2._endYear = 2018;


        Resume resume = new Resume();
        resume._name = "Luke Archibald";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.PrintResume();

    }
        
}
    

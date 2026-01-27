public class Job
    {
        //company, job title, start year, and end year.
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        public void PrintPosition()
        {
            //"Job Title (Company) StartYear-EndYear"
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
        }
        
    }
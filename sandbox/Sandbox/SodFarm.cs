// Sod Farm Activity

// TODO:
// 1. Create a Plot class that has the dimensions of a rectangular sod farm plot in feet
// 2. Complete the TODO in Run
// 3. Complete the SavePlot() function
// Stretch Activities
// 1. Add a name to plot
// 2. How would the plots be loaded from file?

namespace SodFarm

{
    

    // The Plot Class

    public class Plot

    {

        // TODO: create class members for length and width
        public double _length;
        public double _width;


        // TODO: create a method for calculating area
        public double GetArea()
        {
            return _length * _width;
        }

    }

    class PlotManager

    {

        public string _fileName = "sodfarm.txt";

        public List<Plot> _plots = new List<Plot>();

        /// <summary>

        /// Run the program, collecting dimensions for individule plots and add them together

        /// </summary>
        static void Main(string[] args)
        {
            PlotManager plotManager = new PlotManager();
            plotManager.Run();
        }
        public void Run()

        {

            do

            {

                Console.Write("Add a plot? (y/n) ");

                if (Console.ReadLine().ToLower() == "n")

                    break;

                try

                {

                    Console.Write("Enter Length (ft): ");

                    double l = double.Parse(Console.ReadLine());

                    Console.Write("Enter Width (ft): ");

                    double w = double.Parse(Console.ReadLine());

                    // TODO: create a new plot and add it to the list
                    Plot newPlot = new Plot();
                    newPlot._length = l;
                    newPlot._width = w;
                
                    _plots.Add(newPlot);


                }

                catch (FormatException)

                {

                    Console.WriteLine("Invalid input. Please enter numeric values.");

                }                

            } while (true);

            // Display Plot list

            DisplayPlots();

            // Display total area

            Console.WriteLine($"Total Area is: {CalculateTotalArea()} ft^2");

            // Save the plots to disk

            SavePlots();

        }

        /// <summary>

        /// Iterate through the plots and calculate the total area

        /// </summary>

        /// <returns></returns>

        public double CalculateTotalArea()

        {

            double totalArea = 0;

            foreach (Plot p in _plots)

            {

                totalArea =+ p.GetArea();

            }            

            return totalArea;

        }

        /// <summary>

        /// Displays all plots, including dimensions and area

        /// </summary>

        public void DisplayPlots()

        {

            if (_plots.Count == 0)

            {

                Console.WriteLine("No plots found.");

                return;

            }

            foreach (Plot p in _plots)

            {

                Console.WriteLine(p.ToString());

            }

        }

        /// <summary>

        /// Writes all plots to a file, one plot per line

        /// Note: _filename is the output file path

        /// </summary>

        public void SavePlots()

        {
            // Save the plots to file (one plot per line)
            Console.Write("What is your file name? ");
            string fileName = Console.ReadLine();
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Plot plot in _plots)
                outputFile.WriteLine($"{plot}\n");
            }

        }

   }

}

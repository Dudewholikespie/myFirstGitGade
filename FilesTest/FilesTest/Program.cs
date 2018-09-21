using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilesTest
{
    class Program
    {
        private class Unit
        {
            private string name;
            private int x;
            private int y;

            public Unit(string name, int x , int y)
            {
                this.name = name;
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return "\n"+ "My name eh " + name + " My Position is { " + x + " , " + y + "}";
            }
            private string saveMe()
            {
                return name + " , " + x + " , " + y;
        }
            public void Saves()
            {
                if (Directory.Exists("saves") != true)
                {
                    Directory.CreateDirectory("saves");
                    Console.WriteLine("Directory Created!");
                }
                FileStream file = new FileStream("saves/save.file", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine(saveMe());
                writer.Close();
                file.Close();


            }
        }
        static void Main(string[] args)
        {
          /*  if(Directory.Exists("saves") != true)
                {
                Directory.CreateDirectory("saves");
                Console.WriteLine("Directory Created!");
            }
            else
            {
                Console.WriteLine("Directory already exists!");
                Console.WriteLine("Trying to create File...");
                if(File.Exists("saves/save.file") != true)
                {
                    File.Create("saves/save.file").Close();
                    Console.WriteLine("Created FIle!");
                }
                else
                {
                    Console.WriteLine("Already Created File!");
                }

            }*/
            CreateUnits();
            LoadFile();
        }
        static void LoadFile()
        {
            FileStream file = new FileStream("saves/save.file", FileMode.Open, FileAccess.Read);
            /*StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] unit = line.Split(',');
                string name = unit[0];
                int x = Convert.ToInt32(unit[1]);
                int y = Convert.ToInt32(unit[2]);

                Unit newUnit = new Unit(name, x, y);
                Console.WriteLine(newUnit.ToString());

                line = reader.ReadLine();*/
            //}
            //reader.Close();
            //file.Close();
            string[] completeFile = File.ReadAllLines("saves/save.file");
            Unit[] units = new Unit[completeFile.Length];
            for(int i = 0; i<completeFile.Length; i++)
            {
                string[] unit = completeFile[i].Split(',');
                string name = unit[0];
                int x = Convert.ToInt32(unit[1]);
                int y = Convert.ToInt32(unit[2]);
                units[i] = new Unit(name, x, y);

            }
            for(int i = 0; i< units.Length; i++)
            {
                Console.WriteLine(units[i].ToString());
            }
            file.Close();
        }
        static void CreateUnits()


        {
            bool inputting = true;
            while (inputting == true)
            {
                Console.WriteLine("Please create a unit");
                Console.Write("Please enter an name");
                string name = Console.ReadLine();
                Console.Write("Please enter an x position");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter a y position");
                int y = Convert.ToInt32(Console.ReadLine());
                Unit newUnit = new Unit(name, x, y);
                newUnit.Saves();

                Console.WriteLine("Do you want to creat a new unit? Y/N");
                string input = Console.ReadLine();
                if (input == "N")
                {
                    inputting = false;
                }

            }
        }
      
    }
}

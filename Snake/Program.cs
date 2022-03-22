using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static int[,] matrix;
        static int startX = 7;
        static int startY = 11;
        static String option = "c";
        static String color = "blue";
        static int round = 0;



        static void Main(string[] args)
        {
            
            showMatrix();
            move();
            Console.WriteLine("");
            Console.WriteLine("Pulse cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void move()
        {
            int x = startX/2;
            int y = startY / 2;
            matrix[x, y] = 0;
            showMatrix();


            while (option != "p")
            {
                Console.WriteLine("Keys WASD to move // p to stop");
                option = Console.ReadLine();

                switch (option) 
                { 
                    case "w":
                        if (checkMovement(x - 1, y))
                        {
                            x--;
                            matrix[x, y] = 0;
                        }                                            
                        
                        showMatrix();
                    break;
                    case "a":
                        if (checkMovement(x, y - 1))
                        {
                            y--;
                            matrix[x, y] = 0;
                        }
                        showMatrix();
                        break;
                    case "s":
                        if (checkMovement(x + 1, y))
                        {
                            x++;
                            matrix[x, y] = 0;
                        }

                        showMatrix();
                        break;
                    case "d":
                        if (checkMovement(x, y + 1))
                        {
                            y++;
                            matrix[x, y] = 0;
                        }
                        showMatrix();
                        break;
                }
                    
                 
            }
           
        }

        static Boolean checkMovement(int x, int y)
        {
            eventGenerator(x, y);
            Console.WriteLine(x+" "+y);
            if (x < 0 || x >= startX || y < 0 || y >= startY)
            {
                Console.WriteLine("Te chocas con un muro");
                return false;
            }
            else if (matrix[x, y] == 0)
            {
                Console.WriteLine("Te chocas contigo mismo");
                option = "p";

                return false;
            }
            else if (matrix[x, y] == 8)
            {
                Console.WriteLine("Cambias de color");
                
                if (color=="blue")
                {
                    color = "green";
                }else
                {
                    color = "blue";
                }
                
                

                return true;
            }
            else if (matrix[x, y] == 2)
            {
                Console.WriteLine("Has comido una bomba");
                option = "p";

                return false;
            }
            else return true;
        }
        static void showMatrix()
        {
            round++;
            if (matrix == null ) 
            {

                matrix = new int[startX, startY];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = 4;

                    }
                }
                
            } else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.WriteLine("");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        colorChange(i,j);
                                             
                    }
                }
                Console.WriteLine(" ");
            }
            
            
        }
        static void eventGenerator(int x, int y)
        {
            var rand = new Random();

            if (round % 5 == 0)
            {
                int random = rand.Next(0, startX);
                int random2 = rand.Next(0, startY);
                Console.WriteLine("Round: " + round);
                if (matrix[random, random2] == 4)
                {
                    matrix[random, random2] = 8;
                }
                else eventGenerator(x, y);
                

            }else if (round % 7 == 0)
            {
                int random = rand.Next(0, startX);
                int random2 = rand.Next(0, startY);
                Console.WriteLine("Round: " + round);
                if (matrix[random, random2] == 4)
                {
                    matrix[random, random2] = 2;
                }
                else eventGenerator(x, y);
            }
        }
        static void colorChange(int i, int j)
        {
            if (color == "green")
            {
                if (matrix[i, j] == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (matrix[i, j] == 8)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (matrix[i, j] == 2)
                    Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.Write(matrix[i, j]);

            }
            else if (color == "blue")
            {
                if (matrix[i, j] == 0)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (matrix[i, j] == 8)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (matrix[i, j] == 2)
                    Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.Write(matrix[i, j]);
            }
        }
        
    }
}

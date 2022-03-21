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
        static String option = "c";



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
            int x = 3;
            int y = 5;
            matrix[x, y] = 0;
            showMatrix();


            while (option != "p")
            {
                Console.WriteLine("Keys WASD to move");
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
            Console.WriteLine(x+" "+y);
            if (x < 0 || x >= 7 || y < 0 || y >= 10)
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
            else return true;
        }
        static void showMatrix()
        {
            if (matrix == null ) 
            {

                matrix = new int[7, 10];

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

                        if (matrix[i, j] == 0)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(matrix[i, j]);

                    }
                }
                Console.WriteLine(" ");
            }
            
            
        }
    }
}

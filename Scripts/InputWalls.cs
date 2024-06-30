using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Scripts
{
	public class InputWalls
	{
		RubikColors cube = RubikColors.Instance;
		MovingWalls moving = new MovingWalls();
		private int white, red, yellow, green, blue, orange;
		public void InputWall()
		{
			Console.WriteLine("Podaj kolory ściany górnej");
			GetColors(cube.UP);
			Console.WriteLine("Podaj kolor ściany dolnej");
			GetColors(cube.DOWN);
			Console.WriteLine("Podaj kolor ściany frontowej");
			GetColors(cube.FRONT);
			Console.WriteLine("Podaj kolor ściany tylnej");
			GetColors(cube.BACK);
			Console.WriteLine("Podaj kolor ściany prawej");
			GetColors(cube.RIGHT);
			Console.WriteLine("Podaj kolor ściany lewej");
			GetColors(cube.LEFT);
			VerifyCubeColors(cube);
		}
		private void VerifyCubeColors(RubikColors cube)
		{
			for (int i = 0; i < 9; i++)
			{
				char color = cube.UP[i];
				CheckColorChar(color);
				color = cube.DOWN[i];
				CheckColorChar(color);
				color = cube.FRONT[i];
				CheckColorChar(color);
				color = cube.BACK[i];
				CheckColorChar(color);
				color = cube.RIGHT[i];
				CheckColorChar(color);
				color = cube.LEFT[i];
				CheckColorChar(color);
			}
				if(yellow != 9 || red != 9 | white != 9 || orange != 9 || blue !=9 || green != 9)
				{
					yellow = 0;
					red = 0;
					white = 0;
					green = 0;
					blue = 0;
					orange = 0;
					Console.WriteLine("Ściany zostały błędnie wpisane, należy wpisać je od nowa");
					Console.ReadLine();
					InputWall();
				}
			
		}
		private void CheckColorChar(char color)
		{
			if(color == 'y')
			{
				yellow++;
			} else if(color == 'r')
			{
				red++;
			} else if(color == 'w')
			{
				white++;
			} else if(color == 'o')
			{
				orange++;
			} else if(color == 'b')
			{
				blue++;
			} else if(color == 'g')
			{
				green++;
			}
		}
		private void GetColors(char[] side)
		{
			for(int i = 0; i < 9; i++)
			{
				char color;
				do
				{
					Console.WriteLine($"Podaj kolor klocka {i + 1}: ");
					color = Console.ReadKey().KeyChar;
					Console.WriteLine();
					if(color == 'z')
					{
						i = -1;
						break;
					}
				} while (!"wgrbyo".Contains(color));
				if(i > -1) side[i] = color;
			}
		}
		public void ReadWall(string side)
		{
			switch(side)
			{
				case "UP":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.UP[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
				case "LEFT":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.LEFT[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
				case "RIGHT":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.RIGHT[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
				case "BACK":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.BACK[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
				case "DOWN":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.DOWN[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
				case "FRONT":
					for (int j = 0; j < 9; j++)
					{
						string color = Convert.ToString(cube.FRONT[j]);
						color = BetterColors(color);
						Console.WriteLine(color);
					}
					break;
			}
		}
		private string BetterColors(string color)
		{
			switch(color)
			{
				case "g":
					return "Green";
				case "w":
					return "White";
				case "b":
					return "Blue";
				case "o":
					return "Orange";
				case "r":
					return "Red";
				case "y":
					return "Yellow";
				default:
					return "Error";
			}
		}
	}
}

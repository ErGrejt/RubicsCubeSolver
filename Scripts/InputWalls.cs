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
				} while (!"wgrbyo".Contains(color));
				side[i] = color;
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

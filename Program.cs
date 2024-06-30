using RubicsCube.Models;
using RubicsCube.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube
{
	internal class Program
	{
		static void Main(string[] args)
		{
			InputWalls input = new InputWalls();
			MovingWalls moving = new MovingWalls();
			RubikColors cube = RubikColors.Instance;
			Cross solve = new Cross();
			SecondLayerEdges secondLayerEdges = new SecondLayerEdges();
			Console.WriteLine(@"Witaj w programie do układania kostki rubika!
Najpierw musisz podać w jakim stanie jest Twoja kostka.
Aby to zrobić musisz użyć liter w,g,b,r,y,o:
- w - white - biały
- g - green - zielony
- b - blue - niebieski
- r - red - czerwony
- y - yellow - żółty
- o - orange - pomarańczowy
Kliknij 'enter' aby kontynuować");
			Console.ReadLine();
			Console.Clear();
			input.InputWall();
			Console.Clear();
			solve.SolveWhiteCross();
			secondLayerEdges.SolveEdgesSecondLayer();
            Console.Clear();
			input.ReadWall("FRONT");
			Console.ReadLine();
			Console.Clear();
			input.ReadWall("BACK");
			Console.ReadLine();
			Console.Clear();
			input.ReadWall("UP");
			Console.ReadLine();
			Console.Clear();
			input.ReadWall("DOWN");
			Console.ReadLine();
			Console.Clear();
			input.ReadWall("LEFT");
			Console.ReadLine();
			Console.Clear();
			input.ReadWall("RIGHT");
			Console.ReadLine();
			Console.Clear();

		}
	}
}

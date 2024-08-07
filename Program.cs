﻿using RubicsCube.Models;
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
			WhiteCorners whiteCorners = new WhiteCorners();
			YellowCross yellowCross = new YellowCross();
			YellowCorners yellowCorners = new YellowCorners();
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
			string edge = secondLayerEdges.ConnectorEdge();
			whiteCorners.SolveWhiteCorners(edge);
			secondLayerEdges.SolverLastEdgeSecondLayer(edge);
			yellowCross.SolveYellowCross();
			yellowCorners.SolveCornersLastStep(edge);
			Console.WriteLine("Kostka ułożona :)");
			Console.ReadLine();
		}
	}
}

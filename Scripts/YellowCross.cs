using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Scripts
{
	public class YellowCross
	{
		private MovingWalls _walls;
		private RubikColors cube;
		public YellowCross() 
		{ 
			_walls = new MovingWalls();
			cube = RubikColors.Instance;
		}
		public void SolveYellowCross()
		{
			YellowCrossSolver();
		}
		private void YellowCrossSolver()
		{
			string cross = CheckYellowWall();
			switch(cross)
			{
				case "LineVert":
					_walls.TurnDownRight(cube);
					YellowCrossAlgoritm();
					break;
				case "LineHor":
					YellowCrossAlgoritm();
					break;
				case "RightUpCorner":
					_walls.TurnDownRight(cube);
					YellowCrossAlgoritm();
					YellowCrossAlgoritm();
					break;
				case "RightDownCorner":
					YellowCrossAlgoritm();
					YellowCrossAlgoritm();
					break;
				case "LeftDownCorner":
					_walls.TurnDownLeft(cube);
					YellowCrossAlgoritm();
					YellowCrossAlgoritm();
					break;
				case "LeftUpCorner":
					_walls.TurnDownLeft(cube);
					_walls.TurnDownLeft(cube);
					YellowCrossAlgoritm();
					YellowCrossAlgoritm();
					break;
				case "Dot":
					YellowCrossAlgoritm();
					YellowCrossSolver();
					break;
			}
			_walls.WriteMoves(4);
		}
		private string CheckYellowWall() 
		{
			if (cube.DOWN[1] == 'y' && cube.DOWN[3] == 'y' && cube.DOWN[5] == 'y' && cube.DOWN[7] == 'y') return "Cross";
			if (cube.DOWN[1] == 'y' && cube.DOWN[7] == 'y') return "LineVert";
			if (cube.DOWN[3] == 'y' && cube.DOWN[5] == 'y') return "LineHor";
			if (cube.DOWN[1] == 'y' && cube.DOWN[5] == 'y') return "RightUpCorner";
			if (cube.DOWN[5] == 'y' && cube.DOWN[7] == 'y') return "RightDownCorner";
			if (cube.DOWN[7] == 'y' && cube.DOWN[3] == 'y') return "LeftDownCorner";
			if (cube.DOWN[3] == 'y' && cube.DOWN[1] == 'y') return "LeftUpCorner";
			if (cube.DOWN[1] != 'y' && cube.DOWN[3] != 'y' && cube.DOWN[5] != 'y' && cube.DOWN[7] != 'y') return "Dot";
			return "Error";
		}
		private void YellowCrossAlgoritm()
		{
			_walls.TurnFrontRight(cube);
			_walls.TurnLeftRight(cube);
			_walls.TurnDownRight(cube);
			_walls.TurnLeftLeft(cube);
			_walls.TurnDownLeft(cube);
			_walls.TurnFrontLeft(cube);
		}
	}
}

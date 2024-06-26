using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RubicsCube.Scripts
{
	public class Cross
	{
		private RubikColors cube;
		private MovingWalls _walls;
		private char rightCenter, leftCenter, downCenter, upCenter, frontCenter, backCenter;
		private string lastMove;
		private string firstMove;

		public Cross()
		{
			cube = RubikColors.Instance;
			_walls = new MovingWalls();
			rightCenter = cube.RIGHT[4];
			leftCenter = cube.LEFT[4];
			downCenter = cube.DOWN[4];
			upCenter = cube.UP[4];
			frontCenter = cube.FRONT[4];
			backCenter = cube.BACK[4];
		}
		public void SolveWhiteCross()
		{
			MoveWhiteEdgesToTop();
		}
		private void MoveWhiteEdgesToTop()
		{
			bool whiteCrossOnTop = false;
			while (!whiteCrossOnTop)
			{
				whiteCrossOnTop = (cube.UP[1] == 'w' && cube.UP[3] == 'w' && cube.UP[5] == 'w' && cube.UP[7] == 'w');

				for (int i = 0; i < 9; i++)
				{
					if (cube.FRONT[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "FRONT", i);
						MoveWhiteEdgeToTopFromFront(i, sidecolor);
					}
					else if (cube.BACK[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "BACK", i);
						MoveWhiteEdgeToTopFromBack(i, sidecolor);
					}
					else if (cube.RIGHT[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "RIGHT", i);
						MoveWhiteEdgeToTopFromRight(i, sidecolor);
					}
					else if (cube.LEFT[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "LEFT", i);
						MoveWhiteEdgeToTopFromLeft(i, sidecolor);
					}
					else if (cube.DOWN[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "DOWN", i);
						MoveWhiteEdgeToTopFromDown(i, sidecolor);
					}
					else if (cube.UP[i] == 'w')
					{
						char sidecolor = GetAdjacentColor(cube, "UP", i);
						MoveWhiteEdgeFromTopToGoodPosition(i, sidecolor);
					}
				}
				whiteCrossOnTop = (cube.UP[1] == 'w' && cube.UP[3] == 'w' && cube.UP[5] == 'w' && cube.UP[7] == 'w');
			}
			_walls.CountMoves();
			Console.ReadLine();
		}
		private void MoveWhiteEdgeFromTopToGoodPosition(int position, char sidecolor)
		{
			switch(position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnBackLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							
							break;
						case 'g':
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnBackLeft(cube);
							_walls.TurnUpLeft(cube);
							
							break;
						case 'r':
							_walls.TurnBackLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'r':
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'g':
							_walls.TurnRightLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'r':
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'g':
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
			}
		}
		private void MoveWhiteEdgeToTopFromFront(int position, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnFrontRight(cube);
							_walls.TurnRightRight(cube);
							break;
						case 'g':
							_walls.TurnFrontLeft(cube);
							_walls.TurnLeftLeft(cube);
							break;
						case 'r':
							_walls.TurnFrontRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'g':
							_walls.TurnLeftLeft(cube);
							break;
						case 'r':
							_walls.TurnUpRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnRightRight(cube);
							break;
						case 'g':
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'r':
							_walls.TurnUpLeft(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnUpRight(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnFrontLeft(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'g':
							_walls.TurnFrontRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnFrontLeft(cube);
							break;
						case 'r':
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontRight(cube);
							break;
					}
					break;
			}
		}
		private void MoveWhiteEdgeToTopFromRight(int position, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'g':
							_walls.TurnRightRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnRightRight(cube);
							_walls.TurnBackRight(cube);
							break;
						case 'r':
							_walls.TurnRightLeft(cube);
							_walls.TurnFrontLeft(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpRight(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'g':
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'r':
							_walls.TurnFrontLeft(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'g':
							_walls.TurnUpRight(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnBackRight(cube);
							break;
						case 'r':
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'g':
							_walls.TurnRightRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'o':
							_walls.TurnRightLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'r':
							_walls.TurnRightRight(cube);
							_walls.TurnFrontLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
					}
					break;
			}
		}
		private void MoveWhiteEdgeToTopFromLeft(int position, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'g':
							_walls.TurnLeftRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'r':
							_walls.TurnLeftRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnLeftLeft(cube);
							_walls.TurnBackLeft(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'g':
							_walls.TurnUpRight(cube);
							_walls.TurnBackLeft(cube);
							break;
						case 'r':
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnBackLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnBackLeft(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpRight(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'g':
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'r':
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'g':
							_walls.TurnLeftLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'r':
							_walls.TurnLeftLeft(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnLeftRight(cube);
							_walls.TurnBackLeft(cube);
							break;
					}
					break;
			}
		}
		private void MoveWhiteEdgeToTopFromBack(int position, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnBackLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnBackRight(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnBackRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'r':
							_walls.TurnUpLeft(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'o':
							_walls.TurnUpRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnUpLeft(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnUpRight(cube);
							break;
						case 'g':
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnUpRight(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpLeft(cube);
							break;
						case 'o':
							_walls.TurnUpLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnUpRight(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnBackLeft(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnBackRight(cube);
							break;
						case 'g':
							_walls.TurnBackLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnBackRight(cube);
							break;
						case 'r':
							_walls.TurnBackRight(cube);
							_walls.TurnUpLeft(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnBackLeft(cube);
							break;
						case 'o':
							_walls.TurnBackRight(cube);
							_walls.TurnUpRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnUpLeft(cube);
							break;
					}
					break;
			}
		}
		private void MoveWhiteEdgeToTopFromDown(int position, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnDownRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnDownLeft(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnFrontRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnDownRight(cube);
							_walls.TurnDownRight(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnBackRight(cube);
							break;
					}
					break;
				case 3:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnDownRight(cube);
							_walls.TurnDownRight(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnLeftRight(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnDownRight(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnDownLeft(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnBackRight(cube);
							break;
					}
					break;
				case 5:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnRightLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnDownRight(cube);
							_walls.TurnDownRight(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnDownLeft(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnDownRight(cube);
							_walls.TurnBackRight(cube);
							_walls.TurnBackRight(cube);
							break;
					}
					break;
				case 7:
					switch (sidecolor)
					{
						case 'b':
							_walls.TurnDownLeft(cube);
							_walls.TurnRightLeft(cube);
							_walls.TurnRightLeft(cube);
							break;
						case 'g':
							_walls.TurnDownRight(cube);
							_walls.TurnLeftRight(cube);
							_walls.TurnLeftRight(cube);
							break;
						case 'r':
							_walls.TurnDownRight(cube);
							_walls.TurnDownRight(cube);
							_walls.TurnFrontRight(cube);
							_walls.TurnFrontRight(cube);
							break;
						case 'o':
							_walls.TurnBackRight(cube);
							_walls.TurnBackRight(cube);
							break;
					}
					break;
			}
		}
		private char GetAdjacentColor(RubikColors cube, string face, int position)
		{
			switch (face)
			{
				case "FRONT":
					switch (position)
					{
						case 1:
							return cube.UP[7];
						case 3:
							return cube.LEFT[5];
						case 5:
							return cube.RIGHT[3];
						case 7:
							return cube.DOWN[1];
					}
					break;
				case "BACK":
					switch (position)
					{
						case 1:
							return cube.UP[1];
						case 3:
							return cube.RIGHT[5];
						case 5:
							return cube.LEFT[3];
						case 7:
							return cube.DOWN[7];
					}
					break;
				case "LEFT":
					switch (position)
					{
						case 1:
							return cube.UP[3];
						case 3:
							return cube.BACK[5];
						case 5:
							return cube.FRONT[3];
						case 7:
							return cube.DOWN[3];
					}
					break;
				case "RIGHT":
					switch (position)
					{
						case 1:
							return cube.UP[5];
						case 3:
							return cube.FRONT[5];
						case 5:
							return cube.BACK[3];
						case 7:
							return cube.DOWN[5];
					}
					break;
				case "UP":
					switch (position)
					{
						case 1:
							return cube.BACK[1];
						case 3:
							return cube.LEFT[1];
						case 5:
							return cube.RIGHT[1];
						case 7:
							return cube.FRONT[1];
					}
					break;
				case "DOWN":
					switch (position)
					{
						case 1:
							return cube.FRONT[7];
						case 3:
							return cube.LEFT[7];
						case 5:
							return cube.RIGHT[7];
						case 7:
							return cube.BACK[7];
					}
					break;
			}
			return '1';
		}
		private bool LastMoveCheck(string lastMove, string firstMove)
		{
			if (lastMove == null) return false;
			switch(firstMove)
			{
				case "TurnUpRight":
					return lastMove == "TurnUpLeft" ? true : false;
				case "TurnUpLeft":
					return lastMove == "TurnUpRight" ? true : false;
				case "TurnDownRight":
					return lastMove == "TurnDownLeft" ? true : false;
				case "TurnDownLeft":
					return lastMove == "TurnDownRight" ? true : false;
				case "TurnFrontRight":
					return lastMove == "TurnFrontLeft" ? true : false;
				case "TurnFrontLeft":
					return lastMove == "TurnFrontRight" ? true : false;
				case "TurnBackRight":
					return lastMove == "TurnBackLeft" ? true : false;
				case "TurnBackLeft":
					return lastMove == "TurnBackRight" ? true : false;
				case "TurnRightRight":
					return lastMove == "TurnRightLeft" ? true : false;
				case "TurnRightLeft":
					return lastMove == "TurnRightRight" ? true : false;
				case "TurnLeftRight":
					return lastMove == "TurnLeftLeft" ? true : false;
				case "TurnLeftLeft":
					return lastMove == "TurnLeftRight" ? true : false;
				default:
					return false; 
			}
		}
		private void doLastMove(string lastMove)
		{
			switch(lastMove)
			{
				case "TurnUpRight":
					_walls.TurnUpRight(cube);
					break;
				case "TurnUpLeft":
					_walls.TurnUpLeft(cube);
					break;
				case "TurnDownRight":
					_walls.TurnDownRight(cube);
					break;
				case "TurnDownLeft":
					_walls.TurnDownLeft(cube);
					break;
				case "TurnFrontRight":
					_walls.TurnFrontRight(cube);
					break;
				case "TurnFrontLeft":
					_walls.TurnFrontLeft(cube);
					break;
				case "TurnBackRight":
					_walls.TurnBackRight(cube);
					break;
				case "TurnBackLeft":
					_walls.TurnBackLeft(cube);
					break;
				case "TurnRightRight":
					_walls.TurnRightRight(cube);
					break;
				case "TurnRightLeft":
					_walls.TurnRightLeft(cube);
					break;
				case "TurnLeftRight":
					_walls.TurnLeftRight(cube);
					break;
				case "TurnLeftLeft":
					_walls.TurnLeftLeft(cube);
					break;
				default:

					break;
			}
		}
		private void WhiteCrossCorr(RubikColors cube)
		{
			char sidecolor = GetAdjacentColor(cube, "UP", 1);
			switch(sidecolor)
			{
				case 'g':
					_walls.TurnUpLeft(cube);
					break;
				case 'b':
					_walls.TurnUpRight(cube);
					break;
				case 'r':
					_walls.TurnUpRight(cube);
					_walls.TurnUpRight(cube);
					break;
				case 'o':
					break;
			}
		}
	}
}

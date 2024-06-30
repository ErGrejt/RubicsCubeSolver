using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Scripts
{
	public class WhiteCorners
	{
		private RubikColors cube;
		private MovingWalls _walls;
		//Connectors edges
		private int upConnector;
		private int downConnector;
		public WhiteCorners()
		{
			cube = RubikColors.Instance;
			_walls = new MovingWalls();
		}
		public void SolveWhiteCorners(string connector)
		{
			ConnectorsSet(connector);
		}
		private void ConnectorsSet(string connector)
		{
			switch(connector)
			{
				case "frontRightEdge":
					upConnector = 8;
					downConnector = 2;
					break;
				case "frontLeftEdge":
					upConnector = 6;
					downConnector = 0;
					break;
				case "backRightEdge":
					upConnector = 0;
					downConnector = 6;
					break;
				case "backLeftEdge":
					upConnector = 2;
					downConnector = 8;
					break;
			}
		}
		private string CheckCornersColors(string face, int position)
		{
			switch (face)
			{
				case "UP":
					switch(position)
					{
						case 0: return $"{cube.LEFT[0]}{cube.BACK[2]}";
						case 2: return $"{cube.RIGHT[2]}{cube.BACK[0]}";
						case 6: return $"{cube.LEFT[2]}{cube.FRONT[0]}";
						case 8: return $"{cube.RIGHT[0]}{cube.FRONT[2]}";
					}
				break;

				case "DOWN":
					switch (position)
					{
						case 0: return $"{cube.LEFT[8]}{cube.FRONT[6]}";
						case 2: return $"{cube.RIGHT[6]}{cube.FRONT[8]}";
						case 6: return $"{cube.LEFT[6]}{cube.BACK[8]}";
						case 8: return $"{cube.RIGHT[8]}{cube.BACK[6]}";
					}
				break;
			}
			return null;
		}
	}
}

using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Scripts
{
    public class SecondLayerEdges
    {
        private RubikColors cube;
        private MovingWalls _walls;
        private Cross sideColor;
        private int edges = 0;
        //Edges bools
        private bool frontRightEdge;
		private bool frontLeftEdge; 
		private bool backRightEdge; 
		private bool backLeftEdge;
        private int count;
        private string resultEdge;
		public SecondLayerEdges()
        {
            cube = RubikColors.Instance;
            _walls = new MovingWalls();
            sideColor = new Cross();
        }

        public void SolveEdgesSecondLayer()
        {
            CheckEdges();
        }

        private void CheckEdges()
        {
            bool threeedges = false;
            while (!threeedges)
            {
				
                for (int i = 0; i < 9; i++)
                {
					if (cube.DOWN[i] == 'r' || cube.DOWN[i] == 'b' || cube.DOWN[i] == 'o' || cube.DOWN[i] == 'g')
					{
						int position = i;
						char maincolor = cube.DOWN[i];
						char sidecolor = sideColor.GetAdjacentColor(cube, "DOWN", i);
						CheckingEdgesDown(position, maincolor, sidecolor);
					}
                    else if (cube.BACK[i] == 'r' || cube.BACK[i] == 'b' || cube.BACK[i] == 'o' || cube.BACK[i] == 'g')
                    {
                        int position = i;
                        char maincolor = cube.BACK[i];
                        char sidecolor = sideColor.GetAdjacentColor(cube, "BACK", i);
						CheckingEdgesBack(position, maincolor, sidecolor);

					}
                    else if (cube.RIGHT[i] == 'r' || cube.RIGHT[i] == 'b' || cube.RIGHT[i] == 'o' || cube.RIGHT[i] == 'g')
                    {
                        int position = i;
                        char maincolor = cube.RIGHT[i];
                        char sidecolor = sideColor.GetAdjacentColor(cube, "RIGHT", i);
                        CheckingEdgesRight(position, maincolor, sidecolor);
                    }
                    else if (cube.LEFT[i] == 'r' || cube.LEFT[i] == 'b' || cube.LEFT[i] == 'o' || cube.LEFT[i] == 'g')
                    {
                        int position = i;
                        char maincolor = cube.LEFT[i];
                        char sidecolor = sideColor.GetAdjacentColor(cube, "LEFT", i);
						CheckingEdgesLeft(position, maincolor, sidecolor);
					}
                    else if (cube.FRONT[i] == 'r' || cube.FRONT[i] == 'b' || cube.FRONT[i] == 'o' || cube.FRONT[i] == 'g')
					{
						int position = i;
						char maincolor = cube.FRONT[i];
						char sidecolor = sideColor.GetAdjacentColor(cube, "FRONT", i);
						CheckingEdgesFront(position, maincolor, sidecolor);
					}
				}
				threeedges = CheckingSolvedEdges();
			}
            if(count == 3)
            {
				if (!frontRightEdge) resultEdge = "frontRightEdge";
				if (!frontLeftEdge) resultEdge = "frontLeftEdge";
				if (!backRightEdge) resultEdge = "backRightEdge";
				if (!backLeftEdge) resultEdge = "backLeftEdge";

			} else
            {
                resultEdge = "frontRightEdge";
            }
			_walls.WriteMoves(2);
		}
        public string ConnectorEdge()
        {
            return resultEdge;
        }
        private bool CheckingSolvedEdges()
        {
			frontRightEdge = (cube.FRONT[5] == 'r' && cube.RIGHT[3] == 'b');
			frontLeftEdge = (cube.LEFT[5] == 'g' && cube.FRONT[3] == 'r');
			backRightEdge = (cube.BACK[5] == 'o' && cube.LEFT[3] == 'g');
			backLeftEdge = (cube.RIGHT[5] == 'b' && cube.BACK[3] == 'o');
			count = 0;
            if(frontRightEdge) count++;
            if(frontLeftEdge) count++;
            if(backRightEdge) count++;
            if(backLeftEdge) count++;

            if (count >= 3)
            {
                return true;
            } else
            {
                return false;
            }

        }
        private void CheckingEdgesFront(int position, char maincolor, char sidecolor)
        {
            switch(position)
            {
                case 3:
                    switch(maincolor)
                    {
                        case 'g':
                            if(sidecolor == 'y') return;
                            if(sidecolor == 'r')
                            {
                                _walls.TurnLeftRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                edges++;
                                break;
                            } else
                            {
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'g')
                            {
                                edges++;
                                break;
                            } else if(sidecolor == 'y') {
                                break;
                            }

                            _walls.TurnLeftRight(cube);
                            _walls.TurnDownRight(cube);
                            _walls.TurnDownRight(cube);
                            _walls.TurnLeftLeft(cube);
                            _walls.TurnRightRight(cube);
                            _walls.TurnFrontLeft(cube);
                            _walls.TurnRightLeft(cube);
                            _walls.TurnFrontRight(cube);
                            edges++;
                            break;
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'o')
                            {
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnLeftRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnFrontLeft(cube);
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'g')
                            {
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnLeftRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
                case 5:
                    switch (maincolor)
                    {
                        case 'g':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                _walls.TurnRightLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnFrontRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'b')
                            {
                                edges++;
                                break;
                            } else if(sidecolor == 'y')
                            {
                                break;
                            }
                            _walls.TurnFrontRight(cube);
                            _walls.TurnDownLeft(cube);
                            _walls.TurnFrontLeft(cube);
                            _walls.TurnDownRight(cube);
                            _walls.TurnFrontRight(cube);
                            _walls.TurnLeftLeft(cube);
                            _walls.TurnFrontLeft(cube);
                            _walls.TurnLeftRight(cube);
                            edges++;
                            break;
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                               _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'b')
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnRightLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
                case 7:
                    switch (maincolor)
                    {
                        case 'g':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'y') return;
                            if(sidecolor == 'g')
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                edges++;
                                break;
                            } else
                            {
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
                                edges++;
                                break;
                            }
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'g')
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
            }
        }
        private void CheckingEdgesRight(int position, char maincolor, char sidecolor)
        {
            switch (position)
            {
                case 3:
                    switch (maincolor)
                    {
                        case 'g':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'o')
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnRightLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'g')
                            {
                                _walls.TurnRightLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                edges++;
                                break;
                            } else
                            {
                                _walls.TurnRightLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
                                edges++;
                            }
                            break;
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'g')
                            {
                               _walls.TurnRightLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnFrontRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
                case 5:
                    switch (maincolor)
                    {
                        case 'g':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'o')
                            {
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'b')
                            {
                                _walls.TurnBackLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                edges++;
                                break;
                            }
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                                _walls.TurnBackLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'g')
                            {
                               _walls.TurnRightRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
                case 7:
                    switch (maincolor)
                    {
                        case 'g':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'o')
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
                                edges++;
                                break;
                            }
                        case 'r':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'b')
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                edges++;
                                break;
                            }
                        case 'b':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'r')
                            {
                               _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                               _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
                                edges++;
                                break;
                            }
                        case 'o':
                            if (sidecolor == 'y') return;
                            if (sidecolor == 'b')
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                edges++;
                                break;
                            }
                            else
                            {
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
                                edges++;
                                break;
                            }
                    }
                    break;
            }
        }
		private void CheckingEdgesLeft(int position, char maincolor, char sidecolor)
		{
			switch (position)
			{
				case 3:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
								_walls.TurnBackRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
								_walls.TurnLeftLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnLeftLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
							}
							break;
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
							else
							{
							    _walls.TurnBackRight(cube);
                                _walls.TurnDownRight(cube);
								_walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
								_walls.TurnLeftLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnLeftLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
					}
					break;
				case 5:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
							    _walls.TurnFrontLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
							else
							{
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
							    _walls.TurnLeftRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnFrontLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
								_walls.TurnLeftRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
								_walls.TurnFrontLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnLeftRight(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
					}
					break;
				case 7:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
								_walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
								_walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
								_walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
								_walls.TurnDownLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
					}
					break;
			}
		}
		private void CheckingEdgesBack(int position, char maincolor, char sidecolor)
		{
			switch (position)
			{
				case 3:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnBackLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnBackLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnBackLeft(cube);
								_walls.TurnDownLeft(cube);
								_walls.TurnDownLeft(cube);
								_walls.TurnBackRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
							}
							break;
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnBackLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnBackLeft(cube);
								_walls.TurnDownLeft(cube);
								_walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
								edges++;
								break;
							}
							else
							{
                                _walls.TurnRightRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
					}
					break;
				case 5:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnBackRight(cube);
								_walls.TurnDownRight(cube);
								_walls.TurnDownRight(cube);
								_walls.TurnBackLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{

								edges++;
								break;
							}
							else
							{
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
					}
					break;
				case 7:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
								_walls.TurnDownRight(cube);
								_walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
					}
					break;
			}
		}
		private void CheckingEdgesDown(int position, char maincolor, char sidecolor)
		{
			switch (position)
			{
				case 1:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
							}
							break;
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);  
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
					}
					break;
				case 3:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
							}
							break;
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
					}
					break;
				case 5:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'o')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
					}
					break;
				case 7:
					switch (maincolor)
					{
						case 'g':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnDownLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnLeftRight(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnLeftLeft(cube);
								edges++;
								break;
							}
						case 'r':
							if (sidecolor == 'y') return;
							if (sidecolor == 'g')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnFrontLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnFrontRight(cube);
								edges++;
								break;
							}
						case 'b':
							if (sidecolor == 'y') return;
							if (sidecolor == 'r')
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnDownRight(cube);
                                _walls.TurnFrontLeft(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnFrontRight(cube);
                                _walls.TurnRightLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnRightRight(cube);
								edges++;
								break;
							}
						case 'o':
							if (sidecolor == 'y') return;
							if (sidecolor == 'b')
							{
                                _walls.TurnDownLeft(cube);
                                _walls.TurnRightLeft(cube);
                                _walls.TurnBackRight(cube);
                                _walls.TurnRightRight(cube);
                                _walls.TurnBackLeft(cube);
								edges++;
								break;
							}
							else
							{
                                _walls.TurnDownRight(cube);
                                _walls.TurnLeftRight(cube);
                                _walls.TurnBackLeft(cube);
                                _walls.TurnLeftLeft(cube);
                                _walls.TurnBackRight(cube);
								edges++;
								break;
							}
					}
					break;
			}
		}
	}
}

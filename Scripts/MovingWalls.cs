using RubicsCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicsCube.Scripts
{
    internal class MovingWalls
    {
        RubikColors cube = RubikColors.Instance;
        public List<string> moves = new List<string>();
        private int countMoves = 0;
        //Movings
        public void TurnFrontRight(RubikColors cube)
        {
            //Console.WriteLine("FRONT W PRAWO");
            moves.Add("TurnFrontRight");
            countMoves++;
            //Console.ReadLine();
            RotateFrontClockwise(cube);
        }
        public void TurnFrontLeft(RubikColors cube)
        {
            //Console.WriteLine("FRONT W LEWO");
            moves.Add("TurnFrontLeft");
            countMoves++;
            //Console.ReadLine();
            RotateFrontCounterClockwise(cube);
        }
        public void TurnUpRight(RubikColors cube)
        {
            //Console.WriteLine("UP W PRAWO");
            moves.Add("TurnUpRight");
            countMoves++;
            //Console.ReadLine();
            RotateUpClockwise(cube);
        }
        public void TurnUpLeft(RubikColors cube)
        {
            //Console.WriteLine("UP W LEWO");
            moves.Add("TurnUpLeft");
            countMoves++;
            //Console.ReadLine();
            RotateUpCounterClockwise(cube);
        }
        public void TurnRightRight(RubikColors cube)
        {
            //Console.WriteLine("PRAWO W PRAWO");
            moves.Add("TurnRightRight");
            countMoves++;
            //Console.ReadLine();
            RotateRightClockwise(cube);
        }
        public void TurnRightLeft(RubikColors cube)
        {
            //Console.WriteLine("PRAWO W LEWO");
            moves.Add("TurnRightLeft");
            countMoves++;
            //Console.ReadLine();
            RotateRightCounterClockwise(cube);
        }
        public void TurnLeftRight(RubikColors cube)
        {
            //Console.WriteLine("LEWO W PRAWO");
            moves.Add("TurnLeftRight");
            countMoves++;
            //Console.ReadLine();
            RotateLeftClockwise(cube);
        }
        public void TurnLeftLeft(RubikColors cube)
        {
            //Console.WriteLine("LEWO W LEWO");
            moves.Add("TurnLeftLeft");
            countMoves++;
            //Console.ReadLine();
            RotateLeftCounterClockwise(cube);
        }
        public void TurnBackRight(RubikColors cube)
        {
            //Console.WriteLine("BACK W PRAWO");
            moves.Add("TurnBackRight");
            countMoves++;
            //Console.ReadLine();
            RotateBackClockwise(cube);
        }
        public void TurnBackLeft(RubikColors cube)
        {
            //Console.WriteLine("BACK W LEWO");
            moves.Add("TurnBackLeft");
            countMoves++;
            //Console.ReadLine();
            RotateBackCounterClockwise(cube);
        }
        public void TurnDownRight(RubikColors cube)
        {
            //Console.WriteLine("DOWN W PRAWO");
            moves.Add("TurnDownRight");
            countMoves++;
            //Console.ReadLine();
            RotateDownClockwise(cube);
        }
        public void TurnDownLeft(RubikColors cube)
        {
            //Console.WriteLine("DOWN W LEWO");
            moves.Add("TurnDownLeft");
            countMoves++;
            //Console.ReadLine();
            RotateDownCounterClockwise(cube);
        }
        private void CountMoves(string message)
        {
            Console.WriteLine(message + moves.Count);
            Console.ReadLine();
        }
        public void WriteMovesWhiteCross(int number)
        {
            RemoveMoves();
            if(number == 1)
            {
                CountMoves("Ilość ruchów do ułożenia białego krzyża: ");
            } else if(number == 2)
            {
                CountMoves("Ilość ruchów do ułożenia środkowych 3 krawędzi: ");
            }
            for (int i = 0; i < moves.Count; i++)
            {
                ConsoleWLMoves(moves[i]);
                Console.ReadLine();
            }
        }
        private void ConsoleWLMoves(string move)
        {
            switch (move)
            {
                case "TurnFrontRight":
                    Console.WriteLine("FRONT W PRAWO");
                    break;
                case "TurnFrontLeft":
                    Console.WriteLine("FRONT W LEWO");
                    break;
                case "TurnBackRight":
                    Console.WriteLine("BACK W PRAWO");
                    break;
                case "TurnBackLeft":
                    Console.WriteLine("BACK W LEWO");
                    break;
                case "TurnUpRight":
                    Console.WriteLine("UP W PRAWO");
                    break;
                case "TurnUpLeft":
                    Console.WriteLine("UP W LEWO");
                    break;
                case "TurnDownRight":
                    Console.WriteLine("DOWN W PRAWO");
                    break;
                case "TurnDownLeft":
                    Console.WriteLine("DOWN W LEWO");
                    break;
                case "TurnLeftRight":
                    Console.WriteLine("LEFT W PRAWO");
                    break;
                case "TurnLeftLeft":
                    Console.WriteLine("LEFT W LEWO");
                    break;
                case "TurnRightRight":
                    Console.WriteLine("RIGHT W PRAWO");
                    break;
                case "TurnRightLeft":
                    Console.WriteLine("RIGHT W LEWO");
                    break;
                default:
                    Console.WriteLine("NIEZNANY RUCH");
                    break;
            }
        }
        private void RemoveMoves()
        {
            int i = 0;
            while (i < moves.Count - 1)
            {
                if (isCanceling(moves[i], moves[i + 1]))
                {
                    moves.RemoveAt(i);      // Remove current move
                    moves.RemoveAt(i);      // Remove next move
                    i = 0;                  // Start checking from the beginning
                }
                else
                {
                    i++;
                }
            }
        }
        private bool isCanceling(string move1, string move2)
        {
            // Pary ruchów, które się wzajemnie anulują
            if ((move1 == "TurnUpLeft" && move2 == "TurnUpRight") ||
                (move1 == "TurnUpRight" && move2 == "TurnUpLeft") ||
                (move1 == "TurnFrontLeft" && move2 == "TurnFrontRight") ||
                (move1 == "TurnFrontRight" && move2 == "TurnFrontLeft") ||
                (move1 == "TurnDownLeft" && move2 == "TurnDownRight") ||
                (move1 == "TurnDownRight" && move2 == "TurnDownLeft") ||
                (move1 == "TurnLeftLeft" && move2 == "TurnLeftRight") ||
                (move1 == "TurnLeftRight" && move2 == "TurnLeftLeft") ||
                (move1 == "TurnRightLeft" && move2 == "TurnRightRight") ||
                (move1 == "TurnRightRight" && move2 == "TurnRightLeft") ||
                (move1 == "TurnBackLeft" && move2 == "TurnBackRight") ||
                (move1 == "TurnBackRight" && move2 == "TurnBackLeft"))
            {
                return true;
            }

            return false;
        }
        private void RotateSideLeft(char[] side)
        {
            var temp = new char[9];
            temp[0] = side[2];
            temp[1] = side[5];
            temp[2] = side[8];
            temp[3] = side[1];
            temp[4] = side[4];
            temp[5] = side[7];
            temp[6] = side[0];
            temp[7] = side[3];
            temp[8] = side[6];
            Array.Copy(temp, side, 9);
        }
        private void RotateSideRight(char[] side)
        {
            var temp = new char[9];
            temp[0] = side[6];
            temp[1] = side[3];
            temp[2] = side[0];
            temp[3] = side[7];
            temp[4] = side[4];
            temp[5] = side[1];
            temp[6] = side[8];
            temp[7] = side[5];
            temp[8] = side[2];
            Array.Copy(temp, side, 9);
        }
        //Turn Front Right
        private void RotateFrontClockwise(RubikColors cube)
        {
            RotateSideRight(cube.FRONT);
            char[] temp = { cube.UP[6], cube.UP[7], cube.UP[8] };

            cube.UP[6] = cube.LEFT[8];
            cube.UP[7] = cube.LEFT[5];
            cube.UP[8] = cube.LEFT[2];

            cube.LEFT[2] = cube.DOWN[0];
            cube.LEFT[5] = cube.DOWN[1];
            cube.LEFT[8] = cube.DOWN[2];

            cube.DOWN[0] = cube.RIGHT[6];
            cube.DOWN[1] = cube.RIGHT[3];
            cube.DOWN[2] = cube.RIGHT[0];

            cube.RIGHT[0] = temp[0];
            cube.RIGHT[3] = temp[1];
            cube.RIGHT[6] = temp[2];
        }
        //Turn Front Left
        private void RotateFrontCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.FRONT);
            char[] temp = { cube.LEFT[2], cube.LEFT[5], cube.LEFT[8] };

            cube.LEFT[2] = cube.UP[8];
            cube.LEFT[5] = cube.UP[7];
            cube.LEFT[8] = cube.UP[6];

            cube.UP[6] = cube.RIGHT[0];
            cube.UP[7] = cube.RIGHT[3];
            cube.UP[8] = cube.RIGHT[6];

            cube.RIGHT[0] = cube.DOWN[2];
            cube.RIGHT[3] = cube.DOWN[1];
            cube.RIGHT[6] = cube.DOWN[0];

            cube.DOWN[2] = temp[2];
            cube.DOWN[1] = temp[1];
            cube.DOWN[0] = temp[0];
        }
        //Turn Up Right
        private void RotateUpClockwise(RubikColors cube)
        {
            RotateSideRight(cube.UP);
            char[] temp = { cube.BACK[0], cube.BACK[1], cube.BACK[2] };

            cube.BACK[0] = cube.LEFT[0];
            cube.BACK[1] = cube.LEFT[1];
            cube.BACK[2] = cube.LEFT[2];

            cube.LEFT[0] = cube.FRONT[0];
            cube.LEFT[1] = cube.FRONT[1];
            cube.LEFT[2] = cube.FRONT[2];

            cube.FRONT[0] = cube.RIGHT[0];
            cube.FRONT[1] = cube.RIGHT[1];
            cube.FRONT[2] = cube.RIGHT[2];

            cube.RIGHT[0] = temp[0];
            cube.RIGHT[1] = temp[1];
            cube.RIGHT[2] = temp[2];
        }
        //Turn Up Left
        private void RotateUpCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.UP);
            char[] temp = { cube.LEFT[0], cube.LEFT[1], cube.LEFT[2] };

            cube.LEFT[0] = cube.BACK[0];
            cube.LEFT[1] = cube.BACK[1];
            cube.LEFT[2] = cube.BACK[2];

            cube.BACK[0] = cube.RIGHT[0];
            cube.BACK[1] = cube.RIGHT[1];
            cube.BACK[2] = cube.RIGHT[2];

            cube.RIGHT[0] = cube.FRONT[0];
            cube.RIGHT[1] = cube.FRONT[1];
            cube.RIGHT[2] = cube.FRONT[2];

            cube.FRONT[0] = temp[0];
            cube.FRONT[1] = temp[1];
            cube.FRONT[2] = temp[2];
        }
        //Turn Right Right
        private void RotateRightClockwise(RubikColors cube)
        {
            RotateSideRight(cube.RIGHT);
            char[] temp = { cube.UP[2], cube.UP[5], cube.UP[8] };

            cube.UP[2] = cube.FRONT[2];
            cube.UP[5] = cube.FRONT[5];
            cube.UP[8] = cube.FRONT[8];

            cube.FRONT[2] = cube.DOWN[2];
            cube.FRONT[5] = cube.DOWN[5];
            cube.FRONT[8] = cube.DOWN[8];

            cube.DOWN[2] = cube.BACK[6];
            cube.DOWN[5] = cube.BACK[3];
            cube.DOWN[8] = cube.BACK[0];

            cube.BACK[0] = temp[2];
            cube.BACK[3] = temp[1];
            cube.BACK[6] = temp[0];
        }
        //Turn Right Left
        private void RotateRightCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.RIGHT);
            char[] temp = { cube.UP[2], cube.UP[5], cube.UP[8] };

            cube.UP[2] = cube.BACK[6];
            cube.UP[5] = cube.BACK[3];
            cube.UP[8] = cube.BACK[0];

            cube.BACK[0] = cube.DOWN[8];
            cube.BACK[3] = cube.DOWN[5];
            cube.BACK[6] = cube.DOWN[2];

            cube.DOWN[2] = cube.FRONT[2];
            cube.DOWN[5] = cube.FRONT[5];
            cube.DOWN[8] = cube.FRONT[8];

            cube.FRONT[2] = temp[0];
            cube.FRONT[5] = temp[1];
            cube.FRONT[8] = temp[2];
        }
        //Turn Left Right
        private void RotateLeftClockwise(RubikColors cube)
        {
            RotateSideRight(cube.LEFT);
            char[] temp = { cube.UP[0], cube.UP[3], cube.UP[6] };

            cube.UP[0] = cube.BACK[8];
            cube.UP[3] = cube.BACK[5];
            cube.UP[6] = cube.BACK[2];

            cube.BACK[2] = cube.DOWN[6];
            cube.BACK[5] = cube.DOWN[3];
            cube.BACK[8] = cube.DOWN[0];

            cube.DOWN[0] = cube.FRONT[0];
            cube.DOWN[3] = cube.FRONT[3];
            cube.DOWN[6] = cube.FRONT[6];

            cube.FRONT[0] = temp[0];
            cube.FRONT[3] = temp[1];
            cube.FRONT[6] = temp[2];
        }
        //Turn Left Right
        private void RotateLeftCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.LEFT);
            char[] temp = { cube.UP[0], cube.UP[3], cube.UP[6] };

            cube.UP[0] = cube.FRONT[0];
            cube.UP[3] = cube.FRONT[3];
            cube.UP[6] = cube.FRONT[6];

            cube.FRONT[0] = cube.DOWN[0];
            cube.FRONT[3] = cube.DOWN[3];
            cube.FRONT[6] = cube.DOWN[6];

            cube.DOWN[0] = cube.BACK[2];
            cube.DOWN[3] = cube.BACK[5];
            cube.DOWN[6] = cube.BACK[8];

            cube.BACK[2] = temp[2];
            cube.BACK[5] = temp[1];
            cube.BACK[8] = temp[0];
        }
        //Turn Back Right
        private void RotateBackClockwise(RubikColors cube)
        {
            RotateSideRight(cube.BACK);
            char[] temp = { cube.UP[0], cube.UP[1], cube.UP[2] };

            cube.UP[0] = cube.RIGHT[2];
            cube.UP[1] = cube.RIGHT[5];
            cube.UP[2] = cube.RIGHT[8];

            cube.RIGHT[2] = cube.DOWN[8];
            cube.RIGHT[5] = cube.DOWN[7];
            cube.RIGHT[8] = cube.DOWN[6];

            cube.DOWN[8] = cube.LEFT[6];
            cube.DOWN[7] = cube.LEFT[3];
            cube.DOWN[6] = cube.LEFT[0];

            cube.LEFT[0] = temp[2];
            cube.LEFT[3] = temp[1];
            cube.LEFT[6] = temp[0];
        }
        //Turn Back Left
        private void RotateBackCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.BACK);
            char[] temp = { cube.UP[0], cube.UP[1], cube.UP[2] };

            cube.UP[0] = cube.LEFT[6];
            cube.UP[1] = cube.LEFT[3];
            cube.UP[2] = cube.LEFT[0];

            cube.LEFT[0] = cube.DOWN[6];
            cube.LEFT[3] = cube.DOWN[7];
            cube.LEFT[6] = cube.DOWN[8];

            cube.DOWN[6] = cube.RIGHT[8];
            cube.DOWN[7] = cube.RIGHT[5];
            cube.DOWN[8] = cube.RIGHT[2];

            cube.RIGHT[2] = temp[0];
            cube.RIGHT[5] = temp[1];
            cube.RIGHT[8] = temp[2];
        }
        //Turn Down Right
        private void RotateDownClockwise(RubikColors cube)
        {
            RotateSideRight(cube.DOWN);
            char[] temp = { cube.FRONT[6], cube.FRONT[7], cube.FRONT[8] };

            cube.FRONT[6] = cube.LEFT[6];
            cube.FRONT[7] = cube.LEFT[7];
            cube.FRONT[8] = cube.LEFT[8];

            cube.LEFT[6] = cube.BACK[6];
            cube.LEFT[7] = cube.BACK[7];
            cube.LEFT[8] = cube.BACK[8];

            cube.BACK[6] = cube.RIGHT[6];
            cube.BACK[7] = cube.RIGHT[7];
            cube.BACK[8] = cube.RIGHT[8];

            cube.RIGHT[6] = temp[0];
            cube.RIGHT[7] = temp[1];
            cube.RIGHT[8] = temp[2];
        }
        //Turn Down Left
        private void RotateDownCounterClockwise(RubikColors cube)
        {
            RotateSideLeft(cube.DOWN);
            char[] temp = { cube.FRONT[6], cube.FRONT[7], cube.FRONT[8] };

            cube.FRONT[6] = cube.RIGHT[6];
            cube.FRONT[7] = cube.RIGHT[7];
            cube.FRONT[8] = cube.RIGHT[8];

            cube.RIGHT[6] = cube.BACK[6];
            cube.RIGHT[7] = cube.BACK[7];
            cube.RIGHT[8] = cube.BACK[8];

            cube.BACK[6] = cube.LEFT[6];
            cube.BACK[7] = cube.LEFT[7];
            cube.BACK[8] = cube.LEFT[8];

            cube.LEFT[6] = temp[0];
            cube.LEFT[7] = temp[1];
            cube.LEFT[8] = temp[2];
        }
    }
}

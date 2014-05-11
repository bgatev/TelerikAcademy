namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Mines
    {
        public class Point
        {
            private string name;
            private int points;

            public Point()
            {
            }

            public Point(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }

		private static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] matrixField = CreateField();
			char[,] bomb = PutBomb();
			int counter = 0;
			bool explode = false;
			List<Point> champions = new List<Point>(6);
			int row = 0;
			int column = 0;
			bool flag = true;
			const int Max = 35;
			bool flag2 = false;

			do
			{
				if (flag)
				{
					Console.WriteLine("Let play Mines!");
					Dumpp(matrixField);
					flag = false;
				}

				Console.Write("Input row and column: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&	int.TryParse(command[2].ToString(), out column) &&
						row <= matrixField.GetLength(0) && column <= matrixField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						TopScores(champions);
						break;
					case "restart":
						matrixField = CreateField();
						bomb = PutBomb();
						Dumpp(matrixField);
						explode = false;
						flag = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bomb[row, column] != '*')
						{
							if (bomb[row, column] == '-')
							{
								NextMove(matrixField, bomb, row, column);
								counter++;
							}

							if (Max == counter)
							{
								flag2 = true;
							}
							else
							{
								Dumpp(matrixField);
							}
						}
						else
						{
							explode = true;
						}

						break;
					default:
						Console.WriteLine("\nError - Invalid Command\n");
						break;
				}

				if (explode)
				{
					Dumpp(bomb);
					Console.Write("\nYou are dead with {0} points. " + "Input your NickName: ", counter);
					string nickName = Console.ReadLine();
					Point t = new Point(nickName, counter);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Points < t.Points)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}

					champions.Sort((Point r1, Point r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((Point r1, Point r2) => r2.Points.CompareTo(r1.Points));
					TopScores(champions);
					matrixField = CreateField();
					bomb = PutBomb();
					counter = 0;
					explode = false;
					flag = true;
				}

				if (flag2)
				{
					Console.WriteLine("\nWellDone - you open 35 cells.");
					Dumpp(bomb);
					Console.WriteLine("Input your name: ");
					string tempName = Console.ReadLine();
					Point tempPoints = new Point(tempName, counter);
					champions.Add(tempPoints);
					TopScores(champions);
					matrixField = CreateField();
					bomb = PutBomb();
					counter = 0;
					flag2 = false;
					flag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void TopScores(List<Point> tempPoints)
		{
			Console.WriteLine("\nPoints:");
			if (tempPoints.Count > 0)
			{
				for (int i = 0; i < tempPoints.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells", i + 1, tempPoints[i].Name, tempPoints[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty Top Scores!\n");
			}
		}

		private static void NextMove(char[,] field, char[,] bombArray, int row, int column)
		{
			char bombsCount = CalculateBombs(bombArray, row, column);

			bombArray[row, column] = bombsCount;
			field[row, column] = bombsCount;
		}

		private static void Dumpp(char[,] board)
		{
			int row = board.GetLength(0);
			int column = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < row; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < column; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PutBomb()
		{
			int rows = 5;
			int columns = 10;
			char[,] gameField = new char[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					gameField[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int kol = i2 / columns;
				int row = i2 % columns;
				if (row == 0 && i2 != 0)
				{
					kol--;
					row = columns;
				}
				else
				{
					row++;
				}

				gameField[kol, row - 1] = '*';
			}

			return gameField;
		}

		private static void Calculations(char[,] field)
		{
			int kol = field.GetLength(0);
			int row = field.GetLength(1);

			for (int i = 0; i < kol; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (field[i, j] != '*')
					{
						char calculateBomb = CalculateBombs(field, i, j);
						field[i, j] = calculateBomb;
					}
				}
			}
		}

		private static char CalculateBombs(char[,] r, int rr, int row)
		{
			int bombSum = 0;
			int rows = r.GetLength(0);
			int column = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, row] == '*')
				{ 
					bombSum++; 
				}
			}

			if (rr + 1 < rows)
			{
				if (r[rr + 1, row] == '*')
				{ 
					bombSum++; 
				}
			}

			if (row - 1 >= 0)
			{
				if (r[rr, row - 1] == '*')
				{ 
					bombSum++;
				}
			}

			if (row + 1 < column)
			{
				if (r[rr, row + 1] == '*')
				{ 
					bombSum++;
				}
			}

			if ((rr - 1 >= 0) && (row - 1 >= 0))
			{
				if (r[rr - 1, row - 1] == '*')
				{ 
					bombSum++; 
				}
			}

			if ((rr - 1 >= 0) && (row + 1 < column))
			{
				if (r[rr - 1, row + 1] == '*')
				{ 
					bombSum++; 
				}
			}

			if ((rr + 1 < rows) && (row - 1 >= 0))
			{
				if (r[rr + 1, row - 1] == '*')
				{ 
					bombSum++; 
				}
			}

			if ((rr + 1 < rows) && (row + 1 < column))
			{
				if (r[rr + 1, row + 1] == '*')
				{ 
					bombSum++; 
				}
			}

			return char.Parse(bombSum.ToString());
		}
	}
}

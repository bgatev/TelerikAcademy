namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        public GameResult GetResult(string board)
        {
            for (int i = 0; i < 3; i++)
            {
                // check by rows
                if (board[3 * i] == board[3 * i + 1] && board[3 * i + 1] == board[3 * i + 2])
                {
                    if (board[3 * i] == 'X') return GameResult.WonByX;
                    else if (board[3 * i] == 'O') return GameResult.WonByO;
                }
                //check by cols
                else if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    if (board[i] == 'X') return GameResult.WonByX;
                    else if (board[i] == 'O') return GameResult.WonByO;
                }
            }

            //check by diags
            if (board[0] == board[4] && board[4] == board[8])
            {
                if (board[0] == 'X') return GameResult.WonByX;
                else if (board[0] == 'O') return GameResult.WonByO;
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                if (board[2] == 'X') return GameResult.WonByX;
                else if (board[2] == 'O') return GameResult.WonByO;
            }

            int index = board.IndexOf('-');

            if (index != -1) return GameResult.NotFinished;
            else return GameResult.Draw;
        }
    }
}

using System.Collections.Generic;

namespace TicTakToeApp
{
    public class GameEngine
    {
        public readonly List<Player> Players = new List<Player>();
        private readonly StringToMoveConverter converter = new StringToMoveConverter();
        private Board board= new Board();
       
        public void CreatePlayer(Player player)
        {
            Players.Add(player);
        }

        public void RunGame() 
        {
            
            var didAPlayerWin = false;
            while (!didAPlayerWin && Players.Count>0)
            {
                didAPlayerWin = IteratePlayerTurns();
            }
        }

        private bool IteratePlayerTurns()
        {
            foreach (var player in Players)
            {
                var moveString = player.GetMove(board);

                if (moveString == "q")
                {
                    KillPlayer(player); //add goodbye message
                }

                else
                {
                    var move = converter.ConvertToMove(moveString);

                    player.AddMove(move);
                    //board.AddMove(move); //problem when player is deleted

                    if (player.DidWin())
                    {
                        //winclass message accepting player as parameter
                        return true;
                    }

                    //display board with playerlist as parameter 
                }
            }

            return false;
        }

        public void KillPlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
using System;
using Sources.View.UserInterface.Screens;

namespace Sources.View.UserInterface.Elements.Game
{
    public class EndScreenLogicView
    {
        private readonly WinScreen _win;

        private readonly LoseScreen _lose;

        public EndScreenLogicView(WinScreen win, LoseScreen lose)
        {
            _win = win ? win : throw new ArgumentNullException(nameof(win));
            _lose = lose ? lose : throw new ArgumentNullException(nameof(lose));
        }

        public void CloseAll()
        {
            _lose.gameObject.SetActive(false);
            
            _win.gameObject.SetActive(false);
        }
        
        public void OnDefeat()
        {
            _lose.gameObject.SetActive(true);
        }

        public void OnWon()
        {
            _win.gameObject.SetActive(true);
        }
    }
}
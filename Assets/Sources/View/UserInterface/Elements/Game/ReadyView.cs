using System;
using UnityEngine;

namespace Sources.View.UserInterface.Elements.Game
{
    [Serializable]
    public class ReadyView
    {
        [SerializeField] private GameObject _choose;

        [SerializeField] private GameObject _playerReady;

        [SerializeField] private GameObject _enemyReady;

        public void OnStartChoosing()
        {
            _choose.SetActive(true);
        }

        public void OnStopChoosing()
        {
            _choose.SetActive(false);
        }

        public void OnPlayerReady()
        {
            _playerReady.SetActive(true);
        }

        public void OnPlayerUnReady()
        {
            _playerReady.SetActive(false);
        }

        public void OnEnemyReady()
        {
            _enemyReady.SetActive(true);
        }

        public void OnEnemyUnReady()
        {
            _enemyReady.SetActive(false);
        }

        public void InActiveAll()
        {
            _choose.SetActive(false);
            
            _playerReady.SetActive(false);
            
            _enemyReady.SetActive(false);
        }
    }
}
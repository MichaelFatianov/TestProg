using Main.Scripts.Environment;
using Main.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Main.Scripts
{
    public class GameManager: IStartable
    {
        [Inject] private PlayerUnit _player;
        [Inject] private FinishUnit _finish;
        
        [Inject] private PlayerInputHandler _playerInputHandler;
        
        [Inject] private EndgameUI _endgameUI;
        [Inject] private FinishUI _finishUI;
        [Inject] private GameUI _gamehUI;
        
        void IStartable.Start()
        {
            _player.Initialize(OnPlayerDamage, OnPlayerDeath);
            _finish.Initialize(OnFinish);
            
            _endgameUI.Initialize(OnRestart);
            _finishUI.Initialize(OnRestart, OnExit);
        }

        void OnFinish()
        {
            _finishUI.Show(true);
            _gamehUI.Show(false);
            _playerInputHandler.Lock(true);
        }

        void OnPlayerDamage(float currentHealth)
        {
           _gamehUI.UpdateHealth(currentHealth);
        }

        void OnPlayerDeath()
        {
            _endgameUI.Show(true);
            _gamehUI.Show(false);
            _playerInputHandler.Lock(true);
        }

        void OnExit()
        {
            Application.Quit();
        }

        void OnRestart()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
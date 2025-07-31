using System;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.UI
{
    public class FinishUI:UIScreen,IDisposable
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        public void Initialize(Action onRestart, Action onExit)
        {
            _restartButton.onClick.AddListener(onRestart.Invoke);
            _exitButton.onClick.AddListener(onExit.Invoke);
        }

        public void Dispose()
        {
            _restartButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
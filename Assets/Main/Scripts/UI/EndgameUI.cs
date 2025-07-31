using System;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Scripts.UI
{
    public class EndgameUI: UIScreen,IDisposable
    {
        [SerializeField] private Button _restartButton;

        public void Initialize(Action onRestart)
        {
            _restartButton.onClick.AddListener(onRestart.Invoke);
        }

        public void Dispose()
        {
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}
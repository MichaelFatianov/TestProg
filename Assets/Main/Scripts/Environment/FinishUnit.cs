using System;
using UnityEngine;

namespace Main.Scripts.Environment
{
    public class FinishUnit:MonoBehaviour
    {
        private Action _onFinish;
        
        public void Initialize(Action onFinish)
        {
            _onFinish = onFinish;
        }
        
        void OnTriggerEnter(Collider other)
        {
            var player = other.gameObject.GetComponent<PlayerUnit>();
            if (player is { } unit)
            {
                _onFinish?.Invoke();
            }
        }
    }
}
using TMPro;
using UnityEngine;

namespace Main.Scripts.UI
{
    public class GameUI:UIScreen
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        public void UpdateHealth(float health)
        {
            _healthText.text = $"Health: {health}";
        }
    }
}
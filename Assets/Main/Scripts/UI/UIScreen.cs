using UnityEngine;

namespace Main.Scripts.UI
{
    public class UIScreen : MonoBehaviour
    {
        public void Show(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}
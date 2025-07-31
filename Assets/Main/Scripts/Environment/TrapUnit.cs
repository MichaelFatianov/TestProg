using Main.Scripts.Player;
using UnityEngine;

namespace Main.Scripts.Environment
{
    public class TrapUnit:MonoBehaviour
    {
        [SerializeField] private float _damage = 25f;
        private float _damageTimeoutDelta;
        
        private void OnTriggerStay(Collider other)
        {
            Debug.Log(other.gameObject.name);
            var unit = other.GetComponent<PlayerUnit>();
            if (unit is not IDamageable damageable) return;
            if (_damageTimeoutDelta < 1f) return;
            _damageTimeoutDelta = 0f;
            damageable.GetDamage(_damage);
        }

        private void Update()
        {
            _damageTimeoutDelta += Time.deltaTime;
        }
    }
}
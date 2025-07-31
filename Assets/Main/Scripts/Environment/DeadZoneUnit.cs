using Main.Scripts.Player;
using UnityEngine;

namespace Main.Scripts.Environment
{
    public class DeadZoneUnit:MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            var unit = other.GetComponent<PlayerUnit>();
            if (unit is not IDamageable damageable) return;
            damageable.GetDamage(999f);
        }
    }
}
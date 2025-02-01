using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int damage = 1;

        public void TakeDamage(GameObject target)
        {
            var healthcomponent = target.GetComponent<HealthComponent>();
            if (healthcomponent != null)
            {
                healthcomponent.TakeDamage(damage);
            }
        }
    }
}
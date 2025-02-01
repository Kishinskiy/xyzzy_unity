using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private UnityEvent onDeath = null;
        [SerializeField] private UnityEvent onHit = null;

        public void TakeDamage(int amount)
        {
            maxHealth -= amount;
            onHit?.Invoke();
            if (maxHealth <= 0)
            {
                onDeath?.Invoke();
            }
        }
    }
}




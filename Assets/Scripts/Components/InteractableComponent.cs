using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            if (_action != null)
            {
                _action.Invoke();
            }
        }
    }
}
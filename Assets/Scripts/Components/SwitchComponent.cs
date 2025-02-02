using UnityEngine;

namespace PixelCrew.Components
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool isOn;

        [SerializeField] private string _animationKey;

        public void Switch()
        {
             isOn = !isOn; 
             animator.SetBool(_animationKey, isOn); 
        }

        [ContextMenu("Switch")]
        public void SwitchOn()
        {
            Switch();
        }

    }
}
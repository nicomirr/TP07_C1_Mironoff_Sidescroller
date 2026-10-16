using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "HarborBellDataSo", menuName = "Scriptable Objects/HarborBellDataSo")]
    public class HarborBellDataSo : ScriptableObject
    {
        [SerializeField] private string _bellAnimationTrigger;
        public int BellAnimationTrigger => Animator.StringToHash(_bellAnimationTrigger);
    }
}


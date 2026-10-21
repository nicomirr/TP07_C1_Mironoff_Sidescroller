using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyLinearJumpDataSo", menuName = "Scriptable Objects/EnemyLinearJumpDataSo")]
    public class EnemyLinearJumpDataSo : EnemyJumpDataSo
    {
        [SerializeField] private float _jumpCooldown;
        public float JumpCooldown => _jumpCooldown;        
    }
}


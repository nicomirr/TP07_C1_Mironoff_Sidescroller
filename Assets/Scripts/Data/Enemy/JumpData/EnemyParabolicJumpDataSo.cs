using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyParabolicJumpDataSo", menuName = "Scriptable Objects/EnemyParabolicJumpDataSo")]
    public class EnemyParabolicJumpDataSo : EnemyJumpDataSo
    {
        [SerializeField] private float _horizontalJumpForce;
        public float HorizontalJumpForce => _horizontalJumpForce;
    }

}


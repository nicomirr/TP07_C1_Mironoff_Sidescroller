using UnityEngine;
using Game.Core;

//MOVEMENT DATA PUEDE SER BASE, Y PARA CADA TIPO DE MOVIMIENTO, UNA DERIVADA
namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyMovementDataSo", menuName = "Scriptable Objects/EnemyMovementDataSo")]
    public class EnemyMovementDataSo : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        public float MovementSpeed => _movementSpeed;
    }

}


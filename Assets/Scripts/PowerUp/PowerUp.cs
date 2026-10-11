using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Marker;

namespace Game.PowerUp
{
    public class PowerUp : MonoBehaviour, IPowerUp
    {
        [SerializeField] private PowerUpDataSo _data;

        public PowerUpType PowerUpType => _data.PowerUpType;
        public AudioCategory AudioCategory => _data.PowerUpSfx;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<PlayerMarker>(out _))
                this.gameObject.SetActive(false);
        }
    }
}


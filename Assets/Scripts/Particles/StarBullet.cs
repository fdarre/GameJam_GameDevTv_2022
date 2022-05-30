using UnityEngine;
using Enemies;

namespace Particles
{
    public class StarBullet : MonoBehaviour
    {
        #region Serialized in Inspector
        
        [SerializeField] private float bulletSpeed;
        
        #endregion

        #region Init

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            _playerTransformForwardZ = GameObject.FindGameObjectWithTag("Player").transform.forward.z;
            //Use object pooling instead
            Destroy(this.gameObject, 0.5f);
        }
        #endregion

        #region Update

        private void Update()
        {
            _transform.Translate(new Vector3(_playerTransformForwardZ * bulletSpeed * Time.deltaTime, 0, 0));
        }

        #endregion

        #region Collisions

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyHealth>().TakeDamage();
                Destroy(this.gameObject);
            }
        }

        #endregion

        #region Private Variables

        private float _playerTransformForwardZ;
        private Transform _transform;

        #endregion
    }
}

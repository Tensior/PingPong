using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPlatformView : View
    {
        public event Action OnBallHit;
        
        [SerializeField] private float _movementSpeed = 30;
        
        private Rigidbody2D _rigidbody2d;

        protected override void Awake()
        {
            base.Awake();
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Сдвинуть платформу на заданное расстояние с учётом её скорости
        /// </summary>
        /// <param name="translation">Расстояние</param>
        public void Translate(float translation)
        {
            _rigidbody2d.MovePosition(_rigidbody2d.position + translation * _movementSpeed * Vector2.right);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<BallView>() != null)
            {
                OnBallHit?.Invoke();
            }
        }
    }
}
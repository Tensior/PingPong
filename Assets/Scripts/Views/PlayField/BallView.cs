using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallView : View
    {
        [SerializeField] private Vector2Int _ballVelocityLimits;
        [SerializeField] private Vector2Int _ballSizeLimits;

        private Rigidbody2D _ball;

        protected override void Awake()
        {
            base.Awake();
            _ball = GetComponent<Rigidbody2D>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _ball.position = Vector2.zero;
            RandomizeVelocity();
            RandomizeSize();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _ball.velocity = Vector2.zero;
        }

        private void RandomizeVelocity()
        {
            var angle = Random.Range(0f, 2f * Mathf.PI);
            var value = Random.Range(_ballVelocityLimits.x, _ballVelocityLimits.y);
            _ball.velocity = new Vector2(Mathf.Cos(angle) * value, Mathf.Sin(angle) * value);
        }

        private void RandomizeSize()
        {
            var ballSize = Random.Range(_ballSizeLimits.x, _ballSizeLimits.y);
            transform.localScale = new Vector3(ballSize, ballSize, transform.localScale.z);
        }
    }
}
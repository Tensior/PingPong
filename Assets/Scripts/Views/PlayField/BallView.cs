using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class BallView : View
    {
        [SerializeField] private Vector2Int _ballVelocityLimits;
        [SerializeField] private Vector2Int _ballSizeLimits;

        private Rigidbody2D _ballRigidbody2D;
        private SpriteRenderer _ballSpriteRenderer;

        protected override void Awake()
        {
            base.Awake();
            _ballRigidbody2D = GetComponent<Rigidbody2D>();
            _ballSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _ballRigidbody2D.position = Vector2.zero;
            RandomizeVelocity();
            RandomizeSize();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _ballRigidbody2D.velocity = Vector2.zero;
        }

        public void SetBallColor(Color color)
        {
            _ballSpriteRenderer.color = color;
        }

        private void RandomizeVelocity()
        {
            var angle = Random.Range(0f, 2f * Mathf.PI);
            var value = Random.Range(_ballVelocityLimits.x, _ballVelocityLimits.y);
            _ballRigidbody2D.velocity = new Vector2(Mathf.Cos(angle) * value, Mathf.Sin(angle) * value);
        }

        private void RandomizeSize()
        {
            var ballSize = Random.Range(_ballSizeLimits.x, _ballSizeLimits.y);
            transform.localScale = new Vector3(ballSize, ballSize, transform.localScale.z);
        }
    }
}
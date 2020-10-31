using strange.extensions.mediation.impl;
using UnityEngine;

namespace Views.PlayField
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallView : View
    {
        [SerializeField] private Vector2Int _ballSpeedLimits;

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
            _ball.velocity = GetRandomVelocity(_ballSpeedLimits);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _ball.velocity = Vector2.zero;
        }

        private Vector2 GetRandomVelocity(Vector2 limits)
        {
            var angle = Random.Range(0f, 2f * Mathf.PI);
            var value = Random.Range(limits.x, limits.y);
            return new Vector2(Mathf.Cos(angle) * value, Mathf.Sin(angle) * value);
        }
    }
}
using UnityEngine;
using Random = UnityEngine.Random;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ball;
    [SerializeField] private Vector2Int _ballSpeedLimits;

    private void Awake()
    {
        _ball.velocity = GetRandomVelocity(_ballSpeedLimits);
    }

    private Vector2 GetRandomVelocity(Vector2 limits)
    {
        var angle = Random.Range(0f, Mathf.PI);
        var value = Random.Range(limits.x, limits.y);
        return new Vector2(Mathf.Cos(angle) * value, Mathf.Sin(angle) * value);
    }
}

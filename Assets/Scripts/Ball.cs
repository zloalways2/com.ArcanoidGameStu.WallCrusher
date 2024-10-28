using UnityEngine;

public class Ball : MonoBehaviour
{
  public float _ballSpeed = 400f;
  [SerializeField] private Transform _startPosition;

  private Rigidbody2D _rb;
  private float minVerticalSpeed = 0.5f;

  private float minHorizontalSpeed = 0.5f;

  void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
    LaunchBall();
  }

  public void SetStartPosition()
  {
    transform.position = _startPosition.position;
  }

  void LaunchBall()
  {
    Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1).normalized;
    _rb.velocity = direction * _ballSpeed;
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Brick"))
    {
      Destroy(collision.gameObject);
    }

    AdjustBallDirection();
    if (collision.gameObject.CompareTag("SideBoundary"))
    {
      FixSideBoundaryBounce();
    }
    else if (collision.gameObject.CompareTag("TopBoundary"))
    {
      FixTopBoundaryBounce();
    }
  }

  void AdjustBallDirection()
  {
    Vector2 currentVelocity = _rb.velocity;

    if (Mathf.Abs(currentVelocity.y) < minVerticalSpeed)
    {
      currentVelocity.y = Mathf.Sign(currentVelocity.y) * minVerticalSpeed;
    }

    _rb.velocity = currentVelocity.normalized * _ballSpeed;
  }

  void FixSideBoundaryBounce()
  {
    Vector2 currentVelocity = _rb.velocity;

    if (Mathf.Abs(currentVelocity.x) < minHorizontalSpeed)
    {
      currentVelocity.x = Mathf.Sign(currentVelocity.x) * minHorizontalSpeed;
    }

    if (currentVelocity.x > 0)
    {
      currentVelocity.x = -Mathf.Abs(currentVelocity.x);
      _rb.velocity = currentVelocity;
    }
    else
    {
      currentVelocity.x = Mathf.Abs(currentVelocity.x);
      _rb.velocity = currentVelocity;
    }
  }

  void FixTopBoundaryBounce()
  {
    Vector2 currentVelocity = _rb.velocity;

    if (currentVelocity.y > 0)
    {
      currentVelocity.y = -Mathf.Abs(currentVelocity.y);
      _rb.velocity = currentVelocity;
    }
  }
}
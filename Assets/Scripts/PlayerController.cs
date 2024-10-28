using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Transform _startPosition;
  [SerializeField] private float _screenBoundary = 0.5f;
  [SerializeField] private float _speed = 10f;
  
  private float _platformWidth;
  private bool _isTouching; 

  void Awake()
  {
    _platformWidth = transform.localScale.x / 2;
  }

  private void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.phase == TouchPhase.Began)
      {
        _isTouching = true;
      }
      else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
      {
        _isTouching = false;
      }

      if (_isTouching)
      {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

        MovePlatform(touchPosition.x);
      }
    }
  }

  public void SetStartPosition()
  {
    transform.position = _startPosition.position;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

      if (ballRb != null)
      {
        float hitPoint = collision.GetContact(0).point.x - transform.position.x;
        
        float platformWidth = GetComponent<Collider2D>().bounds.size.x;
        float normalizedHitPoint = hitPoint / (platformWidth );
        
        Vector2 newDirection = new Vector2(normalizedHitPoint, 1).normalized;
        ballRb.velocity = newDirection * ballRb.velocity.magnitude;
      }
    }
  }
  
  private void MovePlatform(float targetX)
  {
    float clampedTargetX = Mathf.Clamp(targetX, -_screenBoundary + _platformWidth, _screenBoundary - _platformWidth);
    Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(clampedTargetX, transform.position.y, transform.position.z), _speed * Time.deltaTime);
    transform.position = newPosition;
  }
}
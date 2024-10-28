using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
  [SerializeField] private int _health = 1;

  private LevelController _levelController;

  private void Awake()
  {
    _levelController = GetComponentInParent<LevelController>();
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      _health--;
      if (_health <= 0)
      {
        Destroy(gameObject);
        _levelController.CheckWin();
      }
    }
  }
}
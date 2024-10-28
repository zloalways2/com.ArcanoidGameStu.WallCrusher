using System;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{
  public event Action LevelLost3;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ball"))
    {
      LevelLost3?.Invoke();
    }
  }
}
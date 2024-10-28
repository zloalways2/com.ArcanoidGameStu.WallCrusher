using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  public event Action LevelCompleted3;

  [SerializeField] private int _brickDestroyedCounter;
  [SerializeField] private List<GameObject> _allBricks;

  private int _brickDestroyedCount;

  private void Update()
  {
    if (_brickDestroyedCounter >= _allBricks.Count)
    {
      _brickDestroyedCount = 0;
      LevelCompleted3?.Invoke();
    }
  }
  
  public void CheckWin()
  {
    _brickDestroyedCount += 1;
    if (_brickDestroyedCount >= _allBricks.Count)
    {
      _brickDestroyedCount = 0;
      LevelCompleted3?.Invoke();
    }
  }
}
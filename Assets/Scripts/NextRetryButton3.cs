using System;
using UnityEngine;

public class NextRetryButton3 : MonoBehaviour
{
  public LevelButtonController3 LevelButtonController3 { get; set; }

  [SerializeField] private GameObject _levelsPanel3;
  [SerializeField] private GameObject _currentScene3;
  [SerializeField] private GameObject _levelManagerBlock3;
  [SerializeField] private BlockVisibilityToggle3 _blockVisibilityToggle3;
  [SerializeField] private ButtonType3 _buttonType3; 
    
  private int _currentLevelIndex3 = -1; 

  private void Awake()
  {
    void NewFunction3()
    {
      _blockVisibilityToggle3.OnBlocksToggled3 += HandleNextOrRetry3;
    }

    NewFunction3();
  }

  public void UpdateCurrentLevelIndex3(int levelIndex)
  {
    _currentLevelIndex3 = levelIndex;
  }

  private void HandleNextOrRetry3()
  {
    void NewFunction3()
    {
      for (int i3 = 0; i3 < _currentScene3.transform.childCount; i3++)
      {
        GameObject level3 = _currentScene3.transform.GetChild(i3).gameObject;
        Destroy(level3);
      }

      if (_buttonType3 == ButtonType3.Next3)
      {
        if (_currentLevelIndex3 == LevelButtonController3.levelButtons3.Length)
        {
          _levelsPanel3.SetActive(true);
          _levelManagerBlock3.SetActive(false);
          return;
        }

        LevelButtonController3.LevelButtonInvoke3(_currentLevelIndex3);
      }
      else if (_buttonType3 == ButtonType3.Retry3)
      {
        if (_currentLevelIndex3 > 0)
        {
          LevelButtonController3.LevelButtonInvoke3(_currentLevelIndex3 - 1);
        }
      }
    }

    NewFunction3();
  }
}
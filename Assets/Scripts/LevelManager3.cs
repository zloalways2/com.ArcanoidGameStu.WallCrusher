using System;
using System.Collections;
using UnityEngine;

public class LevelManager3 : MonoBehaviour
{
  [SerializeField] private GameObject _winView;
  [SerializeField] private GameObject _loseView;
  [SerializeField] private LevelTimer3 _levelTimer3;
  [SerializeField] private BottomBoundary _bottomBoundary;
  [SerializeField] private RecordsView _recordsView;
  [SerializeField] private GameObject _permanentScene2;
  [SerializeField] private GameObject _levelScene3;
  [SerializeField] private Ball _ball;
  [SerializeField] private PlayerController _playerController;
  [SerializeField] private BlockVisibilityToggle3 _optionsButtonBlockVisibilityToggle1;

  private int _levelNumber3;

  private void Awake()
  {
    _levelTimer3.LevelLost3 += OnLose3;
    _bottomBoundary.LevelLost3 += OnLose3;
    _optionsButtonBlockVisibilityToggle1.OnBlocksToggled3 += OnOptionsButtonClicked;
  }

  public void SubscribeWinEvent(LevelController levelController, int levelNumber)
  {
    _levelNumber3 = levelNumber;
    levelController.LevelCompleted3 += OnWin3;
  }

  private void OnLose3()
  {
    _levelTimer3.StopTimer3();
    SetGameplayStartsPositions();
    _loseView.SetActive(true);
    _permanentScene2.SetActive(false);
  }

  private void OnWin3()
  {
    _levelTimer3.StopTimer3();
    SetGameplayStartsPositions();
    _winView.SetActive(true);
    _permanentScene2.SetActive(false);
    _recordsView.UpdateRecords(_levelNumber3, _levelTimer3.MaxTimerValue3 - _levelTimer3.TimerValue);
  }

  private void OnOptionsButtonClicked()
  {
    _levelTimer3.StopTimer3();
    SetGameplayStartsPositions();
    for (int i = 0; i < _levelScene3.transform.childCount; i++)
    {
      GameObject level = _levelScene3.transform.GetChild(i).gameObject;
      Destroy(level);
    }
  }

  private void SetGameplayStartsPositions()
  {
    _ball.SetStartPosition();
    _playerController.SetStartPosition();
  }
}
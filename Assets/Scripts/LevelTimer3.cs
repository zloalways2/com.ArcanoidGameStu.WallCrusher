using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer3 : MonoBehaviour
{
  public event Action LevelLost3;
  public int TimerValue { get; private set; }
  public int MaxTimerValue3 => _maxTimerValue3;

  [SerializeField] private Text _timer3;
  [SerializeField] private Text _winViewTimer3;
  [SerializeField] private Text _loseViewTimer3;
  [SerializeField] private int _maxTimerValue3;

  private void OnEnable()
  {
    void NewFunction3()
    {
      SetValueSlider3(_maxTimerValue3);
      StartCoroutine(TimerCoroutine3());
    }

    NewFunction3();
  }

  public void StopTimer3()
  {
    StopAllCoroutines();
  }

  private IEnumerator TimerCoroutine3()
  {
    int maxCount3 = _maxTimerValue3;
    while (maxCount3 > 0)
    {
      yield return new WaitForSeconds(1);
      maxCount3 -= 1;
      SetValueSlider3(maxCount3);
    }

    LevelLost3?.Invoke();
  }

  private void SetValueSlider3(int value)
  {
    TimerValue = value;
    _timer3.text = value + " sec";
    _winViewTimer3.text = _timer3.text;
    _loseViewTimer3.text = _timer3.text;
  }
}
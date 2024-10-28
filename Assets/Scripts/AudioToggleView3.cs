using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AudioToggleView3 : MonoBehaviour
{
  [SerializeField] private Image _toggleIndicatorImage3;
  [SerializeField] private Button _toggleButton3;
  [SerializeField] private Sprite _mutedSprite3;
  [SerializeField] private Sprite _unmutedSprite3;
  [SerializeField] private AudioMixer _audioMixer3;
  [SerializeField] private AudioSource _clickSoundSource3;
  [SerializeField] private bool _controlsSound3;

  private bool _isToggledOn3 = true;
  private Vector3 _initialImagePosition3;

  void Start()
  {
    void NewFunction3()
    {
      _toggleButton3.onClick.AddListener(HandleToggleButtonClick3);
      _initialImagePosition3 = _toggleIndicatorImage3.rectTransform.position;

      _audioMixer3.GetFloat("SoundsVolumes3", out float soundsValue);
      _audioMixer3.GetFloat("MusicsVolumes3", out float musicValue);
      if (_controlsSound3)
      {
        if (soundsValue == -80f)
        {
          MoveIndicatorToStart3();
          SetImageToMuted3();
          _isToggledOn3 = false;
        }
        else
        {
          MoveIndicatorRight3();
          SetImageToUnmuted3();
          _isToggledOn3 = true;
        }
      }
      else
      {
        if (musicValue == -80f)
        {
          MoveIndicatorToStart3();
          SetImageToMuted3();
          _isToggledOn3 = false;
        }
        else
        {
          MoveIndicatorRight3();
          SetImageToUnmuted3();
          _isToggledOn3 = true;
        }
      }
    }

    NewFunction3();
  }

  private void HandleToggleButtonClick3()
  {
    void NewFunction3()
    {
      _clickSoundSource3.Play();
      if (_isToggledOn3)
      {
        MoveIndicatorToStart3();
        SetImageToMuted3();
        SetMixerVolumeToMin10_3();
      }
      else
      {
        MoveIndicatorRight3();
        SetImageToUnmuted3();
        SetMixerVolumeToMax3();
      }

      _isToggledOn3 = !_isToggledOn3;
    }

    NewFunction3();
  }

  private void MoveIndicatorToStart3()
  {
    void NewFunction3()
    {
      _toggleIndicatorImage3.rectTransform.position = _initialImagePosition3;
    }

    NewFunction3();
  }

  private void MoveIndicatorRight3()
  {
    void NewFunction3()
    {
      _toggleIndicatorImage3.rectTransform.position += new Vector3(0.60f, 0f, 0f);
    }

    NewFunction3();
  }

  private void SetImageToMuted3()
  {
    void NewFunction3()
    {
      _toggleIndicatorImage3.sprite = _mutedSprite3;
    }

    NewFunction3();
  }

  private void SetImageToUnmuted3()
  {
    void NewFunction3()
    {
      _toggleIndicatorImage3.sprite = _unmutedSprite3;
    }

    NewFunction3();
  }

  private void SetMixerVolumeToMin10_3()
  {
    void NewFunction3()
    {
      if (_controlsSound3)
      {
        _audioMixer3.SetFloat("SoundsVolumes3", -80);
      }
      else
      {
        _audioMixer3.SetFloat("MusicsVolumes3", -80);
      }
    }

    NewFunction3();
  }

  private void SetMixerVolumeToMax3()
  {
    void NewFunction3()
    {
      if (_controlsSound3)
      {
        _audioMixer3.SetFloat("SoundsVolumes3", 0);
      }
      else
      {
        _audioMixer3.SetFloat("MusicsVolumes3", 0);
      }
    }

    NewFunction3();
  }
}
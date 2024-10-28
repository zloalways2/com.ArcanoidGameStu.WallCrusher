using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsView : MonoBehaviour
{
  [SerializeField] private GameObject _recordTextPrefab;
  [SerializeField] private List<Transform> _recordPanels;

  private const int MaxRecordsPerLevel = 5;
  private List<List<Text>> levelRecords = new List<List<Text>>();

  private void Awake()
  {
    SetValues();
    LoadAllRecords();
  }

  public void UpdateRecords(int level, float time)
  {
    List<float> records = LoadRecords(level);

    records.Add(time);
    records.Sort();
    if (records.Count > MaxRecordsPerLevel)
    {
      records.RemoveAt(records.Count - 1);
    }

    SaveRecords(level, records);
    DisplayRecords(level, records);
  }

  private void SetValues()
  {
    for (int i = 0; i < _recordPanels.Count; i++)
    {
      List<Text> recordsForLevel = new List<Text>();

      for (int j = 0; j < MaxRecordsPerLevel; j++)
      {
        Text recordText = Instantiate(_recordTextPrefab, _recordPanels[i]).GetComponent<Text>();
        recordText.text = $"{j + 1}: 000 sec";
        recordsForLevel.Add(recordText);
      }

      levelRecords.Add(recordsForLevel);
    }
  }

  public void LoadAllRecords()
  {
    for (int i = 1; i <= 10; i++) DisplayRecords(i, LoadRecords(i));
  }

  private List<float> LoadRecords(int level)
  {
    List<float> records = new List<float>();
    for (int i = 0; i < MaxRecordsPerLevel; i++)
    {
      float record = PlayerPrefs.GetFloat("Level3" + level + "Record" + i, -1);
      if (record != -1) records.Add(record);
    }

    return records;
  }

  private void SaveRecords(int level, List<float> records)
  {
    for (int i = 0; i < MaxRecordsPerLevel; i++)
    {
      if (i < records.Count)
      {
        PlayerPrefs.SetFloat("Level3" + level + "Record" + i, records[i]);
      }
      else
      {
        PlayerPrefs.DeleteKey("Level3" + level + "Record" + i);
      }
    }

    PlayerPrefs.Save();
  }


  private void DisplayRecords(int level, List<float> records)
  {
    List<Text> recordTexts = levelRecords[level - 1];

    for (int i = 0; i < recordTexts.Count; i++)
    {
      if (i < records.Count)
      {
        recordTexts[i].text = $"{i + 1}: {records[i]} sec";
      }
      else
      {
        recordTexts[i].text = $"{i + 1}: 000 sec";
      }
    }
  }
}
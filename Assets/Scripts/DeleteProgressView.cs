using UnityEngine;

public class DeleteProgressView : MonoBehaviour
{
  [SerializeField] private BlockVisibilityToggle3 _blockVisibilityToggle1;
  [SerializeField] private RecordsView _recordsView;

  private void Awake()
  {
    _blockVisibilityToggle1.OnBlocksToggled3 += OnDelete;
  }

  private void OnDelete()
  {
    PlayerPrefs.DeleteAll();
    _recordsView.LoadAllRecords();
  }
}
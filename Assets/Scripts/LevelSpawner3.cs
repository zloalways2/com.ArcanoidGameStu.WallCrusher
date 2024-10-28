using UnityEngine;
using UnityEngine.UI;

public class LevelSpawner3 : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _sceneContainer;
    [SerializeField] private Transform _parentTransform; 
    [SerializeField] private BlockVisibilityToggle3 _blockVisibilityToggle;
    [SerializeField] private int lvlnum; 

    private Text _buttonText3; 
    private LevelButtonController3 _levelButtonController3;
    private GameObject _level3_3;

    private void Awake()
    {
        void NewFunction3()
        {
            _levelButtonController3 = GetComponentInParent<LevelButtonController3>();
            _buttonText3 = GetComponent<Button>().GetComponentInChildren<Text>();
            _blockVisibilityToggle.OnBlocksToggled3 += SpawnLevel3;
            _levelButtonController3.LevelTimer3.LevelLost3 += OnLevelLost3;
            _levelButtonController3.BottomBoundary.LevelLost3 += OnLevelLost3;
            if (_buttonText3 != null)
            {
                _buttonText3.text = lvlnum.ToString();
            }
        }

        NewFunction3();
    }

    private void SpawnLevel3()
    {
        void NewFunction3()
        {
            _level3_3 = Instantiate(_levelPrefab, _parentTransform);
            LevelController levelController = _level3_3.GetComponent<LevelController>();
            levelController.LevelCompleted3 += OnLevelCompleted3;
            _levelButtonController3.LevelManager3.SubscribeWinEvent(levelController, lvlnum);
            _levelButtonController3.NextLevelButton3.UpdateCurrentLevelIndex3(lvlnum);
            _levelButtonController3.RetryLevelButton3.UpdateCurrentLevelIndex3(lvlnum);
        }

        NewFunction3();
    }

    private void OnLevelLost3()
    {
        void NewFunction3()
        {
            Destroy(_level3_3);
        }

        NewFunction3();
    }

    private void OnLevelCompleted3()
    {
        Destroy(_level3_3);

        PlayerPrefs.SetInt("Level3" + (lvlnum - 1), 2);
        if (lvlnum < _levelButtonController3.levelButtons3.Length && PlayerPrefs.GetInt("Level1" + lvlnum) != 2)
            PlayerPrefs.SetInt("Level3" + (lvlnum - 1 + 1), 1);
    }
}

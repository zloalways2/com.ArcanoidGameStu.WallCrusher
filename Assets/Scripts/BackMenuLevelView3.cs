using UnityEngine;

public class BackMenuLevelView3 : MonoBehaviour
{
    [SerializeField] private BlockVisibilityToggle3 _blockVisibilityToggle3;
    [SerializeField] private Ball _ball;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _levelScene3;

    private void Awake()
    {
        void NewFunction3()
        {
            OnBlocksToggled3();
        }

        NewFunction3();
    }

    private void OnBlocksToggled3()
    {
        _blockVisibilityToggle3.OnBlocksToggled3 += OnButtonClick3;
    }

    private void OnButtonClick3()
    {
        void NewFunction3()
        {
            _ball.SetStartPosition();
            _playerController.SetStartPosition();
            DeleteSceneLevels3();
        }

        NewFunction3();
    }

    private void DeleteSceneLevels3()
    {
        for (int i3 = 0; i3 < _levelScene3.transform.childCount; i3++)
        {
            ClearScene(i3);
        }

        void ClearScene(int i3)
        {
            GameObject level3 = _levelScene3.transform.GetChild(i3).gameObject;
            Destroy(level3);
        }
    }
}
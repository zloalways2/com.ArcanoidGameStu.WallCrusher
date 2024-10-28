using UnityEngine;
using UnityEngine.UI;

public class ExitButtonController3 : MonoBehaviour
{
    [SerializeField] private Button _exitButton3;

    private void Awake()
    {
        void NewFunction3()
        {
            Exit3();
        }

        NewFunction3();
    }

    private void Exit3()
    {
        void NewFunction3()
        {
            _exitButton3.onClick.AddListener(Application.Quit);
        }

        NewFunction3();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController3 : MonoBehaviour
{
    public Button[] levelButtons3;  
    public Sprite lockedSprite3;    
    public Sprite activeSprite3;    
    public Sprite passedSprite3;    
    public NextRetryButton3 NextLevelButton3;
    public NextRetryButton3 RetryLevelButton3;
    public LevelTimer3 LevelTimer3;
    public LevelManager3 LevelManager3;
    public BottomBoundary BottomBoundary;

    private void Awake()
    {
        void NewFunction3()
        {
            NextLevelButton3.LevelButtonController3 = this;
            RetryLevelButton3.LevelButtonController3 = this;
        }

        NewFunction3();
    }

    private void OnEnable()
    {
        InitializeButtons3();
    }

    public void InitializeButtons3()
    {
        void NewFunction3()
        {
            for (int i3 = 0; i3 < levelButtons3.Length; i3++)
            {
                Button button3 = levelButtons3[i3];
                int levelStatus3;

                if (i3 == 0)
                {
                    levelStatus3 = PlayerPrefs.GetInt("Level3" + i3, 1);
                }
                else
                {
                    levelStatus3 = PlayerPrefs.GetInt("Level3" + i3, 0);
                }

                switch (levelStatus3)
                {
                    case 0:
                        SetButtonState3(button3, lockedSprite3, false);
                        break;
                    case 1:
                        SetButtonState3(button3, activeSprite3, true);
                        break;
                    case 2:
                        SetButtonState3(button3, passedSprite3, true);
                        break;
                }
            }
        }

        NewFunction3();
    }

    public void LevelButtonInvoke3(int levelButtonNumber)
    {
        levelButtons3[levelButtonNumber].onClick.Invoke();
    }

    private void SetButtonState3(Button button, Sprite sprite, bool interactable)
    {
        button.image.sprite = sprite;  
        button.interactable = interactable;  
    }
}

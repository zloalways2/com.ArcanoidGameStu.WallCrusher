using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BlockVisibilityToggle3 : MonoBehaviour
{
    public event Action OnBlocksToggled3;

    [FormerlySerializedAs("_currentBlocks")][SerializeField] private List<GameObject> blocksToHide;
    [FormerlySerializedAs("_targetBlocks")][SerializeField] private List<GameObject> blocksToShow;
    [SerializeField] private Button toggleButton;

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        toggleButton.onClick.AddListener(ToggleBlocksVisibility3);
    }

    private void ToggleBlocksVisibility3()
    {
        void NewFunction3()
        {
            HideBlocks3();
            ShowBlocks3();

            OnBlocksToggled3?.Invoke();

            void ShowBlocks3()
            {
                foreach (GameObject block3 in blocksToShow)
                {
                    block3.SetActive(true);
                }
            }
        }

        NewFunction3();
    }

    private void HideBlocks3()
    {
        void NewFunction3()
        {
            foreach (GameObject block3 in blocksToHide)
            {
                block3.SetActive(false);
            }
        }

        NewFunction3();
    }
}

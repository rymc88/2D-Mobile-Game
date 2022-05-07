using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is Null");
            }

            return _instance;
        }
    }

    [SerializeField] private Text _playerGemCountText;
    [SerializeField] private Image _selectionImg;
    [SerializeField] private Text _gemCount;
    [SerializeField] private Image [] _healthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateLives (int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            //do nothing til we hit max
            if (i == livesRemaining)
            {
                //hide this health bar
                _healthBars[i].enabled = false;
            }
        }
      
    }

    public void UpdateGemCount(int count)
    {
        _gemCount.text = "" + count;
    }

    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "" + gemCount + " G";
    }

    public void UpdateShopSelection(int yPos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    
}

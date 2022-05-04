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

    public void OpenShop(int gemCount)
    {
        _playerGemCountText.text = "" + gemCount + " G";
    }

    public void UpdateShopSelection(int yPos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    private void Awake()
    {
        _instance = this;
    }
}

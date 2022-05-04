using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    private int _currentSelectedItem;
    private int _currentItemCost;

    private Player _player;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.gems);
                
            }

            _shop.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _shop.SetActive(false);
        }
    }

    public void SelectItem(int item)
    { 
        //Debug.Log(item);
        switch (item)
        {
            case 0: //flame
                UIManager.Instance.UpdateShopSelection(0);
                _currentSelectedItem = 0;
                _currentItemCost = 200;
                break;
            case 1: //boots
                UIManager.Instance.UpdateShopSelection(-100);
                _currentSelectedItem = 1;
                _currentItemCost = 400;
                break;
            case 2: //key
                UIManager.Instance.UpdateShopSelection(-200);
                _currentSelectedItem = 2;
                _currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if(_player.gems >= _currentItemCost)
        {
            switch (_currentSelectedItem)
            {
                case 0: //flame
                    GameManager.Instance.hasFlameSword = true;
                    Debug.Log("Flame Sword");
                    break;

                case 1: //boots
                    GameManager.Instance.hasBootsOfFlight = true;
                    Debug.Log("Boots of Flight");
                    break;

                case 2: //key
                    GameManager.Instance.hasCastleKey = true;
                    Debug.Log("Castle Key");
                    break;
            }

            _player.SubtractGems(_currentItemCost);
            //Debug.Log("Purchased " + _currentSelectedItem);
            Debug.Log("Remaining Gems: " + _player.gems);
        }
        else
        {
            Debug.Log("Not Enough Gems. Closing Shop.");
            _shop.SetActive(false);
        }
    }
}

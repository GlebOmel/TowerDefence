using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopItemscr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Towercl selfTower;
    public Image TowerLogo;
    public Text TowerName, TowerPrice;
    public Color BaseColor, SelectColor;
    public GameController gc;
    //public Shopscr Shop;
    public int Index;
    public void SetStartData(Towercl tower, int index, GameController Gc)
    {
        selfTower = tower;
        //TowerLogo.Sprite = tower.Spr;
        TowerName.text = tower.Name;
        TowerPrice.text = tower.Price.ToString();
        Index=index;
        gc =Gc;
    }
    public void OnPointerEnter (PointerEventData eventData)
    {
        GetComponent<Image>().color = SelectColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = BaseColor;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gc.IndexTowerPurchased != Index)
        {
            gc.IndexTowerPurchased = Index;
        }
        else gc.IndexTowerPurchased = -1;
    }

}

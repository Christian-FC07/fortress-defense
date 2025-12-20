using System;
using UnityEngine;
using UnityEngine.UI;

public class archerSpawner : MonoBehaviour
{
    public Transform archersTrfm;
    public GameObject[] archerObj;
    //public ShopItemData itemsData;
    public int[] chosenArcher;
    

    public void Start()
    {
        string[] chosenArcherDecode = GlobalValue.inventoryArchers.Split(',');
        for (int i = 0; i < chosenArcherDecode.Length; i++)
        {
            chosenArcher[i] = int.Parse(chosenArcherDecode[i]);
            Debug.Log("chosenArcher");
        }
    }

    /*public void archerData()
    {
        switch(Inventory.archerID1)
        {
            case 50:
                Instantiate(archerObj[0], archersTrfm);
                Debug.Log("1");
                break;
            case 51:
                Instantiate(archerObj[1], archersTrfm);
                break;
            case 52:
                Instantiate(archerObj[2], archersTrfm);
                break;
            case 53:
                Instantiate(archerObj[3], archersTrfm);
                break;
            case 54:
                Instantiate(archerObj[4], archersTrfm);
                break;
        }
    }
    void archerDataa()
    {
        switch(Inventory.archerID2)
        {
            case 50:
                Instantiate(archerObj[0], archersTrfm);
                break;
            case 51:
                Instantiate(archerObj[1], archersTrfm);
                break;
            case 52:
                Instantiate(archerObj[2], archersTrfm);
                break;
            case 53:
                Instantiate(archerObj[3], archersTrfm);
                break;
            case 54:
                Instantiate(archerObj[4], archersTrfm);
                break;
        }
    }
    void archerDataaa()
    {
        switch(Inventory.archerID3)
        {
            case 50:
                Instantiate(archerObj[0], archersTrfm);
                break;
            case 51:
                Instantiate(archerObj[1], archersTrfm);
                break;
            case 52:
                Instantiate(archerObj[2], archersTrfm);
                break;
            case 53:
                Instantiate(archerObj[3], archersTrfm);
                break;
            case 54:
                Instantiate(archerObj[4], archersTrfm);
                break;
        }
    }
    void archerDataaaa()
    {
        switch(Inventory.archerID4)
        {
            case 50:
                Instantiate(archerObj[0], archersTrfm);
                break;
            case 51:
                Instantiate(archerObj[1], archersTrfm);
                break;
            case 52:
                Instantiate(archerObj[2], archersTrfm);
                break;
            case 53:
                Instantiate(archerObj[3], archersTrfm);
                break;
            case 54:
                Instantiate(archerObj[4], archersTrfm);
                break;
        }
    }
    void archerDataaaaa()
    {
        switch(Inventory.archerID5)
        {
            case 50:
                Instantiate(archerObj[0], archersTrfm);
                break;
            case 51:
                Instantiate(archerObj[1], archersTrfm);
                break;
            case 52:
                Instantiate(archerObj[2], archersTrfm);
                break;
            case 53:
                Instantiate(archerObj[3], archersTrfm);
                break;
            case 54:
                Instantiate(archerObj[4], archersTrfm);
                break;
        }
    }*/
}

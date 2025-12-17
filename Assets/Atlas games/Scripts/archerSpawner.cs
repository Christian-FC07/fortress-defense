using System;
using UnityEngine;
using UnityEngine.UI;

public class archerSpawner : MonoBehaviour
{
    public ShopItemData data;
    public Transform archersTrfm;
    public GameObject[] archerObj;
    public int[]  num;
    private int[] objectData;
    

    void Start()
    {
        //foreach(var location in archersTrfm)
        //{
        //    Debug.Log("archer is here :)");
            //Instantiate(archerObj[1], location);
        //}
        archerData();
    }

    /*ShopItemData.ShopItem GetArcherData(int id)
    {
        ShopItemData.ShopItem chosenData = new ShopItemData.ShopItem();
        for (int i = 0; i < data.ShopData.Length; i++)
        {
            if (data.ShopData[i].id == id)
            {
                chosenData = data.ShopData[i];
            }
        }

        return chosenData;
    }*/

    void archerData()
    {
        /*string[] chosenArcherDecode = GlobalValue.inventoryArchers.Split(',');
        foreach (var num in chosenArcherDecode)
        {
            /*switch(num)
            {
                case "50":
                Debug.Log("50");
                break;
                case "51":
                Debug.Log("51");
                break;
                case "52":
                Debug.Log("52");
                break;
                case "53":
                Debug.Log("53");
                break;
                case "54":
                Debug.Log("54");
                break;
            }

            Debug.Log("archer");
        }*/
        ShopItemData.ShopItem[] itemsData = data.ShopData;

        string[] chosenArcherDecode = GlobalValue.inventoryArchers.Split(',');
        Debug.Log(chosenArcherDecode[0]);
        for (int i = 0; i < chosenArcherDecode.Length; i++)
        {
            if(Convert.ToInt32(chosenArcherDecode[i]) == 53)
            {
                Debug.Log("archer53");
            }
            else if(Convert.ToInt32(chosenArcherDecode[i]) == 50)
            {
                Debug.Log("archer50");
            }

            num[i] = int.Parse(chosenArcherDecode[i]);
            for (int j = 0; j < itemsData.Length; j++)
            {
                if (num[i] == itemsData[j].id)
                {

                    //archerSlotsUI[i].Init(itemsData[j].itemImage);

                }
            }

            /*foreach(var obj in itemsData)
            {
                if (chosenArcher[i] == obj.id)
                {

                    archerSlotsUI[i].Init(obj.itemImage);

                }
            }*/
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class archerSpawner : MonoBehaviour
{
    public ShopItemData data;
    public Image image;
    public Transform[] archersTrfm;
    public GameObject[] archerObj;
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
        foreach(var location in archersTrfm)
        {
            string[] chosenArcherDecode = GlobalValue.inventoryArchers.Split(',');
            for (int i = 0; i < chosenArcherDecode.Length; i++)
            {
                int j = int.Parse(chosenArcherDecode[i]);
                Debug.Log(j);
                switch(j)
                {
                    case 50:
                    Instantiate(archerObj[0], location);
                    break;
                    case 51:
                    Instantiate(archerObj[1], location);
                    break;
                    case 52:
                    Instantiate(archerObj[2], location);
                    break;
                    case 53:
                    Instantiate(archerObj[3], location);
                    break;
                    case 54:
                    Instantiate(archerObj[4], location);
                    break;
                }
            }
        }
    }
}

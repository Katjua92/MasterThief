using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class ItemListMenu : MonoBehaviour {

    public Sprite[] itemList;
    public Image displayItem;
    public Button leftBtn;
    public Button rightBtn;
    public Button itemSpawner;
    public int i = 0;
    public GameObject[] spawnItems;
    public GameObject playerPos;
	// Use this for initialization
	void Start () {
       

    }

    // Update is called once per frame
    void Update () {
        displayItem.sprite = itemList[i];
        
	}

    public void SpawnItem()
    {
        if (i == 0)
        {
            Debug.Log("Mirror");
            Instantiate(spawnItems[0], playerPos.transform.position, Quaternion.identity);
        }

        if (i == 1)
        {
            Debug.Log("Other");
        }

        if (i == 2)
        {
            Debug.Log("Sidste");
        }
    }

    public void Btnr()
    {
        //Debug.Log("ItemNo: " + i);
        if (i == itemList.Length - 1)
        {
            i = 0;
            return;
        }
        if (i < itemList.Length-1)
        {
            i++;
        }
    }

    public void Btnl()
    {
        //Debug.Log("ItemNo: " + i);
        if (i == 0)
        {
            i = itemList.Length - 1;
            return;
        }
        if (i > 0)
        {
            i--;
        }
    }
}

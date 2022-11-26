using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static bool ItemMode;
    public GameObject InventoryUI;
    public GameObject InterfaceUI;

    public int itemselectnumber;

    public Image Selected1;
    public Image Selected2;
    public Image Selected3;
    public Image Selected4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch(ItemMode)
            {
                case true:
                    ItemMode = false;
                    InventoryUI.SetActive(false);
                    break;
                case false:
                    ItemMode = true;
                    InventoryUI.SetActive(true);
                    InterfaceUI.SetActive(false);
                    break;
            }
        }

        if (ItemMode == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                itemselectnumber = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                itemselectnumber = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                itemselectnumber = 3;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                itemselectnumber = 4;
            }
        }

        InventorySelect();
    }

    void InventorySelect()
    {
        switch(itemselectnumber)
        {
            case 1:
                Selected1.color = new Color32(255, 0, 0, 123);
                Selected2.color = new Color32(255, 255, 255, 7);
                Selected3.color = new Color32(255, 255, 255, 7);
                Selected4.color = new Color32(255, 255, 255, 7);
                break;
            case 2:
                Selected2.color = new Color32(255, 0, 0, 123);
                Selected1.color = new Color32(255, 255, 255, 7);
                Selected3.color = new Color32(255, 255, 255, 7);
                Selected4.color = new Color32(255, 255, 255, 7);
                break;
            case 3:
                Selected3.color = new Color32(255, 0, 0, 123);
                Selected1.color = new Color32(255, 255, 255, 7);
                Selected2.color = new Color32(255, 255, 255, 7);
                Selected4.color = new Color32(255, 255, 255, 7);
                break;
            case 4:
                Selected4.color = new Color32(255, 0, 0, 123);
                Selected1.color = new Color32(255, 255, 255, 7);
                Selected3.color = new Color32(255, 255, 255, 7);
                Selected2.color = new Color32(255, 255, 255, 7);
                break;
        }
    }
}

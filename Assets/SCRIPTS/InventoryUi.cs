using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryUi : MonoBehaviour
{
    private TextMeshProUGUI trashText;

    // Start is called before the first frame update
    void Start()
    {
        trashText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateTrashText(PlayerInventory playerInventory)
    {
        trashText.text = playerInventory.NumberOfDiamonds.ToString();
    }
}

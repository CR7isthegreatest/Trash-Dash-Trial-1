using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds {  get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollect;

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollect.Invoke(this);
    }

}

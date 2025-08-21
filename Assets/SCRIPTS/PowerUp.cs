using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public float duration = 6f;


    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // Spawn cool effect to let player know they are powered up

        Instantiate(pickupEffect, transform.position, transform.rotation);

        

        // Apply useful affect to player
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.fowardForce *= multiplier;
     
        // Eleminate power up object
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // wait x amount of second

        yield return new WaitForSeconds(duration);

        // reverse the effect on player

        pm.fowardForce /= multiplier;   

        // Remove Powerup

        Destroy(gameObject);
    }

}

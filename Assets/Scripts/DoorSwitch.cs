using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [SerializeField] private GameObject hiddenDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Corpse"))
        {
            hiddenDoor.SetActive(false);

            //StartCoroutine(RollBoulder(boulder));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hiddenDoor.SetActive(true);
    }
}

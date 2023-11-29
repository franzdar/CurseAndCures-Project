using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLantern : MonoBehaviour
{
    [SerializeField] private GameObject playerLantern;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerLantern.gameObject.SetActive(false);
        }
    }
}

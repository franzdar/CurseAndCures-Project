using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;
    public int checkpointNum;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D actor)
    {
        if (actor.CompareTag("Player"))
        {
            //Save Current Checkpoint Position
            PlayerPrefs.SetInt("Checkpoint", checkpointNum);
            Debug.Log(PlayerPrefs.GetInt("Checkpoint"));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

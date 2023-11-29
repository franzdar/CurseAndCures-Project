using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    public GameObject boulder;
    public AudioSource rollingRockSFX;
    [SerializeField] float stopTime;
    [SerializeField] private bool isTriggered;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = boulder.GetComponent<Rigidbody2D>();
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isTriggered)
        {
            rollingRockSFX.Play();
            isTriggered = true;
        }

        if (collision.CompareTag("Player"))
        {
            Invoke("boulderStop", stopTime);
            StartCoroutine(RollBoulder(boulder));
        }
    }

    private IEnumerator RollBoulder(GameObject boulder)
    {
        rb.isKinematic = false;

        yield return new WaitForSeconds(stopTime);
        rollingRockSFX.Stop();
        Destroy(this.gameObject);
    }
}

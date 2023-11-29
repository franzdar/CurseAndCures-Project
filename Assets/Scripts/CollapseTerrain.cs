using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollapseTerrain : MonoBehaviour
{
    public AudioSource collapseSFX;
    public AudioSource rockFallSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Collapse(this.gameObject));
        }
    }

    public IEnumerator Collapse(GameObject terrain)
    {
        Invoke("TerrainCollapse", 1.5f);
        collapseSFX.Play();
        float i = 0f;
        while (i < 2f)
        {
            i += Time.deltaTime;
            yield return null;
        }

        collapseSFX.Stop();
        terrain.gameObject.SetActive(false);
        Debug.Log("Terrain Collapsed");
    }

    private void TerrainCollapse()
    {
        rockFallSFX.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoySmallObjectTimer : MonoBehaviour
{
    public float destroyTime = 10f;
    
    private void Start()
    {
        StartCoroutine(destroyTimer());
    }

    private IEnumerator destroyTimer()
    {
        yield return new WaitForSecondsRealtime(destroyTime);
        Destroy(gameObject);
    }
}

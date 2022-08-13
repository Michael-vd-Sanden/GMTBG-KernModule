using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private SceneSelect scenes;

    public void Win()
    {
        StartCoroutine(WinBehaviour());
    }

    private IEnumerator WinBehaviour()
    {
        particles.Play();
        yield return new WaitForSeconds(3f);
        scenes.loadEndScene();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D globalLight;
    public float flickerDuration = 30f;
    public ObjectiveManager objMgr;

    [Header("Audio Settings")]
    public AudioSource backgroundMusic;
    public AudioSource scaryMusic;

    private bool hasTriggered = false;

    private void Update()
    {
        if (objMgr.AllObjectivesCompleted() && !hasTriggered)
        {
            hasTriggered = true;
            TriggerFlicker();
        }
    }

    public void TriggerFlicker()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        if (scaryMusic != null && !scaryMusic.isPlaying)
        {
            scaryMusic.Play();
        }

        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        float elapsed = 0f;
        float originalIntensity = globalLight.intensity;

        while (elapsed < flickerDuration)
        {
            globalLight.intensity = Random.Range(0.1f, originalIntensity);

            float waitTime = 0.09f;
            yield return new WaitForSeconds(waitTime);

            elapsed += waitTime;
        }

        globalLight.intensity = originalIntensity;
    }
}

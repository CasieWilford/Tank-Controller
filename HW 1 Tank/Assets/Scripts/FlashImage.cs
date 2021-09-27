using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image image = null;

    Coroutine currentFlashRoutine = null;

    float flashDuration = .2f;
    float maxAlpha = .35f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFlash()
    {
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        // Reset flash animation
        if(currentFlashRoutine != null)
        {
            StopCoroutine(currentFlashRoutine);
        }
        currentFlashRoutine = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        float flashInDuration = flashDuration / 2;

        for (float t = 0; t < flashInDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            image.color = colorThisFrame;
            // Wait until next frame.
            yield return null;
        }

        float flashOutDuration = flashDuration / 2;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            image.color = colorThisFrame;

            yield return null;
        }

        // Ensure alpha is set to 0.
        //image.color = new Color32(0, 0, 0, 0);

    }
}

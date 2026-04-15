using System.Collections;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    [Header("Slide Settings")]
    public float slideDistance = 800f;   // how far it moves down
    public float duration = 0.5f;        // how long the animation takes
    public bool useLocalPosition = true; // UI usually uses localPosition

    private Vector3 startPos;
    private Vector3 targetPos;

    public void StartSlide()
    {
        StopAllCoroutines();
        StartCoroutine(SlideCoroutine());
    }

    private IEnumerator SlideCoroutine()
    {
        // Store starting position
        startPos = useLocalPosition ? transform.localPosition : transform.position;

        // Calculate target position (downwards = negative Y)
        targetPos = startPos + Vector3.down * slideDistance;

        float time = 0f;

        while (time < duration)
        {
            float t = time / duration;

            // Smooth easing (optional but looks better)
            t = Mathf.SmoothStep(0f, 1f, t);

            Vector3 newPos = Vector3.Lerp(startPos, targetPos, t);

            if (useLocalPosition)
                transform.localPosition = newPos;
            else
                transform.position = newPos;

            time += Time.deltaTime;
            yield return null;
        }

        // Ensure exact final position
        if (useLocalPosition)
            transform.localPosition = targetPos;
        else
            transform.position = targetPos;
    }
}
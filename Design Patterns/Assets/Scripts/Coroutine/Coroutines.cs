using System;
using System.Collections;
using UnityEngine;

public static class Coroutines
{
    public static IEnumerator Blink(float duration, float blinkRate, Action<bool> OnBlink, Action OnFinish)
    {
        float timeRunning = 0;
        bool off = false;

        while (timeRunning < duration)
        {
            off = !off;
            OnBlink(off);
            yield return new WaitForSeconds(blinkRate);
            timeRunning += blinkRate;
        }
        if (OnFinish != null)
        {
            OnFinish();
        }
    }

    public static IEnumerator Lerp(float duration, float minValue, float maxValue, Action<float> OnStep, Action OnFinish)
    {
        float timeRunning = 0;
        float value = minValue;

        while (timeRunning < duration)
        {
            value = Mathf.Lerp(minValue, maxValue, timeRunning/duration);
            OnStep(value);
            yield return new WaitForEndOfFrame();
            timeRunning += Time.deltaTime;
        }

        if (OnFinish != null)
        {
            OnFinish();
        }
    }

    public static IEnumerator WaitSeconds(float duration, Action OnFinish)
    {
        float timeRunning = 0;

        while (timeRunning < duration)
        {
            yield return new WaitForEndOfFrame();
            timeRunning += Time.deltaTime;
        }

        if (OnFinish != null)
        {
            OnFinish();
        }
    }
}


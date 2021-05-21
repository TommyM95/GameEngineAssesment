using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image foregroundImage;

    //public Camera camera;

    private float updateSpeedSeconds = 0.1f;

    private void Awake()
    {
        GetComponentInParent<scr_Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elasped = 0f;

        while (elasped < updateSpeedSeconds)
        {
            elasped += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elasped / updateSpeedSeconds);
            yield return null;

        }

        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        Camera camera = FindObjectOfType<Camera>();
        if (camera != null)
        {
            transform.LookAt(camera.transform);
            transform.Rotate(0, 180, 0);
        }
        
    }
}

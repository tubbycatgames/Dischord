using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{
    private DissonanceManager dissonance;
    private Light lt;

    void Start()
    {
        dissonance = GameObject
            .FindWithTag("DissonanceManager")
            .GetComponent<DissonanceManager>();
        lt = GetComponent<Light>();
    }

    void Update()
    {
        lt.intensity = 1 - dissonance.Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{
    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        lt.intensity = 1 - DissonanceManager.Instance.Score;
    }
}

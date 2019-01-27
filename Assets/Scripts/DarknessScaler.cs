using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{
    public float MinSourceLight = 0f;
    public bool ShowFog = true;

    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        RenderSettings.fog = ShowFog;
    }

    void Update()
    {
        // var newIntensity = Mathf.Min(MinSourceLight, 1 - DissonanceManager.Instance.Score);
        // lt.intensity = Mathf.Lerp(
        //     lt.intensity,
        //     newIntensity,
        //     Time.deltaTime
        // );
    }
}

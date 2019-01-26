using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScaler : MonoBehaviour
{
    private DissonanceManager dissonance;

    private Grain grain;
    private LensDistortion lensDistortion;
    private Vignette vignette;

    void Start()
    {
        dissonance = GameObject
            .FindWithTag("DissonanceManager")
            .GetComponent<DissonanceManager>();

        var volume = GetComponent<PostProcessVolume>();
        var profile = volume.profile;

        grain = profile.GetSetting<Grain>();
        lensDistortion = profile.GetSetting<LensDistortion>();
        vignette = profile.GetSetting<Vignette>();
    }

    void Update()
    {
        var ds = dissonance.Score;

        lensDistortion.intensity.value = 50 * ds;

        grain.intensity.value = ds;
        grain.size.value = 3 * ds;

        vignette.intensity.value = ds;

    }
}

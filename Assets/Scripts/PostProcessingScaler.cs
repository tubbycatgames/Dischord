using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScaler : MonoBehaviour
{
    private Grain grain;
    private LensDistortion lensDistortion;
    private Vignette vignette;

    void Start()
    {
        var volume = GetComponent<PostProcessVolume>();
        var profile = volume.profile;

        grain = profile.GetSetting<Grain>();
        lensDistortion = profile.GetSetting<LensDistortion>();
        vignette = profile.GetSetting<Vignette>();
    }

    void Update()
    {
        var ds = DissonanceManager.Instance.Score;

        lensDistortion.intensity.value = 50 * ds;

        grain.intensity.value = ds;
        grain.size.value = 3 * ds;

        vignette.intensity.value = ds;
    }
}

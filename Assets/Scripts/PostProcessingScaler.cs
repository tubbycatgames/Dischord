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
        var dt = Time.deltaTime;

        lensDistortion.intensity.value = Mathf.Lerp(
            lensDistortion.intensity.value, 
            50 * ds, 
            dt);

        grain.intensity.value = Mathf.Lerp(
            grain.intensity.value, 
            ds,
            dt);
        grain.size.value = Mathf.Lerp(
            grain.size.value,
            3 * ds,
            dt);

        vignette.intensity.value = Mathf.Lerp(
            vignette.intensity.value,
            ds,
            dt);
    }
}

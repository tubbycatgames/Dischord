using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScaler : MonoBehaviour
{
    public float BloomMax = 10;
    public float LensDistortionMax = 50;
    public float GrainMax = 1;
    public float VignetteMax = 1;
    public Color VignetteColor = Color.black;

    private Bloom bloom;
    private Grain grain;
    private LensDistortion lensDistortion;
    private Vignette vignette;

    void Start()
    {
        var volume = GetComponent<PostProcessVolume>();
        var profile = volume.profile;

        bloom = profile.GetSetting<Bloom>();
        grain = profile.GetSetting<Grain>();
        lensDistortion = profile.GetSetting<LensDistortion>();
        vignette = profile.GetSetting<Vignette>();
    }

    void Update()
    {
        var ds = DissonanceManager.Instance.Score;
        var dt = Time.deltaTime;

        bloom.intensity.value = Mathf.Lerp(
            bloom.intensity.value,
            BloomMax * ds,
            dt
        );

        lensDistortion.intensity.value = Mathf.Lerp(
            lensDistortion.intensity.value, 
            LensDistortionMax * ds, 
            dt);

        grain.intensity.value = Mathf.Lerp(
            grain.intensity.value, 
            GrainMax * ds,
            dt);
        grain.size.value = Mathf.Lerp(
            grain.size.value,
            3 * ds,
            dt);

        vignette.color.value = VignetteColor;

        vignette.intensity.value = Mathf.Lerp(
            vignette.intensity.value,
            VignetteMax * ds,
            dt);
    }
}

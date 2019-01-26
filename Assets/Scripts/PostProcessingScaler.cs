using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScaler : MonoBehaviour
{
    private GameObject player;
    private GameObject home;

    private Grain grain;
    private LensDistortion lensDistortion;
    private Vignette vignette;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        home = GameObject.FindWithTag("Home");

        var volume = GetComponent<PostProcessVolume>();
        var profile = volume.profile;

        grain = profile.GetSetting<Grain>();
        lensDistortion = profile.GetSetting<LensDistortion>();
        vignette = profile.GetSetting<Vignette>();
    }

    void Update()
    {
        var dissonance = DissonanceManager.GetDissonance(player, home);
        vignette.intensity.value = 1 * dissonance.Score;
    }
}

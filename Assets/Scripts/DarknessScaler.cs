using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{

    public GameObject player;
    public GameObject home;

    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        var dissonance = DissonanceManager.GetDissonance(player, home);
        lt.intensity = 1 - dissonance.Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{

    private GameObject player;
    private GameObject home;

    private Light lt;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        home = GameObject.FindWithTag("Home");
        lt = GetComponent<Light>();
    }

    void Update()
    {
        var dissonance = DissonanceManager.GetDissonance(player, home);
        lt.intensity = 1 - dissonance.Score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessScaler : MonoBehaviour
{

    public GameObject player;
    public GameObject home;
    public float idealDistance = 5;

    private Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentDistance = Vector3.Distance(
            home.transform.position,
            player.transform.position
        );

        lt.intensity = Mathf.Min(
            idealDistance/currentDistance, 
            1
        );
    }
}

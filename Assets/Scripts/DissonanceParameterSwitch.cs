using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissonanceParameterSwitch : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emitter;

    private float currentDissonance;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        currentDissonance = DissonanceManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {

        currentDissonance = Mathf.Lerp(
            currentDissonance,
            DissonanceManager.Instance.Score,
            Time.deltaTime
        );
        emitter.SetParameter("dissonance", currentDissonance);
    }
}

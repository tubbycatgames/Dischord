using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissonanceParameterSwitch : MonoBehaviour
{
    FMODUnity.StudioEventEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("dissonance", DissonanceManager.Instance.Distance);
        Debug.Log(DissonanceManager.Instance.Distance);

    }
}

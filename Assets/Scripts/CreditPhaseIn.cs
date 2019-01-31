using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPhaseIn : MonoBehaviour
{

    public float FadeDuration;

    private CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cg.alpha = Mathf.Lerp(
            0f,
            1f,
            Time.timeSinceLevelLoad / FadeDuration);
    }
}

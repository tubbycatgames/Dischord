using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPhaseIn : MonoBehaviour
{

    public float FadeDuration;
    public CanvasGroup Panel;

    // Start is called before the first frame update
    void Start()
    {
        Panel.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Panel.alpha = Mathf.Lerp(
            0f,
            1f,
            Time.time / FadeDuration);
    }
}

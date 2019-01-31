using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    public float transitionDuration = 5;
    public float goalDistance = 3;

    public CanvasGroup panel;
  
    public static int isHome = 0;

    private GameObject player;
    private float transitionStart;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
      if (isHome == 1)
      {
        var transitionProgress = (Time.time - transitionStart) / transitionDuration;
        panel.alpha = Mathf.Lerp(
          0f, 
          1f,
          transitionProgress
        );

        var transitionEnd = transitionStart + transitionDuration;
        if ( Time.time > transitionEnd)
        {
          SceneManager.LoadScene("CreditsScene");
        }
      }
      else
      {
        var distanceFromHome = Vector3.Distance(transform.position, player.transform.position);
        if (distanceFromHome < goalDistance)
        {
          isHome = 1;
          transitionStart = Time.time;
        }
      }
    }
}

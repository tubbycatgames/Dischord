using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    public float transitionDuration = 5;
    public float goalDistance = 3;
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
      var distanceFromHome = Vector3.Distance(transform.position, player.transform.position);
      Debug.Log(distanceFromHome);

      if (isHome == 1)
      {
        if (transitionStart + transitionDuration > Time.deltaTime)
        {
          SceneManager.LoadScene("CreditsScene");
        }

      }
      else
      {
        if (distanceFromHome < goalDistance)
        {
          isHome = 1;
          transitionStart = Time.deltaTime;
        }
      }

      Debug.Log(isHome);

      // scene transitions can be found in emergency ejector

    }
}

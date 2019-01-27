using UnityEngine;
using UnityEngine.SceneManagement;

class EmergencyEjector : MonoBehaviour
{
    private int rCount;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rCount++;
            if (rCount == 3)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}

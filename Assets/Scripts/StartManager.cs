using UnityEngine;
using UnityEngine.SceneManagement;

class StartManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

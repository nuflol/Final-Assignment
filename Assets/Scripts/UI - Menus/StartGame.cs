using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public void StartTheGame(string stageToPlay) {
        if (Time.timeScale <= 0f) {
            Time.timeScale = 1f;
        }
        
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
    }
}

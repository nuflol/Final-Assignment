using UnityEngine;

public class CharacterGameOver : MonoBehaviour {
    [SerializeField] private GameObject weaponParent;
    public GameObject gameOverPanel;

    public void GameOver() {
        Debug.Log("gameover!");
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
    }
}

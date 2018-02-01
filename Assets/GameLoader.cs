using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {
    public GameObject playButton, loadingText;

    public void LoadGame() {
        playButton.SetActive(false);
        loadingText.SetActive(true);
        SceneManager.LoadSceneAsync("ShipGeneratorScene");
    }
}

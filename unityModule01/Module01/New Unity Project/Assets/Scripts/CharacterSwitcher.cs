using TMPro;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters;
    public TextMeshProUGUI activePlayerLabel;
    private int activeCharacterIndex = 0;
    private Renderer playerRenderer;

    void Start()
    {
        ActiveCharacter(0);
        string playerName = characters[0].name;
        FindObjectOfType<UIManager>().UpdateActivePlayer(playerName);
        playerRenderer = characters[0].GetComponent<Renderer>();
        activePlayerLabel.transform.position = new Vector3(0, 2.0f, 0);
        activePlayerLabel.text = playerName;
        activePlayerLabel.color = playerRenderer.material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ActiveCharacter(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ActiveCharacter(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ActiveCharacter(2);

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        UpdateCamera();
    }

    void ActiveCharacter(int index)
    {
        foreach (GameObject character in characters)
        {
            character.GetComponent<PlayerController>().enabled = false;
        }

        characters[index].GetComponent<PlayerController>().enabled = true;
        string playerName = characters[index].name;
        activeCharacterIndex = index;
        FindObjectOfType<UIManager>().UpdateActivePlayer(playerName);
        activePlayerLabel.text = playerName;
        playerRenderer = characters[index].GetComponent<Renderer>();
        activePlayerLabel.color = playerRenderer.material.color;
    }

    void UpdateCamera()
    {
        Camera.main.transform.position = characters[activeCharacterIndex].transform.position + new Vector3(0, 2, -10);
        Camera.main.transform.LookAt(characters[activeCharacterIndex].transform.position);
    }

    
}

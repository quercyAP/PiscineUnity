using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characters;
    private int activeCharacterIndex = 0;

    void Start()
    {
        ActiveCharacter(0);
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
        activeCharacterIndex = index;
    }

    void UpdateCamera()
    {
        Camera.main.transform.position = characters[activeCharacterIndex].transform.position + new Vector3(0, 2, -10);
        Camera.main.transform.LookAt(characters[activeCharacterIndex].transform.position);
    }
}

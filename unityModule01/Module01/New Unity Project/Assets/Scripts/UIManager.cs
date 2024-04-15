using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private Label activePlayerLabel;
    private Label controlsLabel;

    void OnEnable()
    {
        // Charger le document UI
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        // Accéder aux éléments par leur nom
        activePlayerLabel = root.Q<Label>("ActivePlayerLabel");
        controlsLabel = root.Q<Label>("ControlsLabel");

        // Initialiser le texte des commandes
        controlsLabel.text = "Commandes : A/D pour bouger, ESPACE pour sauter, 1/2/3 pour changer de joueur";
    }

    // Méthode pour mettre à jour le joueur actif
    public void UpdateActivePlayer(string playerName)
    {
        activePlayerLabel.text = "Joueur actif : " + playerName;
    }
}

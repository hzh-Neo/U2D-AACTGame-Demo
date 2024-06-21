using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiManager : MonoBehaviour
{
    public Canvas gameCanvas;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI healthMeshPro;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharactersEvents.characterDamage += onCharacterDamage;
        CharactersEvents.characterHealth += onCharacterHealth;
    }

    private void OnDisable()
    {
        CharactersEvents.characterDamage -= onCharacterDamage;
        CharactersEvents.characterHealth -= onCharacterHealth;
    }

    private void onCharacterDamage(GameObject character,float damage)
    {
       Vector3 position=Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text text = Instantiate(textMeshPro,position,Quaternion.identity,gameCanvas.transform).GetComponent<TMP_Text>();
        text.text=damage.ToString();


    }

    private void onCharacterHealth(GameObject character, float health)
    {
        Vector3 position = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text text = Instantiate(healthMeshPro, position, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();
        text.text = health.ToString();
    }

    private void onExitGame(InputAction.CallbackContext context)
    {

    }
}

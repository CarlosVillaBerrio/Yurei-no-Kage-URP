using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public TextMeshProUGUI text;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(SceneTrigger());
        }
    }

    IEnumerator SceneTrigger()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}

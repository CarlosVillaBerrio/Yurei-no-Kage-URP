using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{

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
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI text;  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //StartCoroutine(SceneTrigger());
            SceneManager.LoadScene("Final Scene");
        }
    }


    //IEnumerator SceneTrigger()
    //{
    //    text.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(3f);
    //    SceneManager.LoadScene("MainMenu");
    //}
}

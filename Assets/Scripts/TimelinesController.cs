using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinesController : MonoBehaviour
{
    private SceneController sceneManager;
    public string nextSceneName;
    public PlayableDirector playableDirector;

    private void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneController>();
        playableDirector.stopped += OnTimelineFinished;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                sceneManager.LoadNextScene(nextSceneName);
            }
    }    

    private void OnTimelineFinished(PlayableDirector director)
    {
        if (director == playableDirector)
        {
            sceneManager.LoadNextScene(nextSceneName);
        }
    }
}

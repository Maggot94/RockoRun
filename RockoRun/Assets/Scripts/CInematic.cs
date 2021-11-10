using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CInematic : MonoBehaviour
{
    private float Duration;
    // Start is called before the first frame update
    void Awake()
    {
       Duration = (float)gameObject.GetComponent<VideoPlayer>().length;
       StartCoroutine(EndCinematic());
    }

    IEnumerator EndCinematic()
    {
        yield return new WaitForSeconds(Duration);
        SceneManager.LoadScene(1);
    }
}

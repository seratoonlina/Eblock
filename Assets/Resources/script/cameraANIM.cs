using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class cameraANIM : MonoBehaviour
{
    [SerializeField] float scoreRed;
    [SerializeField] float scoreBlue;
    public GameObject enableGAMEPAD;
    public GameObject players;
    public GameObject blue;
    public GameObject red;
    public GameObject draw;
    public GameObject greenBottom;
    public GameObject result;


    void Start()
    {
        enableGAMEPAD.SetActive(false);
        scoreBlue = PlayerPrefs.GetFloat("blueScore", 0f);
        scoreRed = PlayerPrefs.GetFloat("redScore", 0f);
        if (scoreRed > scoreBlue)
        {
            players.GetComponent<MeshRenderer>().materials[0].color = Color.red;
            players.GetComponent<MeshRenderer>().materials[1].color = Color.red;
        }
        if (scoreRed < scoreBlue)
        {
            players.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
            players.GetComponent<MeshRenderer>().materials[1].color = Color.blue;
        }
        if (scoreRed == scoreBlue)
        {
            players.GetComponent<MeshRenderer>().materials[0].color = Color.black;
            players.GetComponent<MeshRenderer>().materials[1].color = Color.black;
        }
    }
    
    
    public void startAnimationobject()
    {
        players.GetComponent<Animator>().SetTrigger("on");
        greenBottom.SetActive(true);
        greenBottom.GetComponent<Animator>().SetTrigger("on");
        if (scoreRed > scoreBlue)
        {
            red.SetActive(true);
            blue.SetActive(false);
            draw.SetActive(false);
            red.GetComponent<Animator>().SetTrigger("on");
            StartCoroutine(waitForShowLeaderboat());
        }
        else if (scoreRed < scoreBlue)
        {
            red.SetActive(false);
            blue.SetActive(true);
            draw.SetActive(false);
            blue.GetComponent<Animator>().SetTrigger("on");
            StartCoroutine(waitForShowLeaderboat());
        }
        else if(scoreRed == scoreBlue)
        {
            red.SetActive(false);
            blue.SetActive(false);
            draw.SetActive(true);
            draw.GetComponent<Animator>().SetTrigger("on");
            StartCoroutine(waitForShowLeaderboat());
        }
    }

    IEnumerator waitForShowLeaderboat()
    {
        yield return new WaitForSeconds(5f);
        result.SetActive(true);
    }

}

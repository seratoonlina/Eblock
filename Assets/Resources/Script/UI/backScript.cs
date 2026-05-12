using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class backScript : MonoBehaviour
{
    InputMenu menu;
    public GameObject backLoading;
    public bool OnBack;
    void OnEnable()
    {
        menu.Enable();
    }
    void Awake()
    {
        menu = new InputMenu();
        menu.Movement.Back.performed += ctx => OnBack = true;
        menu.Movement.Back.canceled += ctx => OnBack = false;
    }

    void Update()
    {
        if (OnBack)
        {
            backLoading.SetActive(true);
            backLoading.GetComponent<Animator>().SetTrigger("getBack");
            
        }
    }

    public void getbacknow()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        backLoading.SetActive(true);
    }
}

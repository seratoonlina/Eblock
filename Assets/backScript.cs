using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class backScript : MonoBehaviour
{
    InputMenu menu;
    bool OnBack;
    void Start()
    {
        
    }

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

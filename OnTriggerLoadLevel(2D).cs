using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadLevel(2D) : MonoBehaviour
{
    [SerializeField] private GameObject enterTextObject;
    [SerializeField] private string _levelToLoad;

    private void Start()
    {
        enterTextObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enterTextObject.SetActive(true);
            if (Input.GetButtonDown("Use"))
            {
                SceneManager.LoadScene(_levelToLoad);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enterTextObject.SetActive(false);
        }
    }
}
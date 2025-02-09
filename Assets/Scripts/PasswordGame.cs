using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class PasswordGame : MonoBehaviour
{

    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button submit;
    [SerializeField] private string password;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        submit.onClick.AddListener(CheckPassword);
    }

    private void CheckPassword()
    {
        if (passwordInput.text == password)
        {
            win();
        }
        else
        {
            StartCoroutine(lose());
        }
    }



    public void win()
    {
        passwordInput.text = "";
        Debug.Log("Winner");
    }

    public IEnumerator lose()
    {
        passwordInput.text = "WRONG PASSWORD!";
        yield return new WaitForSeconds(0.75f);
        passwordInput.text = "";
    }
}

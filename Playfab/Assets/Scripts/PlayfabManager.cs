using UnityEngine;
using UnityEngine.UI;

using PlayFab;
using PlayFab.ClientModels;
using System;


public class PlayfabManager : MonoBehaviour
{
    [SerializeField] private InputField inputName;
    [SerializeField] private Button buttonLogin;
    [SerializeField] private Text textStatus;
    [SerializeField] private Canvas canvas;

  
    private void Start()
    {
        canvas.enabled = true;
        inputName.text = "";
        buttonLogin.onClick.AddListener(InputCheck);
    }

    void InputCheck()
    {
        if(inputName.text != string.Empty)
        {
            Enter();
        }
        else
        {
            textStatus.text = "Informe o nome do jogador.";
        }
    }

    void Enter()
    {
        Login();
    }

    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSucess, OnLoginError);
    }

    private void OnLoginSucess(LoginResult result)
    {
        string msg = "Login sucess.";
        textStatus.text = msg;
        Debug.Log(msg);

        canvas.enabled = false;
    }

    private void OnLoginError(PlayFabError error)
    {
        string msg = "Login error.";
        textStatus.text = msg;
        Debug.Log(msg);
    }

    
}

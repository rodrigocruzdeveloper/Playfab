using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 6.0f;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * speed  * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        scoreManager.AddScore(10);
        scoreManager.UpdateScore();
    }

    // EXPLICAR COMO ENVIAR OS DADOS DO JOGO PARA O PLAYFAB

    public void DefNAme(string name)
    {
        // Cria uma requisição para atualizar o nome chave o playfab
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = name
        };

        // Enviando a requisição ao Playfab para atualizar o nome do jogador
        PlayFabClientAPI.UpdateUserTitleDisplayName(

            request,

            // Caso a atualização seja concluida, exibe no console o novo cadastro
            result => Debug.Log("Update name:" + result.DisplayName),

            // Caso ocorra algum erro
            error => Debug.Log("Error update name: " + error.GenerateErrorReport())

         );
    }

    void OnLoginSucess(LoginResult result)
    {
        Debug.Log("Login, sucess.");
    }

   


}

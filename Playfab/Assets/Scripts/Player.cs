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

}

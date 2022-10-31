using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float swarmerInterval, GameObject enemy)
    {
        yield return new WaitForSeconds(swarmerInterval);  //Qual o intervalo de spawn?
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f,1), Random.Range(-1f,1f),0), Quaternion.identity); 
        //Cria o inimigo novo numa posição determinada pelo Vetor
        StartCoroutine(spawnEnemy(swarmerInterval, enemy));    //Existe potencial para ser ilimitado


    }
}

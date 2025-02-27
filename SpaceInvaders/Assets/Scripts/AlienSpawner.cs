using UnityEngine;

//erweiterter Container
public class AlienSpawner : MonoBehaviour
{
    public int currentAliens;
    public bool isAlienWinning;

    //private float timer;
    //[SerializeField] private float maxTimer;

    //[SerializeField] private GameObject[] alien;
    //[SerializeField] private float[] chanceToSpawn;
    //[SerializeField] private int[] alienSpawnAmount;

    void Start()
    {
        //foreach(int amount in alienSpawnAmount)
        //{
        //    currentAliens += amount;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //Spawner();
    }

    //private void Spawner()
    //{
    //    if (timer >= maxTimer)
    //    {
    //        timer = 0;

    //        for(int i = 0; i < alienSpawnAmount.Length; i++) 
    //        {
    //            if (alienSpawnAmount[i] > 0 && Random.Range(0,1) < chanceToSpawn[i])
    //            {
    //                Instantiate(alien[i], transform.position, Quaternion.identity, transform);
    //                alienSpawnAmount[i]--;
    //                break;
    //            }
    //        }
    //    }
    //    timer += Time.deltaTime;
    //}
}
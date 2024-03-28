using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class ZombieFactory : Singleton<ZombieFactory>
{
    [SerializeField] private Zombie[] availableZombie;
    [SerializeField] private Player player;
    [SerializeField] private float waitTime = 180.0f;
    [SerializeField] private int startingZombies = 5;
    [SerializeField] private float minRange = 5.0f;
    [SerializeField] private float maxRange = 50.0f;

    private void Awake() {
        Assert.IsNotNull(availableZombie);
        Assert.IsNotNull(player);
    }


    void Start()
    {
        for(int i=0; i <startingZombies; i++) {
            InstantiateZombie();
        }
        StartCoroutine(GenerateZombie());
    }

    private IEnumerator GenerateZombie() {
        while(true) {
            InstantiateZombie();
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateZombie() {
        int index = Random.Range(0, availableZombie.Length);
        float x = player.transform.position.x + GenerateRange();
        float y = player.transform.position.y;
        float z = player.transform.position.z + GenerateRange();
        Instantiate(availableZombie[index], new Vector3(x,y,z), Quaternion.identity);
    }

    private float GenerateRange() {
        float randomNum = Random.Range(minRange, maxRange);
        bool isPositive = Random.Range(0, 10) < 5;
        return randomNum * (isPositive ? 1 : -1);
    }

}

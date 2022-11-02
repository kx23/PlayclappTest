using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private InputField DistanceIF;
    [SerializeField] private InputField SpeedIF;
    [SerializeField] private InputField CubeSpawnResetTimeIF;
    [SerializeField] private GameObject cubePrefab;

    private float distance;
    private float speed;
    private float cubeSpawnResetTime;
    

    private bool isActive = false;
    private List<GameObject> cubes = new List<GameObject>();
    private float spawnTimer;

    void Update()
    {
        if (isActive)
        {
            if (spawnTimer + cubeSpawnResetTime < Time.time)
            {
                SpawnCube();
            }
        }

    }
    private bool TrySetParameters()
    {
        if (!float.TryParse(DistanceIF.text, out distance))
        {
            Debug.Log("DistanceIF.text string was not valid yet, unable to parse float.");
        }        
        if (!float.TryParse(SpeedIF.text, out speed))
        {
            Debug.Log("SpeedIF.text string was not valid yet, unable to parse float.");
        }
        if (!float.TryParse(CubeSpawnResetTimeIF.text, out cubeSpawnResetTime))
        {
            Debug.Log("CubeSpawnResetTimeIF.text string was not valid yet, unable to parse float.");
        }

        if(distance<=0)
        {
            Debug.LogWarning("Entered a negative value for distance. Enter a positive value.");
            return false;
        }
        if (speed <= 0)
        {
            Debug.LogWarning("Entered a negative value for speed. Enter a positive value.");
            return false;
        }
        if (cubeSpawnResetTime <= 0)
        {
            Debug.LogWarning("Entered a negative value for cubeSpawnResetTime. Enter a positive value.");
            return false;
        }
        return true;
    }
    private void SpawnCube()
    {
        spawnTimer = Time.time;
        //var go =Instantiate(cubePrefab,transform.position,transform.rotation, gameObject.transform);
        var go =Instantiate(cubePrefab,transform.position,transform.rotation);
        Cube c = go.GetComponent<Cube>();
        cubes.Add(go);
        c.Speed = speed;
        c.Limit = transform.position.z+ distance;
    }
    public void StartSpawning()
    {
        if (TrySetParameters())
        {
            SpawnCube();
            isActive = true;
        }

    }
    private void DestroyAllCubes()
    {
        foreach (GameObject c in cubes)
        {
            Destroy(c);
        }
    }
    public void StopSpawning()
    {
        isActive = false;
        // if you want to destroy all cubes after stopping
        //DestroyAllCubes();
    }
}

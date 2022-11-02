using UnityEngine;
using UnityEngine.UI;

public class ResetUIValues : MonoBehaviour
{
    [SerializeField] private InputField DistanceIF;
    [SerializeField] private InputField SpeedIF;
    [SerializeField] private InputField CubeSpawnResetTimeIF;

    [SerializeField] private float defaultDistance;
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float defaultCubeSpawnResetTime;

    private void Start()
    {
        ResetValues();
    }
    public void ResetValues()
    {
        DistanceIF.text = defaultDistance.ToString();
        SpeedIF.text = defaultSpeed.ToString();
        CubeSpawnResetTimeIF.text = defaultCubeSpawnResetTime.ToString();
    }
}

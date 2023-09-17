using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject spike;

    public PlayerScript player;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float speedMultiplier;
    private float startDelay = 1;
    public float repeatDelay;

    private void Awake()
    {
        currentSpeed = minSpeed;
    }

    private void Start()
    {
        Invoke("SpawnSpike", startDelay);
    }

    public void SpawnSpike()
    {
        repeatDelay = Random.Range(0.7f, 2.0f);

        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;

        Invoke("SpawnSpike", repeatDelay);
    }

    private void Update()
    {
        if (currentSpeed < maxSpeed && player.isAlive == true && Time.timeScale == 1)
        {
            currentSpeed += speedMultiplier;
        }
    }
}

using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject spike;

    public PlayerScript player;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float speedMultiplier;

    private void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void GenerateNextSpikeWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
    }

    public void generateSpike()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    private void FixedUpdate()
    {
        if (currentSpeed < maxSpeed && player.isAlive == true)
        {
            currentSpeed += speedMultiplier;
        }
    }
}

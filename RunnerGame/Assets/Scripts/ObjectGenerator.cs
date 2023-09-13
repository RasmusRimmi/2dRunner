using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject spike;

    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    private void Awake()
    {
        currentSpeed = minSpeed;
        generateSpike();
    }

    public void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
    }

}

using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public ObjectGenerator spikeGenerator;

    private void Start()
    {
        spikeGenerator = FindObjectOfType<ObjectGenerator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * spikeGenerator.currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject);
        }
    }
}

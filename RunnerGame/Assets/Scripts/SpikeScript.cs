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
        transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLine"))
        {
            spikeGenerator.GenerateNextSpikeWithGap();
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject);
        }
    }
}

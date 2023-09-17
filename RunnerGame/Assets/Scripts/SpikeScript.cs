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
        if (collision.gameObject.CompareTag("NextLine"))
        {
            //spikeGenerator.canGenerateSpike = true;
            //spikeGenerator.GenerateNextSpikeWithGap();
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Destroy(this.gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}

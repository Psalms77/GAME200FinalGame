using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ObjectCollector : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;
    private int collectedObjects = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Object detected: " + hit.gameObject.name);
            CollectObject(hit.gameObject);
        }
    }

    private void CollectObject(GameObject collectedObject)
    {
        if (collectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collectSound);
        }

        collectedObject.SetActive(false);
        collectedObjects++;

        Debug.Log("Objects Collected: " + collectedObjects);
    }
}

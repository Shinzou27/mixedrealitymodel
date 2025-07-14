using UnityEngine;

public class CrestDetector : MonoBehaviour {
  public GameObject maquete;
  private void OnCollisionEnter(Collision other)
  {

    if (other.gameObject.CompareTag("Crest"))
    {
      Vector3 spawnPoint = Utils.GetTopCenter(gameObject);
      Instantiate(maquete, spawnPoint, Quaternion.identity);
    }
  }
}
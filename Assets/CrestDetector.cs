using UnityEngine;
using UnityEngine.InputSystem;

public class CrestDetector : MonoBehaviour
{
  public GameObject maquete;
  public InputActionReference triggerSpawn;
  private void OnCollisionEnter(Collision other)
  {

    if (other.gameObject.CompareTag("Crest"))
    {
      Vector3 spawnPoint = Utils.GetTopCenter(gameObject);
      Instantiate(maquete, spawnPoint, Quaternion.identity);
    }
  }
  void Update()
  {
    if (triggerSpawn.action.WasPressedThisFrame())
    {
      Vector3 spawnPoint = Utils.GetTopCenter(gameObject);
      Instantiate(maquete, spawnPoint, Quaternion.identity);
    }
  }
}
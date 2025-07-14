using UnityEngine;
using UnityEngine.InputSystem;

public class CrestDetector : MonoBehaviour
{
  public GameObject maquete;
  public InputActionReference triggerSpawn;
  private GameObject instantiatedCity;
  private void OnCollisionEnter(Collision other)
  {

    if (other.gameObject.CompareTag("Crest"))
    {
      CreateCity(other.contacts[0].point);
    }
  }
  // void Update()
  // {
  //   if (triggerSpawn.action.WasPressedThisFrame())
  //   {
  //     CreateCity();
  //   }
  // }
  [ContextMenu("CreateCity")]
  public void CreateCity(Vector3 point)
  {
    if (instantiatedCity)
    {
      Destroy(instantiatedCity);
    }
    // Vector3 spawnPoint = Utils.GetTopCenter(gameObject);
    instantiatedCity = Instantiate(maquete, point, Quaternion.identity);
  }
}
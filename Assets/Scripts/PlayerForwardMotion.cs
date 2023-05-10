using UnityEngine;

public class PlayerForwardMotion : MonoBehaviour
{
  public float forward = 10f;
  public float sideways = 10f;
  public bool isMoving = false;
  public GameObject mainMenu;
  public GameObject winMenu;
  public GameObject lossMenu;

  void Update()
  {
    if (!isMoving)
    {
      if (mainMenu.activeInHierarchy == false && lossMenu.activeInHierarchy == false && winMenu.activeInHierarchy == false)
      {
        isMoving = true;
      }

      return;
    }

    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forward * Time.deltaTime);

    if (transform.position.x >= -2)
    {
      transform.position = new Vector3(transform.position.x - sideways * Time.deltaTime, transform.position.y, transform.position.z);
    }

    if (transform.position.x <= 2)
    {
      transform.position = new Vector3(transform.position.x + sideways * Time.deltaTime, transform.position.y, transform.position.z);
    }

  }
}

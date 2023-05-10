using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

  public GameObject character;
  public GameObject lossMenu;
  public GameObject winMenu;
  public TMP_Text scoreText;
  public Animator animator;

  private void OnTriggerEnter(Collider other)
  {

    if (other.tag == "CubeCreator")
    {
      other.enabled = false;
      AddCube(other);
    }

    if (other.tag == "Coin")
    {
      FindObjectOfType<GameManager>().coinCount++;
      Destroy(other.gameObject);

    }

    if (other.CompareTag("Finish"))
    {
      GameOver();
      if (gameObject.CompareTag("Player"))
      {
        animator.SetTrigger("win");
        winMenu.SetActive(true);
        scoreText.text = ("SCORE: " + (((int.Parse(other.name) - 1)) * FindObjectOfType<GameManager>().coinCount).ToString());
      }
      if (gameObject.tag == "Cube")
      {
        transform.parent.GetComponent<PlayerController>().animator.SetTrigger("win");
        transform.parent.GetComponent<PlayerController>().winMenu.SetActive(true);
        transform.parent.GetComponent<PlayerController>().scoreText.text = ("SCORE: " + (3 * FindObjectOfType<GameManager>().coinCount).ToString());
      }

    }

    if (gameObject.CompareTag("Player"))
    {
      if (other.CompareTag("Obstacle") || other.CompareTag("Lava"))
      {
        other.enabled = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<Rigidbody>().useGravity = false;
        GameOver();
        animator.SetTrigger("loss");
        lossMenu.SetActive(true);

      }
      if (other.tag == "Multiplier")
      {
        GameOver();
        winMenu.SetActive(true);
        if (int.Parse(other.name) - 1 == 0)
        {
          scoreText.text = "SCORE: " + FindObjectOfType<GameManager>().coinCount.ToString();
        }
        else
        {
          scoreText.text = ("SCORE: " + ((int.Parse(other.name) - 1) * FindObjectOfType<GameManager>().coinCount).ToString());
        }
      }

    }
  }


  private void AddCube(Collider other)
  {

    for (int i = 0; i < other.transform.childCount; i++)
    {
      other.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
      other.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
      if (transform.tag == "Player")
      {
        ChooseTransform(other, i, transform);
      }
      else
      {
        ChooseTransform(other, i, transform.parent);
      }
    }

    Destroy(other.gameObject);

  }

  private void ChooseTransform(Collider other, int i, Transform tsfm)
  {
    var childCube = Instantiate(other.transform.GetChild(i).gameObject, transform.position, Quaternion.identity, tsfm);
    tsfm.position = new Vector3(tsfm.position.x, tsfm.position.y + 1, tsfm.position.z);
    childCube.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
  }

  public void GameOver()
  {
    FindObjectOfType<PlayerForwardMotion>().isMoving = false;
    FindObjectOfType<GameManager>().coinCounter.SetActive(false);
  }

}



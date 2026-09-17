using UnityEngine;
using UnityEngine.SceneManagement;

namespace DS.GUI
{
    public class LoseButton : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }   
}

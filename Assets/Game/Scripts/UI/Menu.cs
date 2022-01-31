using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardSorting.UI
{
    public class Menu:MonoBehaviour
    {
        public LoadingAnimationScreen loadingAnimationScreen;
        
        public void LoadButton()
        {
            //Start loading the Scene asynchronously and output the progress bar
            StartCoroutine(LoadScene());
            loadingAnimationScreen.Close();
        }

        IEnumerator LoadScene()
        {
            yield return null;

            //Begin to load the Scene you specify
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game");
            //Don't let the Scene activate until you allow it to
            asyncOperation.allowSceneActivation = false;
            Debug.Log("Pro :" + asyncOperation.progress);
            //When the load is still in progress, output the Text and progress bar
            while (!asyncOperation.isDone)
            {
                //Output the current progress
                string text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

                // Check if the load has finished
                if (asyncOperation.progress >= 0.9f)
                {
                    //Change the Text to show the Scene is ready
                    text = "Press the space bar to continue";
                    if (!loadingAnimationScreen.isAnimating)
                        //Activate the Scene
                        asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
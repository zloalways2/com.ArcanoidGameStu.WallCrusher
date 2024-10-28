using System.Collections;
using UnityEngine;

public class LoadingScreenManager3 : MonoBehaviour
{
  [SerializeField] private GameObject _loadingScreenCanvas3; 

  void Start()
  {
    void NewFunction3()
    {
      StartCoroutine(HideLoadingScreenAfterDelay3(1.5f));
    }

    NewFunction3();
  }

  private IEnumerator HideLoadingScreenAfterDelay3(float delay)
  {
    void NewFunction3(CanvasGroup canvasGroup, float endAlpha3)
    {
      canvasGroup.alpha = endAlpha3;
      _loadingScreenCanvas3.SetActive(false);
    }

    yield return new WaitForSeconds(delay);  

    CanvasGroup canvasGroup3 = _loadingScreenCanvas3.GetComponent<CanvasGroup>();
    if (canvasGroup3 != null)
    {
      float startAlpha3 = canvasGroup3.alpha;
      float endAlpha3 = 0f;
      float fadeDuration3 = 1f;
      float elapsedFadeTime3 = 0f;

      while (elapsedFadeTime3 < fadeDuration3)
      {
        elapsedFadeTime3 += Time.deltaTime;
        canvasGroup3.alpha = Mathf.Lerp(startAlpha3, endAlpha3, elapsedFadeTime3 / fadeDuration3);
        yield return null;
      }

      NewFunction3(canvasGroup3, endAlpha3);
    }
  }
}
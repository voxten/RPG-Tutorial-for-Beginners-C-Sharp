using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour 
{
	[SerializeField] private Animator animator;
	private int _levelToLoad;

	private void Update()
	{	
		if (Input.GetMouseButtonDown(0))
		{
			FadeToLevel(1);       
		}
	}
	
	public void FadeToLevel(int _levelIndex)
	{
		_levelToLoad = _levelIndex;
		animator.SetTrigger("FadeOut"); 
	}
	
	public void OnFadeComplete()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}

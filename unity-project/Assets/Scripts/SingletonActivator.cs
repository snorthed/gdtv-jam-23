using UnityEngine;

namespace DefaultNamespace
{
	public class SingletonRepoActivator : MonoBehaviour
	{
		private void Awake()
		{
			var test = SingletonRepo.Instance;
		}
	}

}
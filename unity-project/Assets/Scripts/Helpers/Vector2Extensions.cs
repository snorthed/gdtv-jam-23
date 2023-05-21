using UnityEngine;

namespace Helpers
{
	public static class Vector2Extensions
	{
		public static Vector3 ToVector3TopDown(this Vector2 vec)
		{
			return new Vector3(vec.x, 0f, vec.y);
		}
	}
}
using UnityEngine;

namespace Helpers
{
	public static class Vector2Extensions
	{
		public static Vector3 ToVector3TopDown(this Vector2 vec, float yValue = 0f)
		{
			return new Vector3(vec.x, yValue, vec.y);
		}

		public static Vector2 ToVector2TopDown(this Vector3 vec) => new Vector2(vec.x, vec.z);
	}
}
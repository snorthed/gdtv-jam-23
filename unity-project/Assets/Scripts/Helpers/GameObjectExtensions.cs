using System;
using UnityEngine;

namespace Helpers
{
	public static class GameObjectExtensions
	{
		public static bool CanSeeTarget(this Transform self,
										Transform target,
										float visableDistance,
										float viewAngle,
										LayerMask rayMask,
										Type targetType, bool debug = false)
		{
			var selfPos = self.position;
			var targetPos = target.position;
			if (debug)
			{
				Debug.DrawRay(selfPos, (targetPos - selfPos).normalized * visableDistance, Color.red, 0.5f);
				var forward = self.forward;
				Debug.DrawRay(selfPos, forward *  visableDistance, Color.blue, 0.5f);
				Debug.DrawRay(selfPos, (Quaternion.Euler(0,viewAngle/2,0) * forward).normalized * visableDistance, Color.black, 2f);
				Debug.DrawRay(selfPos, (Quaternion.Euler(0,-viewAngle/2,0) * forward).normalized * visableDistance, Color.black, 2f);

			}

			var distance = Vector3.Distance(selfPos, targetPos);
			if (distance > visableDistance) return false;
			var dirToTarget = (targetPos - selfPos).normalized;


			if (Vector3.Angle(self.forward, dirToTarget) > viewAngle / 2) return false;
			
			var rayHit = Physics.Raycast(selfPos, dirToTarget, out var raycastHit, visableDistance, rayMask);
			var result = rayHit && raycastHit.collider.TryGetComponent(targetType, out _);
			if (result && debug)
			{
				Debug.Log("We See Something!");
			}

			return result;
		}

		public static bool CanSeeTarget(this GameObject self,
										GameObject target,
										float visableDistance,
										float viewAngle,
										LayerMask rayMask,
										Type targetType,
										bool debug = false) =>
			CanSeeTarget(self.transform, target.transform, visableDistance, viewAngle, rayMask, targetType, debug);

	}
}
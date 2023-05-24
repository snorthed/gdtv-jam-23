using System;
using UnityEngine;

namespace Helpers
{
	public static class GameObjectExtensions
	{
		public static bool CanSeeTarget(this Transform self,
										Transform target,
										float viableDistance,
										float viewAngle,
										LayerMask rayMask,
										Type targetType)
		{
			var selfPos = self.position;
			var targetPos = target.position;

			if (Vector3.Distance(selfPos, targetPos) > viableDistance) return false;

			var dirToTarget = (targetPos - selfPos).normalized;
			if (Vector3.Angle(self.forward, dirToTarget) > viewAngle / 2) return false;
			
			var rayHit = Physics.Raycast(selfPos, dirToTarget, out var raycastHit, viableDistance, rayMask);
			return rayHit && raycastHit.collider.TryGetComponent(targetType, out _);
		}

		public static bool CanSeeTarget(this GameObject self,
										GameObject target,
										float viableDistance,
										float viewAngle,
										LayerMask rayMask,
										Type targetType) =>
			CanSeeTarget(self.transform, target.transform, viableDistance, viewAngle, rayMask, targetType);

	}
}
using System;

namespace CommonComponents.Interfaces
{
	public interface IHealth
	{
		float MaxHP { get; }
		float CurrentHP { get; }

		event HPChanged HPChanged;
		event Death HPEmpty;
    }

	public delegate void HPChanged(float changeBy, float newHP) ;
	public delegate void Death();
}
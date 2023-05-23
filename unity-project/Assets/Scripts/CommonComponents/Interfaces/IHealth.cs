using System;

namespace CommonComponents.Interfaces
{
	public interface IHealth
	{
		float MaxHP { get; }
		float CurrentHP { get; }

		event HPChanged DamageTaken;
        event Action HPEmpty;
    }

	public delegate void HPChanged(float changeBy, float newHP) ;
}
namespace CommonComponents.Interfaces
{
	public interface IHealth
	{
		int MaxHP { get; }
		int CurrentHP { get; }

        DamageTaken OnDamageTaken { get; set; }
	}

	public delegate void DamageTaken(int amount) ;
}
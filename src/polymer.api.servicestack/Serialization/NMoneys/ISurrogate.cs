using NMoneys;

namespace polymer.api.servicestack.Serialization.NMoneys
{
	internal interface ISurrogate
	{
		decimal Amount { get; set; }
		Money ToMoney();
	}
}
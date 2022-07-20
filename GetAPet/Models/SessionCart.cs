namespace GetAPet.Models;

using System.Text.Json.Serialization;
using Infrastructure;

public class SessionCart : DonationCart
{
	public static DonationCart GetCart(IServiceProvider services)
	{
		ISession? session = services.GetRequiredService<IHttpContextAccessor>()
		                            .HttpContext?.Session;
		SessionCart cart = session?.GetJson<SessionCart>( "Cart" )
		                ?? new();
		cart.Session = session;
		return cart;
	}
	
	[JsonIgnore]
	public ISession? Session { get; set; }

	public override void AddItem(Pet pet)
	{
		base.AddItem(pet);
		Session?.SetJson( "Cart", this );
	}

	public override void RemoveLine(Pet pet)
	{
		base.RemoveLine(pet);
		Session?.SetJson( "Cart", this );
	}

	public override void Clear()
	{
		base.Clear();
		Session?.Remove( "Cart" );
	}
}
namespace PartyInvites.Models;

public static class Repository
{
	private static List<GuestResponse> responses { get; set; } = new();

	public static IEnumerable<GuestResponse> Responses => responses;

	public static void AddResponse(GuestResponse response)
	{
		Console.WriteLine(response);
		responses.Add(response);
	}
}
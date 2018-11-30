namespace AnimatedSpriteGenerator.GodotModels {
	public interface IExternalResource {
		int Id { get; }
		string Type { get; }
		string Path { get; }
	}
}
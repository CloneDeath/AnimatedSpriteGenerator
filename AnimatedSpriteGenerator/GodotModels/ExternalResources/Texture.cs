namespace AnimatedSpriteGenerator.GodotModels.ExternalResources {
	public class Texture : IExternalResource {
		public string Type => "Texture";
		public string Path { get; set; }
	}
}
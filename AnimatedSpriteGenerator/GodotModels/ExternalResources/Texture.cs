namespace AnimatedSpriteGenerator.GodotModels.ExternalResources {
	public class Texture : IExternalResource {
		public string Type => "Texture";
		
		public int Id { get; set; }
		public string Path { get; set; }
	}
}
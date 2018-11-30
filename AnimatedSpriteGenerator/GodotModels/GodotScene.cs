using System.Collections.Generic;

namespace AnimatedSpriteGenerator.GodotModels {
	public class GodotScene {
		public List<IExternalResource> ExternalResources { get; set; } = new List<IExternalResource>();
		public List<ISubResource> SubResources { get; set; } = new List<ISubResource>();
	}
}
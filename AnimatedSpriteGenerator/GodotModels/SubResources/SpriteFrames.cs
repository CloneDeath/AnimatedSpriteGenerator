using System;
using System.Collections.Generic;

namespace AnimatedSpriteGenerator.GodotModels.SubResources {
	public class SpriteFrames : ISubResource {
		public string Type => "SpriteFrames";
		
		public List<Animation> Animations { get; set; } = new List<Animation>();

		public class Animation {
			public List<IExternalResource> Frames { get; set; } = new List<IExternalResource>();
			public bool Loop { get; set; } = true;
			public string Name { get; set; } = Guid.NewGuid().ToString();
			public float Speed { get; set; } = 5.0f;
		}
	}
}
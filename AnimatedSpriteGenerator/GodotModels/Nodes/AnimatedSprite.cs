using AnimatedSpriteGenerator.GodotModels.SubResources;

namespace AnimatedSpriteGenerator.GodotModels.Nodes {
	public class AnimatedSprite : INode {
		public string Type => "AnimatedSprite";
		
		public string Name { get; set; } = "AnimatedSprite";
		public SpriteFrames Frames { get; set; } = new SpriteFrames();
		public SpriteFrames.Animation Animation { get; set; }
	}
}
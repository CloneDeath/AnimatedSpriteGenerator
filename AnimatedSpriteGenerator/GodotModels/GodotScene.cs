using System.Collections.Generic;

namespace AnimatedSpriteGenerator.GodotModels {
	public class GodotScene {
		public string Name { get; set; }
		public List<INode> Nodes { get; set; } = new List<INode>();
	}
}
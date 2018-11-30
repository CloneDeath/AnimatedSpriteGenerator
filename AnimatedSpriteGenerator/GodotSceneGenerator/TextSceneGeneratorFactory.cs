using System;
using System.Collections.Generic;
using System.Linq;
using AnimatedSpriteGenerator.GodotModels;
using AnimatedSpriteGenerator.GodotModels.Nodes;

namespace AnimatedSpriteGenerator.GodotSceneGenerator {
	public class TextSceneGeneratorFactory {
		private readonly List<INode> _nodes = new List<INode>();
		public IndexedResourceCollection<IExternalResource> ExternalResources { get; } = new IndexedResourceCollection<IExternalResource>();
		public IndexedResourceCollection<ISubResource> SubResources { get; } = new IndexedResourceCollection<ISubResource>();

		public TextSceneGeneratorFactory(GodotScene scene) {
			Load(scene);
		}

		private void Load(GodotScene scene) {
			foreach (var node in scene.Nodes) {
				Register(node);
			}
		}

		private void Register(INode node) {
			_nodes.Add(node);
			switch (node) {
				case AnimatedSprite animatedSprite: 
					Register(animatedSprite);
					return;
			}
			throw new NotImplementedException(node.Name);
		}

		private void Register(AnimatedSprite animatedSprite) {
			SubResources.Register(animatedSprite.Frames);
			foreach (var frame in animatedSprite.Frames.Animations.SelectMany(a => a.Frames)) {
				ExternalResources.Register(frame);
			}
		}

		public virtual int LoadSteps => NodeCount + SubResourceCount + ExternalResourceCount;
		protected virtual int NodeCount => _nodes.Count;
		protected virtual int SubResourceCount => SubResources.Count;
		protected virtual int ExternalResourceCount => ExternalResources.Count;
	}
}
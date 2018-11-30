using System;
using System.Collections.Generic;
using System.Linq;
using AnimatedSpriteGenerator.GodotModels;
using AnimatedSpriteGenerator.GodotModels.Nodes;
using AnimatedSpriteGenerator.GodotModels.SubResources;

namespace AnimatedSpriteGenerator.GodotSceneGenerator {
	public class TextSceneGenerator {
		protected readonly GodotScene Scene;
		protected readonly TextSceneGeneratorFactory Factory;

		public TextSceneGenerator(GodotScene scene) {
			Scene = scene;
			Factory = new TextSceneGeneratorFactory(Scene);
		}
		
		public string GetSceneContents() {
			return string.Join(
				Environment.NewLine + Environment.NewLine, 
				GetHeader(), 
				GetExternalResources(),
				GetSubResources(),
				GetNodes());
		}

		private string GetHeader() {
			return $"[gd_scene load_steps={Factory.LoadSteps} format=2]";
		}

		private string GetExternalResources() {
			return string.Join(Environment.NewLine, Factory.ExternalResources.Select(GetExternalResouce));
		}

		protected virtual string GetExternalResouce(IndexedResource<IExternalResource> res) {
			return $"[ext_resource path=\"{res.Resource.Path}\" type=\"{res.Resource.Type}\" id={res.Id}]";
		}

		private string GetSubResources() {
			return string.Join(Environment.NewLine, Factory.SubResources.Select(GetSubResource));
		}

		private string GetSubResource(IndexedResource<ISubResource> res) {
			return string.Join(Environment.NewLine,
				$"[sub_resource type=\"{res.Resource.Type}\" id={res.Id}]",
				GetSubResourceProperties(res));
		}

		private string GetSubResourceProperties(IndexedResource<ISubResource> res) {
			switch (res.Resource) {
				case SpriteFrames spriteFrames:
					return $"animations = {GetAnimations(spriteFrames.Animations)}";
			}

			throw new NotImplementedException();
		}

		private string GetAnimations(IEnumerable<SpriteFrames.Animation> animations) {
			return $"[{string.Join(", " + Environment.NewLine, animations.Select(GetAnimation))}]";
		}

		private string GetAnimation(SpriteFrames.Animation animation) {
			return "{"
			       + string.Join(", " + Environment.NewLine,
				       $"\"frames\" : {GetFrames(animation.Frames)}",
				       $"\"loop\" : {(animation.Loop ? "true" : "false")}",
				       $"\"name\" : \"{animation.Name}\"",
				       $"\"speed\" : {animation.Speed:F1}")
			       + "}";
		}

		private string GetFrames(IEnumerable<IExternalResource> animationFrames) {
			return string.Join(", ", animationFrames.Select(GetFrame));
		}

		private string GetFrame(IExternalResource frame) {
			return $"ExtResource( {Factory.ExternalResources.GetId(frame)} )";
		}

		private string GetNodes() {
			return string.Join(Environment.NewLine, Scene.Nodes.Select(GetNode));
		}

		private string GetNode(INode node) {
			return string.Join(Environment.NewLine,
				$"[node name=\"{node.Name}\" type=\"{node.Type}\"]",
				GetNodeDetails(node));
		}

		private string GetNodeDetails(INode node) {
			switch (node) {
				case AnimatedSprite animatedSprite:
					return string.Join(Environment.NewLine,
						$"frames = SubResource( {Factory.SubResources.GetId(animatedSprite.Frames)} )",
						$"animation = \"{animatedSprite.Animation.Name}\"");
			}
			throw new NotImplementedException();
		}
	}
}
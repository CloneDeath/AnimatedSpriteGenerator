using System.Collections.Generic;
using System.Linq;
using AnimatedSpriteGenerator.GodotModels;
using AnimatedSpriteGenerator.GodotModels.ExternalResources;
using AnimatedSpriteGenerator.GodotModels.Nodes;
using AnimatedSpriteGenerator.GodotModels.SubResources;

namespace AnimatedSpriteGenerator
{
    public class Program
    {
        public static void Main() {
            var scene = new GodotScene {
                Name = "Emote",
                Nodes = new List<INode>{GetRootNode()}
            };
        }

        protected static INode GetRootNode() {
            var node = new AnimatedSprite {
                Frames = GetEmoteFrames()
            };
            node.Animation = node.Frames.Animations.First();
            return node;
        }

        protected static SpriteFrames GetEmoteFrames() {
            var frames = new SpriteFrames();
            foreach (var type in new[] {"Pixel", "Vector"}) {
                for (var style = 1; style <= 8; style++) {
                    var contents = new[] {
                        "_", "alert", "anger", "bars", "cash", "circle", "cloud", "cross", "dots1",
                        "dots2", "dots3", "drop", "drops", "exclamation", "exclamations", "faceAngry", "faceHappy",
                        "faceSad", "heart", "heartBroken", "hearts", "idea", "laugh", "music", "question", "sleep",
                        "sleeps", "star", "stars", "swirl"
                    };

                    foreach (var content in contents) {
                        frames.Animations.Add(new SpriteFrames.Animation {
                            Speed = 1,
                            Loop = false,
                            Name = $"{type}_{style}_{content}",
                            Frames = new List<IExternalResource> {
                                new Texture {
                                    Path = $"res://{type}/Style {style}/emote_{content}.png"
                                }
                            }
                        });
                    }
                }
            }

            return frames;
        }
    }
}

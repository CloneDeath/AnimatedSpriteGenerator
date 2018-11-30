using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AnimatedSpriteGenerator.GodotSceneGenerator {
	public class IndexedResourceCollection<T> : IEnumerable<IndexedResource<T>> {
		private readonly List<IndexedResource<T>> _resources = new List<IndexedResource<T>>();
		
		public int Count => _resources.Count;

		public void Register(T resource) {
			if (IsRegistered(resource)) return;
			_resources.Add(new IndexedResource<T> {
				Id = GetNextId(),
				Resource = resource
			});
		}

		private bool IsRegistered(T resource) {
			return _resources.Select(r => r.Resource).Contains(resource);
		}

		private int GetNextId() {
			return _resources.Select(r => r.Id).Max() + 1;
		}

		public int GetId(T resource) {
			return _resources.First(r => r.Resource.Equals(resource)).Id;
		}

		#region IEnumerable<IndexedResource<T>>

		public IEnumerator<IndexedResource<T>> GetEnumerator() => _resources.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		#endregion
	}
}
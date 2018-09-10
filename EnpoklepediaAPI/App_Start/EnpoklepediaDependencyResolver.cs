using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace EnpoklepediaAPI
{
	public class EnpoklepediaDependencyResolver : EnpoklepediaOverrideDependency<IDependencyResolver>, IDependencyResolver
	{
		public EnpoklepediaDependencyResolver(IDependencyResolver inner)
			: base(inner, new Dictionary<Type, Func<object>>()) { }

		public EnpoklepediaDependencyResolver Add(Type serviceType, Func<object> initializer)
		{
			this.Provided.Add(serviceType, initializer);
			return this;
		}

		public IDependencyScope BeginScope() => new Scope(this.Inner.BeginScope(), this.Provided);

		public class Scope : EnpoklepediaOverrideDependency<IDependencyScope>, IDependencyScope
		{
			public Scope(IDependencyScope inner, IDictionary<Type, Func<object>> provided)
				: base(inner, provided) { }
		}
	}

	public abstract class EnpoklepediaOverrideDependency<T> : IDependencyScope where T : IDependencyScope
	{
		protected readonly T Inner;
		protected readonly IDictionary<Type, Func<object>> Provided;

		public EnpoklepediaOverrideDependency(T inner, IDictionary<Type, Func<object>> provided)
		{
			this.Inner = inner;
			this.Provided = provided;
		}

		public void Dispose() => this.Inner.Dispose();

		public object GetService(Type serviceType)
		{
			Func<object> res;
			return this.Provided.TryGetValue(serviceType, out res) ? res() : this.Inner.GetService(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			Func<object> res;
			return this.Inner.GetServices(serviceType).Concat(this.Provided.TryGetValue(serviceType, out res) ? new[] { res() } : Enumerable.Empty<object>());
		}
	}
}
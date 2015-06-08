﻿using System;
using System.Collections.Generic;

namespace Nest
{
	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IObservable<IReindexResponse<T>> Reindex<T>(Func<ReindexDescriptor<T>, ReindexDescriptor<T>> reindexSelector)
			where T : class
		{
			reindexSelector.ThrowIfNull("reindexSelector"); 
			var reindexDescriptor = reindexSelector(new ReindexDescriptor<T>());
			var observable = new ReindexObservable<T>(this, _connectionSettings, reindexDescriptor);
			return observable;
		}

		/// <inheritdoc />
		public IObservable<IReindexResponse<object>> Reindex(Func<ReindexDescriptor<object>, ReindexDescriptor<object>> reindexSelector)
		{
			return Reindex<object>(reindexSelector);
		}
	}
}
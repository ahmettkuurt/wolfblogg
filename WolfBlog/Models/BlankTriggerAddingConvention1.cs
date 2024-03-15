using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace sstoktakip.Models
{
	public class BlankTriggerAddingConvention1 : IModelFinalizingConvention
	{
		public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
		{
			foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
			{
				var table = StoreObjectIdentifier.Create(entityType, StoreObjectType.Table);
				if (table != null && entityType.GetDeclaredTriggers().All(t => t.GetDatabaseName(table.Value) == null))
				{
					entityType.Builder.HasTrigger(table.Value.Name + "AddScoreInComment");
				}
				foreach (var fragment in entityType.GetMappingFragments(StoreObjectType.Table))
				{
					if (entityType.GetDeclaredTriggers().All(a => a.GetDatabaseName(fragment.StoreObject) == null))
					{
						entityType.Builder.HasTrigger(fragment.StoreObject.Name + "AddScoreInComment");
					}
				}
			}
		}
	}
}

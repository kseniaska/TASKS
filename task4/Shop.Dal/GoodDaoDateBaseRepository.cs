namespace Shop.Dal;

public class GoodDaoDataBaseRepository: DatabaseRepositoryBase<GoodDao>
{
    public GoodDaoDataBaseRepository(ShopEntityContext context): base(context, context.Goods) {}
}
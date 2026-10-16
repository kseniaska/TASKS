namespace Shop.Dal;

public class ShopDaoDataBaseRepository : DatabaseRepositoryBase<ShopDao>
{
    public ShopDaoDataBaseRepository(ShopEntityContext context): base(context, context.Shops) {}
}
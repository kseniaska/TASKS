namespace Shop.Dal;

public class ClientDaoDataBaseRepository : DatabaseRepositoryBase<ClientDao>
{
    public ClientDaoDataBaseRepository(ShopEntityContext context): base(context, context.Clients) {}
}
using System.Collections.ObjectModel;

namespace Application.Permissions;

public static class PermissionAction
{
    public const string Create = nameof(Create);
    public const string Read = nameof(Read);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);

    public const string Export = nameof(Export);
    public const string Import = nameof(Import);
    public const string Use = nameof(Use);
}

public static class PermissionResource
{
    public const string SystemMethods = nameof(SystemMethods);
    public const string Agents = nameof(Agents);
    public const string Audit = nameof(Audit);
    public const string GoodsStocks = nameof(GoodsStocks);
    public const string Hubs = nameof(Hubs);
    public const string Owners = nameof(Owners);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Roles = nameof(Roles);
    public const string RoleTemplates = nameof(RoleTemplates);
    public const string RoleTemplateClaims = nameof(RoleTemplateClaims);
    public const string Tenants = nameof(Tenants);
    public const string Ttn = nameof(Ttn);
    public const string UserRoles = nameof(UserRoles);
    public const string Users = nameof(Users);
    public const string Warehouses = nameof(Warehouses);
    public const string Permissions = nameof(Permissions);
    public const string InventoryAct = nameof(InventoryAct);
    public const string InventoryScan = nameof(InventoryScan);
    public const string InventoryEan = nameof(InventoryScan);
}


public static class StoreWebPermissions
{
    private static readonly StoreWebPermission[] All =
    [
        new("Использовать возможности системного пользователя", PermissionAction.Use, PermissionResource.SystemMethods),

        new("Создание Пользователей", PermissionAction.Create, PermissionResource.Users),
        new("Просмотр Пользователей", PermissionAction.Read, PermissionResource.Users, IsBasic: true),
        new("Изменение Пользователей", PermissionAction.Update, PermissionResource.Users),
        new("Удаление Пользователей", PermissionAction.Delete, PermissionResource.Users),

        new("Изменение Ролей Рользователей", PermissionAction.Update, PermissionResource.UserRoles),

        new("Создание Ролей", PermissionAction.Create, PermissionResource.Roles),
        new("Просмотр Ролей", PermissionAction.Read, PermissionResource.Roles, IsBasic: true),
        new("Изменение Ролей", PermissionAction.Update, PermissionResource.Roles),
        new("Удаление Ролей", PermissionAction.Delete, PermissionResource.Roles),

        new("Создание Признаков Роли", PermissionAction.Create, PermissionResource.RoleClaims),
        new("Просмотр Признаков Роли", PermissionAction.Read, PermissionResource.RoleClaims, IsBasic: true),
        new("Изменение Признаков Роли", PermissionAction.Update, PermissionResource.RoleClaims),
        new("Удаление Признаков Роли", PermissionAction.Delete, PermissionResource.RoleClaims),

        new("Создание Складов", PermissionAction.Create, PermissionResource.Warehouses),
        new("Просмотр Складов", PermissionAction.Read, PermissionResource.Warehouses, IsBasic: true),
        new("Изменение Складов", PermissionAction.Update, PermissionResource.Warehouses),
        new("Удаление Складов", PermissionAction.Delete, PermissionResource.Warehouses),

        new("Создание Агентов", PermissionAction.Create, PermissionResource.Agents),
        new("Просмотр Агентов", PermissionAction.Read, PermissionResource.Agents, IsBasic: true),
        new("Изменение Агентов", PermissionAction.Update, PermissionResource.Agents),
        new("Удаление Агентов", PermissionAction.Delete, PermissionResource.Agents),

        new("Просмотр общего лога системы", PermissionAction.Read, PermissionResource.Audit, IsBasic: true),

        new("Создание Накладных", PermissionAction.Create, PermissionResource.Ttn, IsBasic: true),
        new("Просмотр Накладных", PermissionAction.Read, PermissionResource.Ttn, IsBasic: true),
        new("Изменение Накладных", PermissionAction.Update, PermissionResource.Ttn, IsBasic: true),
        new("Удаление Накладных", PermissionAction.Delete, PermissionResource.Ttn),

        new("Создание Товарных остатков", PermissionAction.Create, PermissionResource.GoodsStocks, IsBasic: true),
        new("Просмотр Товарных остатков", PermissionAction.Read, PermissionResource.GoodsStocks, IsBasic: true),
        new("Изменение Товарных остатков", PermissionAction.Update, PermissionResource.GoodsStocks, IsBasic: true),
        new("Удаление Товарных остатков", PermissionAction.Delete, PermissionResource.GoodsStocks),

        new("Создание Тенантов", PermissionAction.Create, PermissionResource.Tenants),
        new("Прсомотр Тенантов", PermissionAction.Read, PermissionResource.Tenants),
        new("Изменение Тенантов", PermissionAction.Update, PermissionResource.Tenants),
        new("Удаление Тенантов", PermissionAction.Delete, PermissionResource.Tenants),

        new("Создание Хабов", PermissionAction.Create, PermissionResource.Hubs),
        new("Просмотр Хабов", PermissionAction.Read, PermissionResource.Hubs),
        new("Изменение Хабов", PermissionAction.Update, PermissionResource.Hubs),
        new("Удаление Хабов", PermissionAction.Delete, PermissionResource.Hubs),

        new("Создание Овнеров", PermissionAction.Create, PermissionResource.Owners),
        new("Просмотр Овнеров", PermissionAction.Read, PermissionResource.Owners),
        new("Изменение Овнеров", PermissionAction.Update, PermissionResource.Owners),
        new("Удаление Овнеров", PermissionAction.Delete, PermissionResource.Owners),

        new("Создание Шаблонов ролей", PermissionAction.Create, PermissionResource.RoleTemplates),
        new("Просмотр Шаблонов ролей", PermissionAction.Read, PermissionResource.RoleTemplates),
        new("Изменение Шаблонов ролей", PermissionAction.Update, PermissionResource.RoleTemplates),
        new("Удаление Шаблонов ролей", PermissionAction.Delete, PermissionResource.RoleTemplates),

        new("Создание Признаков шаблонов ролей", PermissionAction.Create, PermissionResource.RoleTemplateClaims),
        new("Просмотр Признаков шаблонов ролей", PermissionAction.Read, PermissionResource.RoleTemplateClaims),
        new("Изменение Признаков шаблонов ролей", PermissionAction.Update, PermissionResource.RoleTemplateClaims),
        new("Удаление Признаков шаблонов ролей", PermissionAction.Delete, PermissionResource.RoleTemplateClaims),

        new("Просмотр Разрешений", PermissionAction.Read, PermissionResource.Permissions),

        new("Создание Инвентаризационных актов", PermissionAction.Create, PermissionResource.InventoryAct, IsBasic: true),
        new("Просмотр Инвентаризационных актов", PermissionAction.Read, PermissionResource.InventoryAct, IsBasic: true),
        new("Изменение Инвентаризационных актов", PermissionAction.Update, PermissionResource.InventoryAct, IsBasic: true),
        new("Удаление Инвентаризационных актов", PermissionAction.Delete, PermissionResource.InventoryAct),

        new("Создание Инвентаризационных сканов", PermissionAction.Create, PermissionResource.InventoryScan, IsBasic: true),
        new("Просмотр Инвентаризационных сканов", PermissionAction.Read, PermissionResource.InventoryScan, IsBasic: true),
        new("Изменение Инвентаризационных сканов", PermissionAction.Update, PermissionResource.InventoryScan, IsBasic: true),
        new("Удаление Инвентаризационных сканов", PermissionAction.Delete, PermissionResource.InventoryScan),

        new("Создание записей Ean", PermissionAction.Create, PermissionResource.InventoryEan, IsBasic: true),
        new("Просмотр записей Ean", PermissionAction.Read, PermissionResource.InventoryEan, IsBasic: true),
    ];

    /* Наборы разрешений для стандартных шаблонов ролей */
    public static IReadOnlyList<StoreWebPermission> FullAccess { get; } = new ReadOnlyCollection<StoreWebPermission>(All);
    public static IReadOnlyList<StoreWebPermission> Basic { get; } = new ReadOnlyCollection<StoreWebPermission>(All.Where(x => x.IsBasic).ToList());
    public static IReadOnlyList<StoreWebPermission> Cashier { get; } = new ReadOnlyCollection<StoreWebPermission>(All.Where(x => x.IsCashier).ToList());
}

public record StoreWebPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsCashier = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}
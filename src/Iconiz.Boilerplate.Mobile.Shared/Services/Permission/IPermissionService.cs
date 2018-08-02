namespace Iconiz.Boilerplate.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}
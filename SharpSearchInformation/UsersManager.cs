using SharpSearchInformation.Model;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace SharpSearchInformation
{
    internal class UsersManager
    {
        public List<UserModel> GetAllUsers()
        {
            List < UserModel > users = new List<UserModel>();
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                // Crear un objeto para realizar una búsqueda de usuarios
                using (UserPrincipal userPrincipal = new UserPrincipal(context))
                {
                    // Obtener todos los usuarios
                    using (PrincipalSearcher searcher = new PrincipalSearcher(userPrincipal))
                    {
                        foreach (var result in searcher.FindAll())
                        {
                            // Convertir el resultado a un objeto UserPrincipal
                            UserPrincipal user = result as UserPrincipal;

                            if (user != null)
                            {
                                users.Add(new UserModel()
                                {
                                    IsEnabled = user.Enabled.HasValue ? user.Enabled.Value : false,
                                    Name = user.Name,
                                    SID = user.Sid.Value
                                });
                            }
                        }
                    }
                }
            }

            return users;
        }
    }
}

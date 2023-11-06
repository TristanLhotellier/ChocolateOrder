using Models;

namespace ChocoProject.Core;

public interface InterfaceServiceAdmin
{
    /// <summary>
    /// Loads the list of administrators from the data source.
    /// </summary>
    /// <returns>True if the load was successful, otherwise false.</returns>
    bool LoadAdminList();

    /// <summary>
    /// Saves the list of administrators to the data source.
    /// </summary>
    /// <returns>True if the save was successful, otherwise false.</returns>
    bool SaveAdminList();

    /// <summary>
    /// Asks the administrator to make a choice among the available options.
    /// </summary>
    /// <returns>The administrator's choice as an integer.</returns>
    int AdminChoice();

    /// <summary>
    /// Handles the administrator's menu.
    /// </summary>
    /// <returns>True if the administrator has left the menu, otherwise false.</returns>
    bool AdminMenu();

    /// <summary>
    /// Creates a new administrator by asking for information from the user.
    /// If the administrator already exists, retrieves it, otherwise adds it to the list.
    /// </summary>
    /// <returns>True if the administrator already exists, otherwise false.</returns>
    bool formAdmin();

    /// <summary>
    /// Searches for an administrator by password and login.
    /// </summary>
    /// <param name="Password">The password of the administrator to search for.</param>
    /// <param name="Login">The login of the administrator to search for.</param>
    /// <returns>The administrator found or null if it does not exist.</returns>
    Administrator AdminFindByPasswordAndLogin(string Password, string Login);
}
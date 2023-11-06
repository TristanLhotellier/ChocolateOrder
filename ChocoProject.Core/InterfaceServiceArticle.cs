using Models;

namespace ChocoProject.Core;

/// <summary>
/// Interface for the article management service.
/// </summary>
public interface InterfaceServiceArticle
{
    /// <summary>
    /// Loads the list of articles from a data source.
    /// </summary>
    /// <returns>True if the load was successful, otherwise false.</returns>
    bool LoadArticleList();

    /// <summary>
    /// Saves the list of articles to a data source.
    /// </summary>
    /// <returns>True if the save was successful, otherwise false.</returns>
    bool SaveArticleList();

    /// <summary>
    /// Allows to create a new article and adds it to the list of articles if possible.
    /// </summary>
    /// <returns>True if the article was added, otherwise false.</returns>
    bool formArticle();

    /// <summary>
    /// Searches for an article by its reference.
    /// </summary>
    /// <param name="Reference">The reference of the article to search for.</param>
    /// <returns>The article found or null if it does not exist.</returns>
    Article FindArticleByReference(string Reference);

    /// <summary>
    /// Converts the list of articles to a string representation.
    /// </summary>
    /// <returns>The string representation of the list of articles.</returns>
    string ArticleListToString();
}
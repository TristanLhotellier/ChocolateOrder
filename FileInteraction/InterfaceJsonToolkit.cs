using Models;

namespace FileInteraction;

public interface InterfaceJsonToolkit
{
    /// <summary>
    /// Deserializes a JSON file into a list of User objects.
    /// </summary>
    /// <param name="filepath">The path to the JSON file to deserialize.</param>
    /// <returns>The list of User objects resulting from the deserialization.</returns>
        List<Buyer> Deserialize(string filepath);

    /// <summary>
    /// Serializes a list of User objects into a JSON string.
    /// </summary>
    /// <param name="json">The list of User objects to serialize.</param>
    /// <returns>The JSON string resulting from the serialization.</returns>
        string Serialize(List<Buyer> json);

    /// <summary>
    /// Deserializes a JSON file into a list of Administrator objects.
    /// </summary>
    /// <param name="filepath">The path to the JSON file to deserialize.</param>
    /// <returns>The list of Administrator objects resulting from the deserialization.</returns>
        List<Administrator> DeserializeAdministrator(string filepath);

    /// <summary>
    /// Serializes a list of Administrator objects into a JSON string.
    /// </summary>
    /// <param name="json">The list of Administrator objects to serialize.</param>
    /// <returns>The JSON string resulting from the serialization.</returns>
        string SerializeAdministrator(List<Administrator> json);

    /// <summary>
    /// Deserializes a JSON file into a list of Article objects.
    /// </summary>
    /// <param name="filepath">The path to the JSON file to deserialize.</param>
    /// <returns>The list of Article objects resulting from the deserialization.</returns>
        List<Article> DeserializeArticles(string filepath);

    /// <summary>
    /// Serializes a list of Article objects into a JSON string.
    /// </summary>
    /// <param name="json">The list of Article objects to serialize.</param>
    /// <returns>The JSON string resulting from the serialization.</returns>
        string SerializeArticles(List<Article> json);

    /// <summary>
    /// Deserializes a JSON file into a list of ItemsPurchased objects.
    /// </summary>
    /// <param name="filepath">The path to the JSON file to deserialize.</param>
    /// <returns>The list of ItemsPurchased objects resulting from the deserialization.</returns>
        List<PurchasedArticle> DeserializeItemsPurchased(string filepath);

    /// <summary>
    /// Serializes a list of ItemsPurchased objects into a JSON string.
    /// </summary>
    /// <param name="json">The list of ItemsPurchased objects to serialize.</param>
    /// <returns>The JSON string resulting from the serialization.</returns>
        string SerializeItemsPurchased(List<PurchasedArticle> json);

    }
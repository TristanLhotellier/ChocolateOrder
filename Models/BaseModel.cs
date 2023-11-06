using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    /// <summary>
    /// Represents a base model for other models in the application.
    /// </summary>
    public class BaseModel 
    {
        /// <summary>
        /// Gets or sets the unique identifier for the model.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        
    }
}
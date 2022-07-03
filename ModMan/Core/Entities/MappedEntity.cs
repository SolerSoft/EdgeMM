namespace ModMan.Core.Entities
{
    /// <summary>
    /// Base class for an observable object that wraps backing data.
    /// </summary>
    /// <typeparam name="TData">
    /// The backing data type.
    /// </typeparam>
    public abstract class MappedEntity<TData> : Entity
    {
        #region Private Fields

        private readonly TData data;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new MappedEntity with the specified backing data.
        /// </summary>
        /// <param name="data">
        /// The backing data for the model.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="data" /> is null.
        /// </exception>
        public MappedEntity(TData data)
        {
            // Validate
            if (data == null) { throw new ArgumentNullException(nameof(data)); }

            // Store
            this.data = data;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the backing data.
        /// </summary>
        public TData Data => data;

        #endregion Public Properties
    }
}
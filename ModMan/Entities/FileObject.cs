using Microsoft.Toolkit.Mvvm.ComponentModel;
using IOPath = System.IO.Path;

namespace ModMan.Entities
{
    /// <summary>
    /// Base class for an object that is backed by a file.
    /// </summary>
    public abstract class FileObject : ObservableObject
    {
        #region Private Fields

        private string directory;
        private string fileName;
        private string path;

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        /// Updates the <see cref="Directory" /> and <see cref="FileName" /> properties based on the <see cref="Path" /> property.
        /// </summary>
        private void UpdatePathParts()
        {
            Directory = IOPath.GetDirectoryName(path);
            FileName = IOPath.GetFileName(path);
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        /// Called when the value of the <see cref="Path" /> property changes.
        /// </summary>
        protected virtual void OnPathChanged()
        {
        }

        #endregion Protected Methods

        #region Public Properties

        /// <summary>
        /// Gets the directory to where the object file can be found.
        /// </summary>
        /// <value>
        /// The directory where the object file can be found.
        /// </value>
        public string Directory
        {
            get { return directory; }
            private set { SetProperty(ref directory, value); }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get { return fileName; }
            private set { SetProperty(ref fileName, value); }
        }

        /// <summary>
        /// Gets or sets the system path to where the object file can be found.
        /// </summary>
        /// <value>
        /// The path to the object file.
        /// </value>
        public string Path
        {
            get { return path; }
            set
            {
                if (SetProperty(ref path, value))
                {
                    UpdatePathParts();
                    OnPathChanged();
                }
            }

            #endregion Public Properties
        }
    }

    /// <summary>
    /// Base class for an object that serializes data to a file.
    /// </summary>
    /// <typeparam name="TData">
    /// The backing data type.
    /// </typeparam>
    public abstract class FileObject<TData> : FileObject
    {
        #region Private Fields

        private readonly TData data;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="FileObject" /> with the specified backing data.
        /// </summary>
        /// <param name="data">
        /// The backing data for the model.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="data" /> is null.
        /// </exception>
        public FileObject(TData data)
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
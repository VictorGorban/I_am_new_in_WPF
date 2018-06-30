using System.Diagnostics.CodeAnalysis;

namespace Handy_Extensions
{
    /// <summary>
    /// Provides methods for right-sided class operations like right-sided cast, assignment, etc..
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class CastAndTo
    {
        #region Cast and To
        /// <summary>
        /// Right-sided conversion. Have deal with null.
        /// </summary>
        public static T Cast<T>(this object o)  => (T)o;

        /// <summary>
        /// Right-sided assignment. Have deal with null.
        /// </summary>
        public static T To<T>(this T o, out T x) => x = o;

        /// <summary>
        /// Right-sided cast/assignment. Have deal with null.
        /// </summary>
        public static T CastTo<T>(this object o, out T x) => x = (T)o;
        #endregion

        

    }

}

namespace System.Collections.Generic
{
    public static class SetExtensions
    {
        public static bool IsNullOrEmpty<T>(this ISet<T> @this)
        {
            return @this == null || @this.Count == 0;
        }
    }
}

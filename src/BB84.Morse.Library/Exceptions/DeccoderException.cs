namespace BB84.Morse.Library.Exceptions;

/// <summary>
/// The <see cref="DeccoderException"/> class.
/// </summary>
/// <inheritdoc/>
public sealed class DeccoderException(string paramName, string message) : ArgumentOutOfRangeException(paramName, message)
{ }

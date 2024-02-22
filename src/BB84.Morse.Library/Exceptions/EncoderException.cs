namespace BB84.Morse.Library.Exceptions;

/// <summary>
/// The <see cref="EncoderException"/> class.
/// </summary>
/// <inheritdoc/>
public sealed class EncoderException(string paramName, string message) : ArgumentOutOfRangeException(paramName, message)
{ }

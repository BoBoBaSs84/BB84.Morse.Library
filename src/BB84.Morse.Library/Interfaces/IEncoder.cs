using BB84.Morse.Library.Exceptions;

namespace BB84.Morse.Library.Interfaces;

/// <summary>
/// The morse code encoder interface.
/// </summary>
public interface IEncoder
{
	/// <summary>
	/// Decodes the given morse code <paramref name="message"/> bak into readable text.
	/// </summary>
	/// <remarks>
	/// If a letter can not be decoded, a <see cref="DeccoderException"/> will be thrown.
	/// </remarks>
	/// <param name="message">The message to decode.</param>
	/// <returns>The decoded message.</returns>
	/// <exception cref="DeccoderException"></exception>
	string Decode(string message);

	/// <summary>
	/// Encodes the given <paramref name="message"/> into morse code.
	/// </summary>
	/// <remarks>
	/// If a character can not be encoded, a <see cref="EncoderException"/> will be thrown.
	/// </remarks>
	/// <param name="message">The message to encode.</param>
	/// <returns>The encoded message.</returns>
	/// <exception cref="EncoderException"></exception>
	string Encode(string message);
}

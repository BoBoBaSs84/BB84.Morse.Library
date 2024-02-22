using BB84.Morse.Library.Exceptions;
using BB84.Morse.Library.Interfaces;

namespace BB84.Morse.Library;

/// <summary>
/// The morse code encoder class.
/// </summary>
public sealed class Encoder : IEncoder
{
	private static readonly Lazy<Encoder> LazyEncoder = new(() => new());
	private static readonly Dictionary<char, string> EncodeDictionary = new()
	{
		{'A', ".-"},
		{'B', "-..."},
		{'C', "-.-."},
		{'D', "-.."},
		{'E', "."},
		{'F', "..-."},
		{'G', "--."},
		{'H', "...."},
		{'I', ".."},
		{'J', ".---"},
		{'K', "-.-"},
		{'L', ".-.."},
		{'M', "--"},
		{'N', "-."},
		{'O', "---"},
		{'P', ".--."},
		{'Q', "--.-"},
		{'R', ".-."},
		{'S', "..."},
		{'T', "-"},
		{'U', "..-"},
		{'V', "...-"},
		{'W', ".--"},
		{'X', "-..-"},
		{'Y', "-.--"},
		{'Z', "--.."},
		{'0', "-----"},
		{'1', ".----"},
		{'2', "..---"},
		{'3', "...--"},
		{'4', "....-"},
		{'5', "....."},
		{'6', "-...."},
		{'7', "--..."},
		{'8', "---.."},
		{'9', "----."},
		{'.', ".-.-.-"},
		{',', "--..--"},
		{'?', "..--.."},
		{'\'', ".----."},
		{'!', "-.-.--"},
		{'/', "-..-."},
		{'(', "-.--."},
		{')', "-.--.-"},
		{'&', ".-..."},
		{':', "---..."},
		{';', "-.-.-."},
		{'=', "-...-"},
		{'+', ".-.-."},
		{'-', "-....-"},
		{'_', "..--.-"},
		{'\"', ".-..-."},
		{'$', "...-..-"},
		{'@', ".--.-."},
		{' ', "/"}
	};
	private static readonly Dictionary<string, char> DecodeDictionary = new()
	{
		{".-", 'A'},
		{"-...", 'B'},
		{"-.-.", 'C'},
		{"-..", 'D'},
		{".", 'E'},
		{"..-.", 'F'},
		{"--.", 'G'},
		{"....", 'H'},
		{"..", 'I'},
		{".---", 'J'},
		{"-.-", 'K'},
		{".-..", 'L'},
		{"--", 'M'},
		{"-.", 'N'},
		{"---", 'O'},
		{".--.", 'P'},
		{"--.-", 'Q'},
		{".-.", 'R'},
		{"...", 'S'},
		{"-", 'T'},
		{"..-", 'U'},
		{"...-", 'V'},
		{".--", 'W'},
		{"-..-", 'X'},
		{"-.--", 'Y'},
		{"--..", 'Z'},
		{"-----", '0'},
		{".----", '1'},
		{"..---", '2'},
		{"...--", '3'},
		{"....-", '4'},
		{".....", '5'},
		{"-....", '6'},
		{"--...", '7'},
		{"---..", '8'},
		{"----.", '9'},
		{".-.-.-", '.'},
		{"--..--", ','},
		{"..--..", '?'},
		{".----.", '\''},
		{"-.-.--", '!'},
		{"-..-.", '/'},
		{"-.--.", '('},
		{"-.--.-", ')'},
		{".-...", '&'},
		{"---...", ':'},
		{"-.-.-.", ';'},
		{"-...-", '='},
		{".-.-.", '+'},
		{"-....-", '-'},
		{"..--.-", '_'},
		{".-..-.", '\"'},
		{"...-..-", '$'},
		{".--.-.", '@'},
		{"/", ' '}
	};

	/// <summary>
	/// Initializes a new instance of the <see cref="Encoder"/> class.
	/// </summary>
	private Encoder()
	{ }

	/// <summary>
	/// The morse code encoder singleton instance.
	/// </summary>
	public static IEncoder Instance => LazyEncoder.Value;

	/// <inheritdoc/>
	/// <exception cref="EncoderException"></exception>
	public string Encode(string message)
	{
		message = message.ToUpperInvariant();
		string encodedMessage = string.Empty;

		foreach (char character in message)
		{
			if (EncodeDictionary.TryGetValue(character, out string value))
				encodedMessage += string.Concat(value, " ");
			else
				throw new EncoderException(nameof(message), $"'{character}' is not a valid character to encode.");
		}
		return encodedMessage.Trim();
	}

	/// <inheritdoc/>
	/// <exception cref="DeccoderException"></exception>
	public string Decode(string message)
	{
		string[] words = message.Split('/').Select(x => x.Trim()).ToArray();
		string decodedMessage = string.Empty;

		foreach (string word in words)
		{
			string[] letters = word.Split(' ');
			foreach (string letter in letters)
			{
				if (DecodeDictionary.TryGetValue(letter, out char value))
					decodedMessage += value;
				else
					throw new DeccoderException(nameof(message), $"'{letter}' is not a valid letter to decode.");
			}
			decodedMessage += ' ';
		}
		return decodedMessage.Trim();
	}
}

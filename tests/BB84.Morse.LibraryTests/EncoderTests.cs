using BB84.Morse.Library;
using BB84.Morse.Library.Exceptions;
using BB84.Morse.Library.Interfaces;

namespace BB84.Morse.LibraryTests;

[TestClass]
public sealed class EncoderTests
{
	private readonly IEncoder _encoder = Encoder.Instance;

	[DataTestMethod]
	[DataRow("S", "...")]
	[DataRow("O", "---")]
	[DataRow("SOS", "... --- ...")]	
	[DataRow("Ha Ha", ".... .- / .... .-")]
	public void EncodeTest(string message, string expected)
		=> Assert.AreEqual(expected, _encoder.Encode(message));


	[DataTestMethod]
	[DataRow("*")]
	[DataRow("{")]
	[DataRow("}")]
	[ExpectedException(typeof(EncoderException))]
	public void EncodeExceptionTest(string message)
		=> Assert.AreEqual(string.Empty, _encoder.Encode(message));

	[DataTestMethod]
	[DataRow("...", "S")]
	[DataRow("---", "O")]
	[DataRow("... --- ...", "SOS")]	
	[DataRow(".... .- / .... .-", "HA HA")]
	public void DecodeTest(string message, string expected)
		=> Assert.AreEqual(expected, _encoder.Decode(message));

	[DataTestMethod]
	[DataRow("*")]
	[DataRow("[")]
	[DataRow("]")]
	[ExpectedException(typeof(DeccoderException))]
	public void DecodeExceptionTest(string message)
		=> Assert.AreEqual(string.Empty, _encoder.Decode(message));
}
